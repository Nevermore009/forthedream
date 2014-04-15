using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 分页
    /// 李超伟
    /// 2013-6-3
    /// update 2013-10-17
    /// </summary>
    public static class NewSplitPage
    {
        #region"分页"
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pars">参数（如name=123）</param>
        /// <param name="pageIndex">当前页面</param>
        /// <param name="PageSize">每页条数</param>
        /// <param name="allrecord">总记录数</param>
        public static string Pagination(string pars, int pageIndex, int PageSize, int allrecord)
        {
            pars = string.IsNullOrEmpty(pars) ? "?" : "?" + pars + "&";

            if (pageIndex == 0) pageIndex = 1;

            // 总页数
            int AllPage;

            StringBuilder result = new StringBuilder();
            if (allrecord > 0)
            {
                //获取总页数(整除和有余数的情况)
                if (allrecord % PageSize == 0)
                {
                    AllPage = allrecord / PageSize;
                }
                else
                {
                    AllPage = allrecord / PageSize + 1;
                }
                //获取当前页数
                if ((pageIndex > AllPage) && (AllPage != 0))
                {
                    pageIndex = AllPage;
                } 
                if (pageIndex == 1)
                {
                    result.Append("<span class='disabled'> 首页 </span>");
                    result.Append("<span class='disabled'> 上一页 </span>");
                }
                else
                {
                    result.Append("<a href=" + pars + "page=1> 首页 </a>");
                    result.Append("<a href=" + pars + "page=" + (pageIndex - 1) + "> 上一页 </a>");
                }

                if (AllPage <= 10)
                {
                    for (int i = 1; i <= AllPage; i++)
                    {
                        if (pageIndex == i)
                        {
                            result.Append("<span class='current'>" + i.ToString() + "</span>");
                        }
                        else
                        {
                            result.Append("<a href=" + pars + "page=" + i.ToString() + ">" + i.ToString() + "</a>");
                        }
                    }
                }
                else
                {
                    if (Convert.ToInt32(pageIndex) <= 4)
                    {
                        for (int i = 1; i <= 7; i++)
                        {
                            if (pageIndex == i)
                            {
                                result.Append("<span class='current'>" + i.ToString() + "</span>");
                            }
                            else
                            {
                                result.Append("<a href=" + pars + "page=" + i.ToString() + ">" + i.ToString() + "</a>");
                            }
                        }
                        result.Append("...");
                        result.Append("<a href=" + pars + "page=" + (AllPage - 1).ToString() + ">" + (AllPage - 1).ToString() + "</a>");
                        result.Append("<a href=" + pars + "page=" + AllPage.ToString() + ">" + AllPage.ToString() + "</a>");
                    }
                    else if (Convert.ToInt32(pageIndex) > AllPage - 7)
                    {
                        result.Append("<a href=" + pars + "page=1>1</a><a href=?page=2>2</a>...");
                        for (int i = 6; i >= 0; i--)
                        {
                            if (pageIndex == AllPage - i)
                            {
                                result.Append("<span class='current'>" + (AllPage - i).ToString() + "</span>");
                            }
                            else
                            {
                                result.Append("<a href=" + pars + "page=" + (AllPage - i).ToString() + ">" + (AllPage - i).ToString() + "</a>");
                            }
                        }
                    }
                    else
                    {
                        for (int i = Convert.ToInt32(pageIndex) - 3; i <= Convert.ToInt32(pageIndex) + 3; i++)
                        {
                            if (pageIndex == i)
                            {
                                result.Append("<span class='current'>" + i.ToString() + "</span>");
                            }
                            else
                            {
                                result.Append("<a href=" + pars + "page=" + i.ToString() + ">" + i.ToString() + "</a>");
                            }
                        }

                        result.Append("...");
                        result.Append("<a href=" + pars + "page=" + (AllPage - 1).ToString() + ">" + (AllPage - 1).ToString() + "</a>");
                        result.Append("<a href=" + pars + "page=" + AllPage.ToString() + ">" + AllPage.ToString() + "</a>");
                    }
                }
                if (pageIndex == AllPage)
                {
                    result.Append("<span class='disabled'> 下一页 </span>");
                    result.Append("<span class='disabled'> 尾页 </span>");
                }
                else
                {
                    result.Append("<a href=" + pars + "page=" + (pageIndex + 1) + "> 下一页 </a>");
                    result.Append("<a href=" + pars + "page=" + AllPage.ToString() + "> 尾页 </a>");
                }

            }
            else
            {
                result.Append("没有记录！");
            }
            return result.ToString();
        }
        #endregion
    }
}
