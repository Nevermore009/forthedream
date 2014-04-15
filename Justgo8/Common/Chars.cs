using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Common
{
	/// <summary>
	/// JudgeValue 的摘要说明。
	/// </summary>
	public class Chars
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public Chars()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


        /*以下是处理SQL字符相关*/

        /// 过滤输入界面中非法sql字符 
        /// </summary> 
        /// <param name="value">要过滤的字符串 </param> 
        /// <returns>string </returns> 
        public static string Filter(string value)
        {
            //return value;
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            value = Regex.Replace(value, @"and", string.Empty);
            value = Regex.Replace(value, @"or", string.Empty);
            value = Regex.Replace(value, @"create", string.Empty);
            value = Regex.Replace(value, @"delete", string.Empty);
            value = Regex.Replace(value, @"update", string.Empty);
            value = Regex.Replace(value, @"select", string.Empty);
            value = Regex.Replace(value, @"count", string.Empty);
            value = Regex.Replace(value, @"%20", string.Empty);
            value = Regex.Replace(value, @"from", string.Empty);
            value = Regex.Replace(value, @"table", string.Empty);
            value = Regex.Replace(value, @"alter", string.Empty);
            value = Regex.Replace(value, @"sp_", string.Empty);
            value = Regex.Replace(value, @"exec", string.Empty);
            value = Regex.Replace(value, @"execute", string.Empty);
            value = Regex.Replace(value, @"union", string.Empty);
            value = Regex.Replace(value, @"dele", string.Empty);
            value = Regex.Replace(value, @"drop", string.Empty);
            value = Regex.Replace(value, @"delcare", string.Empty);
            value = Regex.Replace(value, @"truncate", string.Empty);
            value = Regex.Replace(value, @"chr", string.Empty);
            value = Regex.Replace(value, @";", string.Empty);
            value = Regex.Replace(value, @"'", string.Empty);
            value = Regex.Replace(value, @"&", string.Empty);
            value = Regex.Replace(value, @"--", string.Empty);
            value = Regex.Replace(value, @"==", string.Empty);
            value = Regex.Replace(value, @"<", string.Empty);
            value = Regex.Replace(value, @">", string.Empty);
            value = Regex.Replace(value, @"%", string.Empty);

            return value;
        }

		/// <summary>
		/// 防止字符串注入
		/// </summary>
		/// <param name="_strValue">需要判断的字符串</param>
		/// <returns>如果字符串检索与防注入的字符串相匹配，则返回 false 值，否则返回 true 值</returns>
		public static bool IsImmit(string _strValue)
		{
			string[] _str = {"dir","cmd","'","copy","format","and","exec","insert","select","delete","update","count","*","chr","mid","master","truncate","char","declare"};
			for(int i=0;i<_str.Length;i++)
			{
				if(_strValue.IndexOf(_str[i]) >= 0)
					return false;
			}
			return true;
		}

		/// <summary>
		/// 替换输入非法字符，如 html 端中的 ＜、＞
		/// </summary>
		/// <param name="_inputString">需要转换的字符串</param>
		/// <returns>返回已转换后的新字符串</returns>
		public static string InputText(string _inputString)
		{
			StringBuilder retVal = new StringBuilder();

			_inputString = System.Web.HttpContext.Current.Server.HtmlEncode(_inputString);
			if ((_inputString != null) && (_inputString != String.Empty))
			{
				_inputString = _inputString.Trim();
				for (int i = 0; i < _inputString.Length; i++)
				{
					switch (_inputString[i])
					{
						case '"':
							retVal.Append("&quot;");
							break;
						case '<':
							retVal.Append("&lt;");
							break;
						case '>':
							retVal.Append("&gt;");
							break;
						case ' ':
							retVal.Append("&nbsp;");
							break;
						default:
							retVal.Append(_inputString[i]);
							break;
					}
				}
			}
			return retVal.ToString().Replace("\n", "<br>").Replace(" ", "&nbsp;").Replace("'", "‘");
		}


        /*以下是处理字符过渡相关*/

		/// <summary>
		/// 检查字符串是否为空值
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <returns>当字符串为空时返回 false 值，否则返回 true 值</returns>
		public static bool IsNull(string _strValue)
		{
			if(_strValue == "" || _strValue == null || _strValue.Length == 0)
				return false;
			return true;
		}

		/// <summary>
		/// 检查字符串是否超出指定长度
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <param name="iLen">设置字符串的长度范围</param>
		/// <returns>当字符串的长度超出设置字符串的长度范围时返回 false 值，否则返回 true 值</returns>
		public static bool IsLen(string _strValue,int iLen)
		{
			if(iLen > 0 && _strValue.Length > 0)
			{
				if(_strValue.Length > iLen)
					return false;
			}
			return true;
		}

		/// <summary>
		/// 检查字符串是否为数字(整数)
		/// </summary>
		/// <param name="_strValue"> 字符串的值</param>
		/// <returns>首先判断是否为数字，如果是数字，那么就返回字符串的整数形式，如果不是数字，则返回默认整型 0 值</returns>
		public static int RetInt(string _strValue)
		{
			if(IsInt(_strValue))
			{
				return Convert.ToInt32(_strValue);
			}
			return 0;
		} 

		/// <summary>
		/// 检查字符串是否为数字(整数)，这里用正则表达式
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <returns>如果参数的值不是数字时返回 false 值，否则返回 true 值</returns>
		public static bool IsInt(string _strValue)
		{		
			Regex regex = new Regex(@"^\d+$");
			return regex.Match(_strValue).Success;
		}

		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		/// <summary>
		/// 是否数字字符串可带 +- 号
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>如果带正负号，则返回 true 值，否则返回 false 值</returns>
		public static bool IsSignInt(string _strValue)
		{
			Match m = RegNumberSign.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// 返回带 +- 号的整数
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>返回带 +- 号的整数</returns>
		public static int RetSignInt(string _strValue)
		{
			if(IsSignInt(_strValue))
			{
				return Convert.ToInt32(_strValue);
			}
			return 0;
		}

		private static System.Text.RegularExpressions.Regex RegFloat = new Regex("^[0-9]+[.]?[0-9]+$");
		/// <summary>
		/// 判断是否为 float 型
		/// </summary>
		/// <param name="_strValue">输入的字符串</param>
		/// <returns>返回 bool 值</returns>
		public static bool IsFloat(string _strValue)
		{
			Match m = RegFloat.Match(_strValue);
			return m.Success;
		} 

		/// <summary>
		/// 返回字符串是否为 float 类型，这里用正则表达式，可以带 +- 号
		/// </summary>
		/// <param name="_strValue">输入的字符串</param>
		/// <returns>如果该字符串为 float 类型，则返回字符串的 float 类型的值，否则返回 0.0000 数，表示没有返回成功</returns>
		public static float RetFloat(string _strValue)
		{
			if(_strValue != "" && IsFloat(_strValue))
			{
				return Convert.ToSingle(_strValue);
			}
			return (float)0;
		}


		private static Regex RegDouble = new Regex(@"^[+-]?\d*(,\d{3})*(\.\d+)?$"); 
		/// <summary>
		/// 检查字符串是否为 double 类型，这里用正则表达式，可以带 +- 号
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <returns>如果参数的值不是 double  类型时返回 false 值，否则返回 true 值</returns>
		public static bool IsDouble(string _strValue)
		{
			Match m = RegDouble.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// 返回字符串带 +- 号的 double 类型，这里用正则表达式
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <returns>返回字符串带 +- 号的 double 类型，这里用正则表达式</returns>
		public static double RetDouble(string _strValue)
		{
			if(IsDouble(_strValue))
			{
				return Double.Parse(_strValue);
			}
			return (double)0;
		}

		/// <summary>
		/// 检查字符串是否为数字，这里用正则表达式
		/// </summary>
		/// <param name="_strValue">字符串的值</param>
		/// <returns>如果参数的值不是数字时返回 false 值，否则返回 true 值</returns>
		public static bool IsNumeric(string _strValue)
		{		
			Regex regex = new Regex(@"^[+-]?\d*(,\d{3})*(\.\d+)?$");
			return regex.Match(_strValue).Success;				 
		}	

		/// <summary>
		/// 判断一个整数是否是另一个数的倍数
		/// </summary>
		/// <param name="_iNum">要判断的整数</param>
		/// <param name="_iMultiple">倍数</param>
		/// <returns>如果整除返回 true 值，否则返回 false 值</returns>
		public static bool IsMultiple(int _iNum,int _iMultiple)
		{
			if(_iNum % _iMultiple != 0)
				return false;
			return true;
		}

		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		/// <summary>
		/// 是否是浮点数
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>检索字符串是否为浮点数，如果为浮点数时，则返回 true 值，否则返回 false 值</returns>
		public static bool IsDecimal(string _strValue)
		{
			Match m = RegDecimal.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// 返回字符串是否为 float 类型，这里用正则表达式，可以带 +- 号
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>如果该字符串为 decimal 类型，则返回字符串的 decimal 类型的值，否则返回 0.0000 数，表示没有返回成功</returns>
		public static decimal RetDecimal(string _strValue)
		{
			if(IsDecimal(_strValue))
			{
				return Convert.ToDecimal(_strValue);
			}
			return 0;
		}
       
		private static Regex RegSignDecimal = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
		/// <summary>
		/// 是否是浮点数可带正负号
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>检索字符串是否为带正负号的浮点数，如果是则返回 ture 值，否则返回 false 值</returns>
		public static bool IsSignDecimal(string _strValue)
		{
			Match m = RegSignDecimal.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// 当一个字符串中有符点数及字符串时，返回样式为：符点数 - 字符串；如果字符串中有 2 个".."时，如：12..11abcd 中，返回 1211-abcd 这个字符串
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>当一个字符串中有符点数及字符串时，返回样式为：符点数 - 字符串；如果字符串中有 2 个".."时，如：12..11abcd 中，返回 1211-abcd 这个字符串</returns>
		public static string RetNumSplitStr(string _strValue)
		{
			string _str = _strValue;
			string _strRetNum = string.Empty,_strTote = string.Empty;
			
			for(int i=0;i<_str.Length;i++)
			{
				if(Char.IsDigit(Convert.ToChar(_str[i])) )
				{
					_strRetNum += _str[i]; 
				}
				else if(_str[i].ToString() == "." && i + 1 <_str.Length && _str[0].ToString() != "." && i - 1 != 0)
				{
					if(Char.IsDigit(Convert.ToChar(_str[i-1])) && Char.IsDigit(Convert.ToChar(_str[i+1])))
						_strRetNum += _str[i];
				}
				else
				{
					_strTote += _str[i];
				}
			}		
			return _strRetNum + "-" + _strTote;
		}

		/// <summary>
		/// 判断字符串是否有小数点
		/// </summary>
		/// <param name="_strValue">要检索的字符串</param>
		/// <returns>如果有小数点返回 false 值，否则返回 true 值</returns>
		public static bool IsRadixPoint(string _strValue)
		{
			if(_strValue.IndexOf(".") >= 0)
				return false;
			return true;
		}

		private static Regex NumAndChar = new Regex("^[A-Za-z0-9]+$"); 
		/// <summary>
		/// 判断只能有数字0-9和26个英文字母（包括大小写）组成
		/// </summary>
		/// <param name="_strValue">要检索的字符串</param>
		/// <returns>如果字符串不是数字和英文返回 false 值，否则返回 true 值</returns>
		public static bool IsNumAndChar(string _strValue)
		{
			Match m=NumAndChar.Match(_strValue);
			return m.Success;
		} 

		private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
		/// <summary>
		/// 检测是否有中文字符
		/// </summary>
		/// <param name="_strValue">要检索的字符串</param>
		/// <returns>如果字符中有中文字符，则返回为 false 值，否则返回 true 值</returns>
		public static bool IsHasCHZN(string _strValue)
		{
			Match m = RegCHZN.Match(_strValue);
			return m.Success;
		}

		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
		/// <summary>
		/// 邮件地址
		/// </summary>
		/// <param name="_strValue">输入字符串</param>
		/// <returns>判断邮件地址是否规范，如果是则返回 true 值，否则返回 false 值</returns>
		public static bool IsEmail(string _strValue)
		{
			Match m = RegEmail.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// 去掉字符串 ',＜,＞
		/// </summary>
		/// <param name="_objValue">对象的值</param>
		/// <returns>返回去掉 ',＜,＞ 之后的字符串</returns>
		public static string strReplace(object _objValue)
		{
			if (_objValue != null && _objValue.ToString() != "")
			{
				return _objValue.ToString().Replace("'","").Replace("<","").Replace(">","");
			}			 
			return "";
		}

		/// <summary>
		/// 截取字符串的指定长度
		/// </summary>
		/// <param name="str">需要截取的字符串</param>
		/// <param name="maxSize">需要截取的最大长度</param>
		/// <returns>返回截取的字符串，被截取的字符串样式为 aaaaa.......</returns>
		public static string strIntercept(string str, int maxSize)
		{
			str = Html_ToClient(str);
			if (str == string.Empty)
			{
				return string.Empty;
			}
			int num = 0;
			byte[] bytes = new System.Text.ASCIIEncoding().GetBytes(str);
			for (int i = 0; i <= (bytes.Length - 1); i++)
			{
				if (bytes[i] == 0x3f)
				{
					num += 2;
				}
				else
				{
					num++;
				}
				if (num > maxSize)
				{
					str = str.Substring(0, i);
                    return str + "...";
				}
			}
			return str;
		}

		/// <summary>
		/// 将字符串做HTML解码,并去掉字符串末端空格 
		/// </summary>
		/// <param name="_strValue">>需要做 HTML 解码的字符串</param>
		/// <returns>返回已做 HTML 解码的字符串</returns>
		public static string Html_ToClient(string _strValue)
		{
			if (_strValue == null)
			{
				return null;
			}
			if (_strValue != string.Empty)
			{
				return HttpContext.Current.Server.HtmlDecode(_strValue.Trim());
			}
			return string.Empty;
		}

		/// <summary>
		/// 将字符串做HTML编码,并去掉字符串末端空格 
		/// </summary>
		/// <param name="_strValue">需要做 HTML 编码的字符串</param>
		/// <returns>返回已做 HTML 编码的字符串</returns>
		public static string Html_ToServer(string _strValue)
		{
			if ((_strValue != null) && (_strValue != string.Empty))
			{
				return HttpContext.Current.Server.HtmlEncode(_strValue.Trim());
			}
			return string.Empty;
		}
	
		/// <summary>
		/// 返回 Request.QuertString 对象的 String 字符串形式
		/// </summary>
		/// <param name="_obj">Request 对象</param>
		/// <returns>返回 Request 对象的 String 字符串形式</returns>
		public static string strRequest(object _obj)
		{
			if(_obj != null && _obj.ToString() != "")
				return _obj.ToString();
			return string.Empty;
		} 

		/// <summary>
		/// 判断文件扩展名是否正确
		/// </summary>
		/// <param name="_strValue">需判断的文件名字符串</param>
		/// <param name="_strReamType">扩展名字符串</param>
		/// <returns>如果扩展名字符串一致时返回 true 值，否则返回 false 值</returns>
		public static bool IsFileReam(string _strValue,string _strReamType)
		{
			if(_strValue.ToLower().IndexOf(_strReamType.ToLower()) > 0)
				return true;
			return false;
		}

		/// <summary>
		/// 获得指定位数的随机数
		/// </summary>
		/// <param name="iNum">位数，小于6</param>
		/// <returns>指定位数的随机数</returns>
		public static string getRndom(int iNum)
		{
			Random rnd = new Random();
			Double i = rnd.NextDouble();
			return i.ToString().Substring(2,iNum);
		}

        /// <summary>
        /// 阿拉伯数字转换成中文数字
        /// </summary>
        /// <param name="inputNum">阿拉伯数字</param>
        /// <returns></returns>
        public static string ReturnStr(int inputNum)
        {
            string[] intArr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] strArr = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "零" };

            string tmpArr = inputNum.ToString();
            string tmpVal = "";

            for (int i = 0; i < tmpArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length; j++)
                {
                    if (tmpArr[i].ToString() == intArr[j].ToString())
                    {
                        tmpVal = tmpVal + strArr[j].ToString();
                        break;
                    }
                }
            }

            return tmpVal;
        }

        /*以下是加密相关算法 */

		#region 字符串位置交换法加密解密
		/// <summary>
		/// 字符串位置交换法加密
		/// </summary>
		/// <param name="_str">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public static string stringEncode(string _str)
		{
			string newstr="";
			char[] chr=_str.ToCharArray();
			int Length=chr.Length;
			for(int i=0;i<Length;i++)
			{
				newstr += chr[Length-i-1].ToString() + chr[i].ToString();
			}
			return newstr.Substring(Length);
		}

		/// <summary>
		/// 字符串位置交换法解密
		/// </summary>
		/// <param name="_str">要解密的字符串</param>
		/// <returns>解密后的字符串</returns>
		public static string stringDecode(string _str)
		{
			string newstr="";
			char[] chr=_str.ToCharArray();
			for(int i=0;i<chr.Length;i++)
			{
				_str=chr[i].ToString() + _str;
			}
			chr=_str.ToCharArray();
			for(int i=0;i<chr.Length;i++)
			{
				if(i%2 != 0)
                    newstr += chr[i].ToString();
			}
			return newstr;
		}
		#endregion

		#region DES加密
		/// <summary>
		/// DES加密
		/// </summary>
		/// <param name="_strValue">需要加密的字符串</param>
		/// <returns>返回加密后的字符串</returns>
		public static string QxEncrypt(string _strValue)
		{
			PasswordDeriveBytes pdb = new PasswordDeriveBytes("", null);
			DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
			byte[] key = pdb.CryptDeriveKey("DES", "SHA1", 0, new byte[8]);
			byte[] data = System.Text.Encoding.Unicode.GetBytes(_strValue);

			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, desc.CreateEncryptor(key, key), CryptoStreamMode.Write);

			cs.Write(data, 0, data.Length);
			cs.FlushFinalBlock();
			return System.Text.Encoding.Unicode.GetString(ms.ToArray());
		}
		#endregion

		#region DES解密
		/// <summary>
		/// DES解密
		/// </summary>
		/// <param name="_strValue">需要解密的字符串</param>
		/// <returns>解密后的字符串</returns>
		public static string QxDecrypt(string _strValue)
		{
			PasswordDeriveBytes pdb = new PasswordDeriveBytes("", null);
			DESCryptoServiceProvider desc = new DESCryptoServiceProvider();
			byte[] key = pdb.CryptDeriveKey("DES", "SHA1", 0, new byte[8]);
			byte[] data = System.Text.Encoding.Unicode.GetBytes(_strValue);

			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, desc.CreateDecryptor(key, key), CryptoStreamMode.Write);
			cs.Write(data, 0, data.Length);
			cs.FlushFinalBlock();
			return System.Text.Encoding.Unicode.GetString(ms.ToArray());
		}
		#endregion		

		#region MD5加密
		private const string HEX_TABLE = "0123456789ABCDEF";
		/// <summary>
		/// MD5加密
		/// </summary>
		/// <param name="stream">数据流</param>
		/// <returns>返回加密后的字符串</returns>
		public static string QxGetMD5(Stream stream)
		{
			MD5 md5 = new MD5CryptoServiceProvider();
			//Calculate MD5 Checksum
			byte[] data = md5.ComputeHash(stream);
			//convert to string
			StringBuilder sb = new StringBuilder();
			sb.Length = data.Length * 2;
			for (int i = 0; i < data.Length; i++)
			{
				sb[i * 2] = HEX_TABLE[data[i] >> 4];
				sb[i * 2 + 1] = HEX_TABLE[data[i] & 0xF];
			}
			md5.Clear();
			return sb.ToString();
		}

		/// <summary>
		/// MD5加密
		/// </summary>
		/// <param name="_strValue">要加密的字符串</param>
		/// <returns>返回32位加密后的字符串</returns>
		public static string QxGetMD5(string _strValue)
		{
			byte[] data = ASCIIEncoding.ASCII.GetBytes(_strValue);
			MemoryStream stream = new MemoryStream(data);
			return QxGetMD5(stream);
		}

		/// <summary>
		///  MD5加密
		/// </summary>
		/// <param name="_strValue">要加密的字符串</param>
		/// <param name="_iSubLen">要截取密串的长度</param>
		/// <returns>返回截取密串的字符串形式</returns>
		public static string QxGetMD5(string _strValue,int _iSubLen)
		{
			byte[] data = ASCIIEncoding.ASCII.GetBytes(_strValue);
			MemoryStream stream = new MemoryStream(data);
			return QxGetMD5(stream).Substring(0,_iSubLen);
		}
		#endregion

        #region Json拼接

        /// <summary>
        /// 合并为JSON格式的字符串
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="message">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string MergerJson(int errorCode, string message, string data = "")
        {
            return "{\"errorCode\":" + errorCode + ",\"message\":\"" + message + "\",\"data\":" + (string.IsNullOrEmpty(data) ? "[]" : data) + "}";
        }

        /// <summary>
        /// 合并为JSON格式的字符串
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="message">消息</param>
        /// <param name="data">总数量</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string MergerJson(int errorCode, string message, int total, string data = "")
        {
            return "{\"errorCode\":" + errorCode + ",\"message\":\"" + message + "\",\"data\":" + (string.IsNullOrEmpty(data) ? "[]" : data) + ",\"total\":" + total + "}";
        }

        #endregion
	}
}
