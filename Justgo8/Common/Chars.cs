using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Common
{
	/// <summary>
	/// JudgeValue ��ժҪ˵����
	/// </summary>
	public class Chars
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public Chars()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}


        /*�����Ǵ���SQL�ַ����*/

        /// ������������зǷ�sql�ַ� 
        /// </summary> 
        /// <param name="value">Ҫ���˵��ַ��� </param> 
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
		/// ��ֹ�ַ���ע��
		/// </summary>
		/// <param name="_strValue">��Ҫ�жϵ��ַ���</param>
		/// <returns>����ַ����������ע����ַ�����ƥ�䣬�򷵻� false ֵ�����򷵻� true ֵ</returns>
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
		/// �滻����Ƿ��ַ����� html ���е� ������
		/// </summary>
		/// <param name="_inputString">��Ҫת�����ַ���</param>
		/// <returns>������ת��������ַ���</returns>
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
			return retVal.ToString().Replace("\n", "<br>").Replace(" ", "&nbsp;").Replace("'", "��");
		}


        /*�����Ǵ����ַ��������*/

		/// <summary>
		/// ����ַ����Ƿ�Ϊ��ֵ
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <returns>���ַ���Ϊ��ʱ���� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsNull(string _strValue)
		{
			if(_strValue == "" || _strValue == null || _strValue.Length == 0)
				return false;
			return true;
		}

		/// <summary>
		/// ����ַ����Ƿ񳬳�ָ������
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <param name="iLen">�����ַ����ĳ��ȷ�Χ</param>
		/// <returns>���ַ����ĳ��ȳ��������ַ����ĳ��ȷ�Χʱ���� false ֵ�����򷵻� true ֵ</returns>
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
		/// ����ַ����Ƿ�Ϊ����(����)
		/// </summary>
		/// <param name="_strValue"> �ַ�����ֵ</param>
		/// <returns>�����ж��Ƿ�Ϊ���֣���������֣���ô�ͷ����ַ�����������ʽ������������֣��򷵻�Ĭ������ 0 ֵ</returns>
		public static int RetInt(string _strValue)
		{
			if(IsInt(_strValue))
			{
				return Convert.ToInt32(_strValue);
			}
			return 0;
		} 

		/// <summary>
		/// ����ַ����Ƿ�Ϊ����(����)��������������ʽ
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <returns>���������ֵ��������ʱ���� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsInt(string _strValue)
		{		
			Regex regex = new Regex(@"^\d+$");
			return regex.Match(_strValue).Success;
		}

		private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
		/// <summary>
		/// �Ƿ������ַ����ɴ� +- ��
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>����������ţ��򷵻� true ֵ�����򷵻� false ֵ</returns>
		public static bool IsSignInt(string _strValue)
		{
			Match m = RegNumberSign.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// ���ش� +- �ŵ�����
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>���ش� +- �ŵ�����</returns>
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
		/// �ж��Ƿ�Ϊ float ��
		/// </summary>
		/// <param name="_strValue">������ַ���</param>
		/// <returns>���� bool ֵ</returns>
		public static bool IsFloat(string _strValue)
		{
			Match m = RegFloat.Match(_strValue);
			return m.Success;
		} 

		/// <summary>
		/// �����ַ����Ƿ�Ϊ float ���ͣ�������������ʽ�����Դ� +- ��
		/// </summary>
		/// <param name="_strValue">������ַ���</param>
		/// <returns>������ַ���Ϊ float ���ͣ��򷵻��ַ����� float ���͵�ֵ�����򷵻� 0.0000 ������ʾû�з��سɹ�</returns>
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
		/// ����ַ����Ƿ�Ϊ double ���ͣ�������������ʽ�����Դ� +- ��
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <returns>���������ֵ���� double  ����ʱ���� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsDouble(string _strValue)
		{
			Match m = RegDouble.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// �����ַ����� +- �ŵ� double ���ͣ�������������ʽ
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <returns>�����ַ����� +- �ŵ� double ���ͣ�������������ʽ</returns>
		public static double RetDouble(string _strValue)
		{
			if(IsDouble(_strValue))
			{
				return Double.Parse(_strValue);
			}
			return (double)0;
		}

		/// <summary>
		/// ����ַ����Ƿ�Ϊ���֣�������������ʽ
		/// </summary>
		/// <param name="_strValue">�ַ�����ֵ</param>
		/// <returns>���������ֵ��������ʱ���� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsNumeric(string _strValue)
		{		
			Regex regex = new Regex(@"^[+-]?\d*(,\d{3})*(\.\d+)?$");
			return regex.Match(_strValue).Success;				 
		}	

		/// <summary>
		/// �ж�һ�������Ƿ�����һ�����ı���
		/// </summary>
		/// <param name="_iNum">Ҫ�жϵ�����</param>
		/// <param name="_iMultiple">����</param>
		/// <returns>����������� true ֵ�����򷵻� false ֵ</returns>
		public static bool IsMultiple(int _iNum,int _iMultiple)
		{
			if(_iNum % _iMultiple != 0)
				return false;
			return true;
		}

		private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
		/// <summary>
		/// �Ƿ��Ǹ�����
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>�����ַ����Ƿ�Ϊ�����������Ϊ������ʱ���򷵻� true ֵ�����򷵻� false ֵ</returns>
		public static bool IsDecimal(string _strValue)
		{
			Match m = RegDecimal.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// �����ַ����Ƿ�Ϊ float ���ͣ�������������ʽ�����Դ� +- ��
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>������ַ���Ϊ decimal ���ͣ��򷵻��ַ����� decimal ���͵�ֵ�����򷵻� 0.0000 ������ʾû�з��سɹ�</returns>
		public static decimal RetDecimal(string _strValue)
		{
			if(IsDecimal(_strValue))
			{
				return Convert.ToDecimal(_strValue);
			}
			return 0;
		}
       
		private static Regex RegSignDecimal = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //�ȼ���^[+-]?\d+[.]?\d+$
		/// <summary>
		/// �Ƿ��Ǹ������ɴ�������
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>�����ַ����Ƿ�Ϊ�������ŵĸ�������������򷵻� ture ֵ�����򷵻� false ֵ</returns>
		public static bool IsSignDecimal(string _strValue)
		{
			Match m = RegSignDecimal.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// ��һ���ַ������з��������ַ���ʱ��������ʽΪ�������� - �ַ���������ַ������� 2 ��".."ʱ���磺12..11abcd �У����� 1211-abcd ����ַ���
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>��һ���ַ������з��������ַ���ʱ��������ʽΪ�������� - �ַ���������ַ������� 2 ��".."ʱ���磺12..11abcd �У����� 1211-abcd ����ַ���</returns>
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
		/// �ж��ַ����Ƿ���С����
		/// </summary>
		/// <param name="_strValue">Ҫ�������ַ���</param>
		/// <returns>�����С���㷵�� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsRadixPoint(string _strValue)
		{
			if(_strValue.IndexOf(".") >= 0)
				return false;
			return true;
		}

		private static Regex NumAndChar = new Regex("^[A-Za-z0-9]+$"); 
		/// <summary>
		/// �ж�ֻ��������0-9��26��Ӣ����ĸ��������Сд�����
		/// </summary>
		/// <param name="_strValue">Ҫ�������ַ���</param>
		/// <returns>����ַ����������ֺ�Ӣ�ķ��� false ֵ�����򷵻� true ֵ</returns>
		public static bool IsNumAndChar(string _strValue)
		{
			Match m=NumAndChar.Match(_strValue);
			return m.Success;
		} 

		private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");
		/// <summary>
		/// ����Ƿ��������ַ�
		/// </summary>
		/// <param name="_strValue">Ҫ�������ַ���</param>
		/// <returns>����ַ����������ַ����򷵻�Ϊ false ֵ�����򷵻� true ֵ</returns>
		public static bool IsHasCHZN(string _strValue)
		{
			Match m = RegCHZN.Match(_strValue);
			return m.Success;
		}

		private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w Ӣ����ĸ�����ֵ��ַ������� [a-zA-Z0-9] �﷨һ�� 
		/// <summary>
		/// �ʼ���ַ
		/// </summary>
		/// <param name="_strValue">�����ַ���</param>
		/// <returns>�ж��ʼ���ַ�Ƿ�淶��������򷵻� true ֵ�����򷵻� false ֵ</returns>
		public static bool IsEmail(string _strValue)
		{
			Match m = RegEmail.Match(_strValue);
			return m.Success;
		}

		/// <summary>
		/// ȥ���ַ��� ',��,��
		/// </summary>
		/// <param name="_objValue">�����ֵ</param>
		/// <returns>����ȥ�� ',��,�� ֮����ַ���</returns>
		public static string strReplace(object _objValue)
		{
			if (_objValue != null && _objValue.ToString() != "")
			{
				return _objValue.ToString().Replace("'","").Replace("<","").Replace(">","");
			}			 
			return "";
		}

		/// <summary>
		/// ��ȡ�ַ�����ָ������
		/// </summary>
		/// <param name="str">��Ҫ��ȡ���ַ���</param>
		/// <param name="maxSize">��Ҫ��ȡ����󳤶�</param>
		/// <returns>���ؽ�ȡ���ַ���������ȡ���ַ�����ʽΪ aaaaa.......</returns>
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
		/// ���ַ�����HTML����,��ȥ���ַ���ĩ�˿ո� 
		/// </summary>
		/// <param name="_strValue">>��Ҫ�� HTML ������ַ���</param>
		/// <returns>�������� HTML ������ַ���</returns>
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
		/// ���ַ�����HTML����,��ȥ���ַ���ĩ�˿ո� 
		/// </summary>
		/// <param name="_strValue">��Ҫ�� HTML ������ַ���</param>
		/// <returns>�������� HTML ������ַ���</returns>
		public static string Html_ToServer(string _strValue)
		{
			if ((_strValue != null) && (_strValue != string.Empty))
			{
				return HttpContext.Current.Server.HtmlEncode(_strValue.Trim());
			}
			return string.Empty;
		}
	
		/// <summary>
		/// ���� Request.QuertString ����� String �ַ�����ʽ
		/// </summary>
		/// <param name="_obj">Request ����</param>
		/// <returns>���� Request ����� String �ַ�����ʽ</returns>
		public static string strRequest(object _obj)
		{
			if(_obj != null && _obj.ToString() != "")
				return _obj.ToString();
			return string.Empty;
		} 

		/// <summary>
		/// �ж��ļ���չ���Ƿ���ȷ
		/// </summary>
		/// <param name="_strValue">���жϵ��ļ����ַ���</param>
		/// <param name="_strReamType">��չ���ַ���</param>
		/// <returns>�����չ���ַ���һ��ʱ���� true ֵ�����򷵻� false ֵ</returns>
		public static bool IsFileReam(string _strValue,string _strReamType)
		{
			if(_strValue.ToLower().IndexOf(_strReamType.ToLower()) > 0)
				return true;
			return false;
		}

		/// <summary>
		/// ���ָ��λ���������
		/// </summary>
		/// <param name="iNum">λ����С��6</param>
		/// <returns>ָ��λ���������</returns>
		public static string getRndom(int iNum)
		{
			Random rnd = new Random();
			Double i = rnd.NextDouble();
			return i.ToString().Substring(2,iNum);
		}

        /// <summary>
        /// ����������ת������������
        /// </summary>
        /// <param name="inputNum">����������</param>
        /// <returns></returns>
        public static string ReturnStr(int inputNum)
        {
            string[] intArr = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            string[] strArr = { "һ", "��", "��", "��", "��", "��", "��", "��", "��", "��" };

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

        /*�����Ǽ�������㷨 */

		#region �ַ���λ�ý��������ܽ���
		/// <summary>
		/// �ַ���λ�ý���������
		/// </summary>
		/// <param name="_str">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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
		/// �ַ���λ�ý���������
		/// </summary>
		/// <param name="_str">Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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

		#region DES����
		/// <summary>
		/// DES����
		/// </summary>
		/// <param name="_strValue">��Ҫ���ܵ��ַ���</param>
		/// <returns>���ؼ��ܺ���ַ���</returns>
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

		#region DES����
		/// <summary>
		/// DES����
		/// </summary>
		/// <param name="_strValue">��Ҫ���ܵ��ַ���</param>
		/// <returns>���ܺ���ַ���</returns>
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

		#region MD5����
		private const string HEX_TABLE = "0123456789ABCDEF";
		/// <summary>
		/// MD5����
		/// </summary>
		/// <param name="stream">������</param>
		/// <returns>���ؼ��ܺ���ַ���</returns>
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
		/// MD5����
		/// </summary>
		/// <param name="_strValue">Ҫ���ܵ��ַ���</param>
		/// <returns>����32λ���ܺ���ַ���</returns>
		public static string QxGetMD5(string _strValue)
		{
			byte[] data = ASCIIEncoding.ASCII.GetBytes(_strValue);
			MemoryStream stream = new MemoryStream(data);
			return QxGetMD5(stream);
		}

		/// <summary>
		///  MD5����
		/// </summary>
		/// <param name="_strValue">Ҫ���ܵ��ַ���</param>
		/// <param name="_iSubLen">Ҫ��ȡ�ܴ��ĳ���</param>
		/// <returns>���ؽ�ȡ�ܴ����ַ�����ʽ</returns>
		public static string QxGetMD5(string _strValue,int _iSubLen)
		{
			byte[] data = ASCIIEncoding.ASCII.GetBytes(_strValue);
			MemoryStream stream = new MemoryStream(data);
			return QxGetMD5(stream).Substring(0,_iSubLen);
		}
		#endregion

        #region Jsonƴ��

        /// <summary>
        /// �ϲ�ΪJSON��ʽ���ַ���
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">��Ϣ</param>
        /// <param name="data">����</param>
        /// <returns></returns>
        public static string MergerJson(int errorCode, string message, string data = "")
        {
            return "{\"errorCode\":" + errorCode + ",\"message\":\"" + message + "\",\"data\":" + (string.IsNullOrEmpty(data) ? "[]" : data) + "}";
        }

        /// <summary>
        /// �ϲ�ΪJSON��ʽ���ַ���
        /// </summary>
        /// <param name="errorCode">�������</param>
        /// <param name="message">��Ϣ</param>
        /// <param name="data">������</param>
        /// <param name="data">����</param>
        /// <returns></returns>
        public static string MergerJson(int errorCode, string message, int total, string data = "")
        {
            return "{\"errorCode\":" + errorCode + ",\"message\":\"" + message + "\",\"data\":" + (string.IsNullOrEmpty(data) ? "[]" : data) + ",\"total\":" + total + "}";
        }

        #endregion
	}
}
