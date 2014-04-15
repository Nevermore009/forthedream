using System;
using System.Text;

namespace Common
{
	/// <summary>
	/// 分页样式类，需要实例化
	/// </summary>
	public class SplitPage
	{
		private int iCurrPageIndex;		//当前页号
		private int iPageCount;			//页总数
		private int iPageSize;			//页显示记录数
		private int iTotal;				//记录条数
		private DBStyleType DbStyleType;		//样式
		private string strPageUrl = string.Empty;//翻页URL

		/// <summary>
		/// 实例化分页
		/// </summary>
		/// <param name="_iCurrPageIndex">提交的当前页</param>
		/// <param name="_iPageSize">每页记录条数</param>
		/// <param name="_iTotal">总记录数</param>
		public SplitPage(int _iCurrPageIndex,int _iPageSize,int _iTotal)
		{
			this.iPageCount = GetiPageCount(_iPageSize,_iTotal);//计算总页数
			
			//得出当前页
			if(_iCurrPageIndex>iPageCount)
				_iCurrPageIndex=iPageCount;
			if(_iCurrPageIndex<=0)
				_iCurrPageIndex=1;
			this.iCurrPageIndex = _iCurrPageIndex;

			this.iPageSize = _iPageSize;
			this.iTotal = _iTotal;
		}

		/// <summary>
		/// 获得当前页
		/// </summary>
		/// <returns>获得当前页</returns>
		public int GetCurrPageIndex()
		{
			return iCurrPageIndex;
		}

		/// <summary>
		/// 获得总页数
		/// </summary>
		/// <returns>获得总页数</returns>
		public int GetPageCount()
		{
			return iPageCount;
		}

		/// <summary>
		/// 分页时显示页码的字符串
		/// </summary>
		/// <param name="_strPageUrl">翻页URL 格式：XXX.aspx?a=b&c=d&pg=*&k=m 其中*表示跳到的页码数</param>
		/// <param name="_iStyleType">样式</param>
		/// <returns>分页时显示页码</returns>
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
		/// 对样式的枚举
		/// </summary>
		public enum DBStyleType
		{
			/// <summary>
			/// 样式一： 共有1000条记录 目前是第1/30页 上一页 1 2 3 4 5 下一页
			/// </summary>
			style1,
			/// <summary>
			/// 样式二： 共有1000条记录 目前是第1/30页 《〈 1 2 3 4 5 〉 》 跳至第口页，生成代码不得放入form内
			/// </summary>
			style2,
			/// <summary>
			/// 样式三： 共有1000条记录 目前是第1/30页 上一页 下一页
			/// </summary>
			style3,
			/// <summary>
			/// 样式四： 共有1000条记录 目前是第1/30页 首页 上一页 下一页 尾页
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
		/// 分页样式一
		/// </summary>
		/// <returns>分页样式一</returns>
		private string GetPageControl()
		{
			StringBuilder builder = new StringBuilder("");
			string text = "color:Maroon;font-family:\"Century Gothic\";font-size:12px";
			string text2 = "color:#000000;font-family:\"Century Gothic\";font-size:12px";
			string text3 = "font-size:12px;font-family:\"Century Gothic\";color:Black;";
			builder.Append(string.Concat(new object[] { "<font style=font-size:12px>共有&nbsp;<font class=", text, ">", this.iTotal, "</font>&nbsp;条信息&nbsp;当前页<font class=", text, ">", this.iCurrPageIndex.ToString(), "</font>/<font class=", text2, ">", this.iPageCount.ToString(), "</font>&nbsp;</font>" }));
			if (this.iCurrPageIndex == 1)
			{
				builder.Append("上一页");
			}
			if (this.iCurrPageIndex > 1)
			{
				string[] textArray = new string[] { "<a class='pg' href=\"", this.strPageUrl.Replace(Convert.ToString(-7654987), (this.iCurrPageIndex - 2).ToString()), "\">上一页</a>&nbsp;" };
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
					builder.Append("下一页");
				}
				else
				{
					string[] textArray4 = new string[] { "<a class='pg' href=\"", this.strPageUrl.Replace(Convert.ToString(-7654987), this.iCurrPageIndex.ToString()), "\">下一页</a>" };
					builder.Append(string.Concat(textArray4));
				}
			}
			else
			{
				builder.Append("下一页");
			}
			return builder.ToString();
		}

		/// <summary>
		/// 分页样式二
		/// </summary>
		/// <returns>分页样式二</returns>
		private string GetPageControl2()
		{
			string _color="#CCCCCC"; //被禁用文字的颜色
			int iMax=6;				 //显示数字的个数+1，必须是双数
			StringBuilder builder = new StringBuilder("");

			builder.Append("共有"+ iTotal +"条记录 目前是第"+ iCurrPageIndex +"/"+ iPageCount +"页 ");


			if(iCurrPageIndex-10>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-10)) +"' title='上十页'>&lt;&lt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&lt;&lt;</font> ");
			}

			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='上一页'>&lt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&lt;</font> ");
			}
			
			//-中间的数字链接----
			int i1=iCurrPageIndex-iMax/2;   //最小的数字
			int i2=iCurrPageIndex+iMax/2; //最大的数字
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
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='下一页'>&gt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&gt;</font> ");
			}

			if(iPageCount-iCurrPageIndex>10)
			{
				builder.Append("<a  class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+10)) +"' title='下十页'>&gt;&gt;</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">&gt;&gt;</font> ");
			}

			builder.Append("跳至第<input style=width:20px type='textbox' name='goCurrPage' onchange=\"window.location.href='"+ strPageUrl.Replace("*","'+this.value+'") +"'\">页<input type=button style=width:20px; value=GO>");

			return builder.ToString();
		}

		/// <summary>
		/// 分页样式三
		/// </summary>
		/// <returns>分页样式三</returns>
		private string GetPageControl3()
		{
			string _color="#CCCCCC"; //被禁用文字的颜色
			StringBuilder builder = new StringBuilder("");

			builder.Append("共有"+ iTotal +"条记录 目前是第"+ iCurrPageIndex +"/"+ iPageCount +"页 ");


			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='上一页'>上一页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">上一页</font> ");
			}

			if(iPageCount-iCurrPageIndex>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='下一页'>下一页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">下一页</font> ");
			}

			return builder.ToString();
		}

		/// <summary>
		/// 分页样式四
		/// </summary>
		/// <returns>分页样式四</returns>
		private string GetPageControl4()
		{
			string _color="#CCCCCC"; //被禁用文字的颜色
			StringBuilder builder = new StringBuilder("");

			builder.Append("共有"+ iTotal +"条记录 目前是第"+ iCurrPageIndex +"/"+ iPageCount +"页 ");

			if(iCurrPageIndex!=1)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*","1") +"' title='首页'>首页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">首页</font> ");
			}

			if(iCurrPageIndex-1>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex-1)) +"' title='上一页'>上一页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">上一页</font> ");
			}

			if(iPageCount-iCurrPageIndex>0)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",Convert.ToString(iCurrPageIndex+1)) +"' title='下一页'>下一页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">下一页</font> ");
			}

			if(iCurrPageIndex!=iPageCount && iPageCount>1)
			{
				builder.Append("<a class='pg' href='"+ strPageUrl.Replace("*",iPageCount.ToString()) +"' title='尾页'>尾页</a> ");
			}
			else
			{
				builder.Append("<font color=" + _color + ">尾页</font> ");
			}

			return builder.ToString();
		}
	}
}
