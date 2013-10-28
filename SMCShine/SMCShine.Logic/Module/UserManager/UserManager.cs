using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SMCShine.Data;
using SMCShine.Data.Entities;
using System.Data.Linq;
using SMCShine.Common;

namespace SMCShine.Logic
{
    public class UserManager
    {
        private GlobalDataContext dataContext = null;
        /// <summary>
        /// 当前DataContext对象
        /// </summary>
        public GlobalDataContext DataContext
        {
            get
            {
                if (dataContext == null)
                {
                    dataContext = new GlobalDataContext();
                }
                return dataContext;
            }
            set
            {
                if (dataContext == null || !dataContext.Equals(value))
                {
                    dataContext = value;
                }
            }
        }

        public enum LoginResult
        {
            ValidateSucceed = 0, UserNotExist = 1, IncorrectPwd = 2, UserUnavailable = 3, UnkownError = 4
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public LoginResult Login(string userAccount, string passWord, out User user)
        {
            user = null;
            try
            {
                user = DataContext.User.SingleOrDefault<User>(x => x.UserAccount == userAccount && x.State == 0);
                if (user == null)
                    return LoginResult.UserNotExist;
                if (user.UserPassword == AES.Encrypt(passWord))
                    return LoginResult.ValidateSucceed;
                else
                    return LoginResult.IncorrectPwd;
            }
            catch (Exception)
            {
                return LoginResult.UnkownError;
            }
        }

        public bool ChangePassWordById(Guid guid, string newPassword)
        {
            try
            {
                User user = DataContext.User.Single<User>(x => x.Guid == guid && x.State == 0);
                user.UserPassword = AES.Encrypt(newPassword);
                DataContext.SubmitChanges();
                return true;
            }
            catch (ChangeConflictException)
            {
                foreach (ObjectChangeConflict confict in DataContext.ChangeConflicts)
                {
                    confict.Resolve(RefreshMode.KeepCurrentValues);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                DataContext.SubmitChanges();
            }
        }

        public object GetAllGroup(string campusGuid)
        {
            if (string.IsNullOrEmpty(campusGuid))
            {
                return null;
            }
            object list;
            if (campusGuid == Guid.Empty.ToString())
            {
                list = from ug in DataContext.UserGroup
                       where ug.State == 0 && ug.CampusGuid != null
                       select ug;
            }
            else
            {
                list = from ug in DataContext.UserGroup
                       join cmp in DataContext.Campus on ug.CampusGuid equals cmp.Guid
                       where ug.State == 0 && ug.CampusGuid != null
                       select new
                       {
                           Guid = ug.Guid,
                           Name = ug.Name + "(" + cmp.Name + ")"
                       };
            }
            return list;
            //return DataContext.UserGroup.Where(x => x.State == 0 && x.CampusGuid != null).ToList<UserGroup>();
        }


        public string GetUserGroupName(Guid guid)
        {
            string userGroupName = DataContext.UserGroup.SingleOrDefault<UserGroup>(x => x.Guid == guid && x.State == 0).Name;
            return userGroupName;
        }

        public UserGroup GetGroupByID(Guid guid)
        {
            return DataContext.UserGroup.SingleOrDefault(x => x.Guid == guid && x.State == 0);
        }


        public bool AddUserGroup(UserGroup entity)
        {
            UserGroup usergroup = DataContext.UserGroup.SingleOrDefault(x => x.Name == entity.Name && x.State == 0 && x.CampusGuid == entity.CampusGuid);
            if (usergroup == null)
            {
                DataContext.UserGroup.InsertOnSubmit(entity);
                DataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddUser(User entity)
        {
            User user = DataContext.User.SingleOrDefault(x => x.UserAccount == entity.UserAccount && x.State == 0);
            if (user == null)
            {
                entity.UserPassword = AES.Encrypt(entity.UserPassword);
                DataContext.User.InsertOnSubmit(entity);
                DataContext.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetPermisionXml(Guid guid)
        {
            return DataContext.UserGroup.SingleOrDefault(x => x.Guid == guid).PermisionXml;
        }
    }
}
