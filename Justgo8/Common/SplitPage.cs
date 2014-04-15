using System;
using System.Text;

namespace Common
{
	/// <summary>
	/// ��ҳ��ʽ�࣬��Ҫʵ����
	/// </summary>
	public class SplitPage
	{
		private int iCurrPageIndex;		//��ǰҳ��
		private int iPageCount;			//ҳ����
		private int iPageSize;			//ҳ��ʾ��¼��
		private int iTotal;				//��¼����
		private DBStyleType DbStyleType;		//��ʽ
		private string strPageUrl = string.Empty;//��ҳURL

		/// <summary>
		/// ʵ������ҳ
		/// </summary>
		/// <param name="_iCurrPageIndex">�ύ�ĵ�ǰҳ</param>
		/// <param name="_iPageSize">ÿҳ��¼����</param>
		/// <param name="_iTotal">�ܼ�¼��</param>
		public SplitPage(int _iCurrPageIndex,int _iPageSize,int _iTotal)
		{
			this.iPageCount = GetiPageCount(_iPageSize,_iTotal);//������ҳ��
			
			//�ó���ǰҳ
			if(_iCurrPageIndex>iPageCount)
				_iCurrPageIndex=iPageCount;
			if(_iCurrPageIndex<=0)
				_iCurrPageIndex=1;
			this.iCurrPageIndex = _iCurrPageIndex;

			this.iPageSize = _iPageSize;
			this.iTotal = _iTotal;
		}

		/// <summary>
		/// ��õ�ǰҳ
		/// </summary>
		/// <returns>��õ�ǰҳ</returns>
		public int GetCurrPageIndex()
		{
			return iCurrPageIndex;
		}

		/// <summary>
		/// �����ҳ��
		/// </summary>
		/// <returns>�����ҳ��</returns>
		public int GetPageCount()
		{
			return iPageCount;
		}

		/// <summary>
		/// ��ҳʱ��ʾҳ����ַ���
		/// </summary>
		/// <param name="_strPageUrl">��ҳURL ��ʽ��XXX.aspx?a=b&c=d&pg=*&k=m ����*��ʾ������ҳ����</param>
		/// <param name="_iStyleType">��ʽ</param>
		/// <returns>��ҳʱ��ʾҳ��</returns>
		public string strPage(string _strPageUrl,DBStyleType _DBStyleType)
		{
			this.strPageUrl = _strPageUrl;
			this.DbStyleType = _DBStyleType;
			if (DbStyleType==DBStyleType.style1)
			{
				return GetPageControl();
			}
			else if(DbStyleType==DBStyleType.style2)
			{
				 return GetPageControl2();
			}
			else if(DbStyleType==DBStyleType.style3)
			{
				 return GetPageControl3();
			}
			else if(DbStyleType==DBStyleType.style4)
			{
				 return GetPageControl4();
			}
			return "";
		}

		/// <summary>
		/// ����ʽ��ö��
		/// </summary>
		public enum DBStyleType
		{
			/// <summary>
			/// ��ʽһ�� ����1000����¼ Ŀǰ�ǵ�1/30ҳ ��һҳ 1 2 3 4 5 ��һҳ
			/// </summary>
			style1,
			/// <summary>
			/// ��ʽ���� ����1000����¼ Ŀǰ�ǵ�1/30ҳ ���� 1 2 3 4 5 �� �� �����ڿ�ҳ�����ɴ��벻�÷���form��
			/// </summary>
			style2,
			/// <summary>
			/// ��ʽ���� ����1000����¼ Ŀǰ�ǵ�1/30ҳ ��һҳ ��һҳ
			/// </summary>
			style3,
			/// <summary>
			/// ��ʽ�ģ� ����1000����¼ Ŀǰ�ǵ�1/30ҳ ��ҳ ��һҳ ��һҳ βҳ
			/// </summary>
			style4,
			}

		private int GetiPageCount(int _iPageSize, int _iTotal)
		{
			if ((_iTotal % _iPageSize) > 0)
			{
				return ((_iTotal / _iPageSize) + 1);
			}
			return (_iTotal / _iPageSize);
		}

		/// <summary>
		/// ��ҳ��ʽһ
		/// </summary>
		/// <returns>��ҳ��ʽһ</returns>
		private string GetPageControl()
		{
			StringBuilder builder = new StringBuilder("");
			string text = "color:Maroon;font-family:\"Century Gothic\";font-size:12px";
			string text2 = "color:#000000;font-family:\"Century Gothic\";font-size:12px";
			string text3 = "font-size:12px;font-family:\"Century Gothic\";color:Black;";
			builder.Append(string.Concat(new object[] { "<font style=font-size:12px>����&nbsp;<font class=", text, ">", this.iTotal, "</font>&nbsp;����Ϣ&nbsp;��ǰҳ<font class=", text, ">", this.iCurrPageIndex.ToString(), "</font>/<font class=", text2, ">", this.iPageCount.ToString(), "</font>&nbsp;</font>" }));
			if (this.iCurrPageIndex == 1)
			{
				builder.Append("��һҳ");
			}
			if (this.iCurrPageIndex > 1)
			{
				string[] textArray = new string[] { "<a class='pg' href=\"", this.strPageUrl.Replace(Convert.ToString(-7654987), (this.iCurrPageIndex - 2).ToString()), "\">��һҳ</a>&nbsp;" };
				builder.Append(string.Concat(textArray));
			}
			for (int i = this.iCurrPageIndex - 5; i <= (this.iCurrPageIndex + 5); i++)
			{
				if ((i > 0) && (i <= this.iPageCount))
				{
					if (i == this.iCurrPageIndex)
					{
						builder.Append("<font Class=" + text3 + ">" + i.ToString() + "</font>&nbsp;");
					}
					else
					{
						string[] textArray3 = new string[] { "<a class='pg' href=\"", this.strPageUrl.Replace(Convert.ToString(-7654987), (i - 1).ToString()), "\"><font class=FYLine>", i.ToString(), "</font></a>&nbsp;" };
						builder.Append(string.Concat(textArray3));
					}
				}
			}
			if (this.iPageCount > 1)
			{
				if (this.iPageCount == this.iCurrPageIndex)
				{
					builder.Append("��һҳ");
				}
				else
				{
					string[] textArray4 = new string[] { "<a class='pg' href=\"", this.strPageUrl.Replace(Convert.ToString(-7654987), this.iCurrPageIndex.ToString()), "\">��һҳ</a>" };
					builder.Append(string.Concat(textArray4));
				}
			}
			else
			{
				builder.Append("��һҳ");
			}
			return builder.ToString();
		}

		/// <summary>
		/// ��ҳ��ʽ��
		/// </summary>
		/// <returns>��ҳ��ʽ��</returns>
		private string GetPageControl2()
		{
			string _color="#CCCCCC"; //���������ֵ���ɫ
			int iMax=6;				 //��ʾ���ֵĸ���+1��������˫��
			StringBuilder builder = new StringBuilder("");

			builder.Append("����"+ iTotal +"����¼ Ŀǰ�ǵ�"+ iCurrPageIndex +"/"+ iPageCount +"ҳ ");


			if(iCurrPageIndex-10>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-10)) +"' title='��ʮҳ'>&lt;&lt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&lt;&lt;</font> ");
			}

			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='��һҳ'>&lt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&lt;</font> ");
			}
			
			//-�м����������----
			int i1=iCurrPageIndex-iMax/2;   //��С������
			int i2=iCurrPageIndex+iMax/2; //��������
			if (i1<2)
				i1=1;
			if(i2>iPageCount)
				i2=iPageCount;
			if(i2<=iMax+1 && iPageCount>iMax/2+1)
			{
				i2=iPageCount;
				if (iPageCount>iMax+1)
					i2=iMax+1;
			}
			if(i1>iPageCount-iMax && iPageCount>iMax/2)
			{
				i1=iPageCount-iMax;
				if (i1<2)
					i1=1;
			}

			for(int i=i1;i<=i2;i++)
			{
				if(i==iCurrPageIndex)
				{
					builder.Append("<font color=red><b>" + i + "</b></font> ");
				}
				else
				{
					builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",i.ToString()) +"'>" + i + "</a> ");
				}
			}
			//----------

			if(iPageCount-iCurrPageIndex>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='��һҳ'>&gt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&gt;</font> ");
			}

			if(iPageCount-iCurrPageIndex>10)
			{
				builder.Append("<a  class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+10)) +"' title='��ʮҳ'>&gt;&gt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&gt;&gt;</font> ");
			}

			builder.Append("������<input style=width:20px type='textbox' name='goCurrPage' onchange=\"window.location.href='"+ strPageUrl.Replace("*","'+this.value+'") +"'\">ҳ<input type=button style=width:20px; value=GO>");

			return builder.ToString();
		}

		/// <summary>
		/// ��ҳ��ʽ��
		/// </summary>
		/// <returns>��ҳ��ʽ��</returns>
		private string GetPageControl3()
		{
			string _color="#CCCCCC"; //���������ֵ���ɫ
			StringBuilder builder = new StringBuilder("");

			builder.Append("����"+ iTotal +"����¼ Ŀǰ�ǵ�"+ iCurrPageIndex +"/"+ iPageCount +"ҳ ");


			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='��һҳ'>��һҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">��һҳ</font> ");
			}

			if(iPageCount-iCurrPageIndex>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='��һҳ'>��һҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">��һҳ</font> ");
			}

			return builder.ToString();
		}

		/// <summary>
		/// ��ҳ��ʽ��
		/// </summary>
		/// <returns>��ҳ��ʽ��</returns>
		private string GetPageControl4()
		{
			string _color="#CCCCCC"; //���������ֵ���ɫ
			StringBuilder builder = new StringBuilder("");

			builder.Append("����"+ iTotal +"����¼ Ŀǰ�ǵ�"+ iCurrPageIndex +"/"+ iPageCount +"ҳ ");

			if(iCurrPageIndex!=1)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*","1") +"' title='��ҳ'>��ҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">��ҳ</font> ");
			}

			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='��һҳ'>��һҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">��һҳ</font> ");
			}

			if(iPageCount-iCurrPageIndex>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='��һҳ'>��һҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">��һҳ</font> ");
			}

			if(iCurrPageIndex!=iPageCount && iPageCount>1)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",iPageCount.ToString()) +"' title='βҳ'>βҳ</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">βҳ</font> ");
			}

			return builder.ToString();
		}
	}
}
