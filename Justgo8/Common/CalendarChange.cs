using System;

namespace Common
{
	/// <summary>
	/// 提供1900-2011年的阴阳历互转，需要实例化此类
	/// </summary>
	public class CalendarChange
	{
		/// <summary>
		/// 实例化，提供1900-2011年的阴阳历互转，出错时返回1900-1-1
		/// </summary>
		public CalendarChange()
		{
			
		}

		/// <summary>
		/// 阴阳历互转，出错时返回1900-1-1
		/// </summary>
		/// <param name="vDate">转换日期</param>
		/// <param name="ChgType">转换方式： 0 阳历转阴历 , 1 阴历转阳历</param>
		/// <returns>阳阴历互转，出错时返回1900-1-1</returns>
		public DateTime GetChgDate(DateTime vDate,int ChgType)
		{
			//ChgType=0 阳历转阴历 ChgType=1 阴历转阳历
			//日期数据定义方法如下
			//前12个字节代表1-12月为大月或是小月，1为大月30天，0为小月29天；
			//第13位为闰月的情况，1为大月30天，0为小月29天；
			//第14位为闰月的月份，如果不是闰月为0，否则给出月份，10、11、12分别用A、B、C来表示，即使用16进制；
			//最后4位为当年家农历新年-即农历1月1日所在公历的日期，如0131代表1月31日。

			int vvdate = vDate.Year;

			if (vvdate > 2011 || vvdate < 1900 )
			{
				return Convert.ToDateTime("1900-1-1");
			}
			int AddMonth=0;
			int AddDay=0;
			int AddYear=0;
			//int getDay=0;
			int i=0;
			//bool RunYue=false;
			DateTime conDate=DateTime.Now;

			string[] daList= new string[2012];
			daList[1900] = "010010110110180131";;
			daList[1901] = "010010101110000219";
			daList[1902] = "101001010111000208";
			daList[1903] = "010100100110150129";
			daList[1904] = "110100100110000216";
			daList[1905] = "110110010101000204";
			daList[1906] = "011010101010140125";
			daList[1907] = "010101101010000213";
			daList[1908] = "100110101101000202";
			daList[1909] = "010010101110120122";
			daList[1910] = "010010101110000210";
			daList[1911] = "101001001101160130";
			daList[1912] = "101001001101000218";
			daList[1913] = "110100100101000206";
			daList[1914] = "110101010100150126";
			daList[1915] = "101101010101000214";
			daList[1916] = "010101101010000204";
			daList[1917] = "100101101101020123";
			daList[1918] = "100101011011000211";
			daList[1919] = "010010011011170201";
			daList[1920] = "010010011011000220";
			daList[1921] = "101001001011000208";
			daList[1922] = "101100100101150128";
			daList[1923] = "011010100101000216";
			daList[1924] = "011011010100000205";
			daList[1925] = "101011011010140124";
			daList[1926] = "001010110110000213";
			daList[1927] = "100101010111000202";
			daList[1928] = "010010010111120123";
			daList[1929] = "010010010111000210";
			daList[1930] = "011001001011060130";
			daList[1931] = "110101001010000217";
			daList[1932] = "111010100101000206";
			daList[1933] = "011011010100150126";
			daList[1934] = "010110101101000214";
			daList[1935] = "001010110110000204";
			daList[1936] = "100100110111030124";
			daList[1937] = "100100101110000211";
			daList[1938] = "110010010110170131";
			daList[1939] = "110010010101000219";
			daList[1940] = "110101001010000208";
			daList[1941] = "110110100101060127";
			daList[1942] = "101101010101000215";
			daList[1943] = "010101101010000205";
			daList[1944] = "101010101101140125";
			daList[1945] = "001001011101000213";
			daList[1946] = "100100101101000202";
			daList[1947] = "110010010101120122";
			daList[1948] = "101010010101000210";
			daList[1949] = "101101001010170129";
			daList[1950] = "011011001010000217";
			daList[1951] = "101101010101000206";
			daList[1952] = "010101011010150127";
			daList[1953] = "010011011010000214";
			daList[1954] = "101001011011000203";
			daList[1955] = "010100101011130124";
			daList[1956] = "010100101011000212";
			daList[1957] = "101010010101080131";
			daList[1958] = "111010010101000218";
			daList[1959] = "011010101010000208";
			daList[1960] = "101011010101060128";
			daList[1961] = "101010110101000215";
			daList[1962] = "010010110110000205";
			daList[1963] = "101001010111040125";
			daList[1964] = "101001010111000213";
			daList[1965] = "010100100110000202";
			daList[1966] = "111010010011030121";
			daList[1967] = "110110010101000209";
			daList[1968] = "010110101010170130";
			daList[1969] = "010101101010000217";
			daList[1970] = "100101101101000206";
			daList[1971] = "010010101110150127";
			daList[1972] = "010010101101000215";
			daList[1973] = "101001001101000203";
			daList[1974] = "110100100110140123";
			daList[1975] = "110100100101000211";
			daList[1976] = "110101010010180131";
			daList[1977] = "101101010100000218";
			daList[1978] = "101101101010000207";
			daList[1979] = "100101101101060128";
			daList[1980] = "100101011011000216";
			daList[1981] = "010010011011000205";
			daList[1982] = "101001001011140125";
			daList[1983] = "101001001011000213";
			daList[1984] = "1011001001011A0202";
			daList[1985] = "011010100101000220";
			daList[1986] = "011011010100000209";
			daList[1987] = "101011011010060129";
			daList[1988] = "101010110110000217";
			daList[1989] = "100100110111000206";
			daList[1990] = "010010010111150127";
			daList[1991] = "010010010111000215";
			daList[1992] = "011001001011000204";
			daList[1993] = "011010100101030123";
			daList[1994] = "111010100101000210";
			daList[1995] = "011010110010180131";
			daList[1996] = "010110101100000219";
			daList[1997] = "101010110110000207";
			daList[1998] = "100100110110150128";
			daList[1999] = "100100101110000216";
			daList[2000] = "110010010110000205";
			daList[2001] = "110101001010140124";
			daList[2002] = "110101001010000212";
			daList[2003] = "110110100101000201";
			daList[2004] = "010110101010120122";
			daList[2005] = "010101101010000209";
			daList[2006] = "101010101101170129";
			daList[2007] = "001001011101000218";
			daList[2008] = "100100101101000207";
			daList[2009] = "110010010101150126";
			daList[2010] = "101010010101000214";
			daList[2011] = "101101001010100203";

			AddYear =vvdate;

			if(ChgType==1)
			{
				AddMonth=Convert.ToInt16(daList[AddYear].Substring(14,2));
				AddDay = Convert.ToInt16(daList[AddYear].Substring(16, 2));
				conDate = Convert.ToDateTime(AddYear +"-"+ AddMonth + "-"+ AddDay);
				AddDay = vDate.Day;

				for(i=1;i<vDate.Month;i++)
				{
					AddDay = AddDay + 29 + Convert.ToInt16(daList[vvdate].Substring(i-1, 1));
				}
				return conDate.AddDays(AddDay - 1);
			}
			else
			{
                AddMonth = Convert.ToInt16(daList[AddYear].Substring(14, 2));
                AddDay = Convert.ToInt16(daList[AddYear].Substring(16, 2));
                conDate = Convert.ToDateTime(AddYear + "-" + AddMonth + "-" + AddDay);
                AddDay = vDate.Day;

                for (i = 1; i < vDate.Month; i++)
                {
                    AddDay = AddDay + 29 + Convert.ToInt16(daList[vvdate].Substring(i - 1, 1));
                }
                return conDate.AddDays(AddDay - 1);
                //                TimeSpan t;
                //AddMonth = Convert.ToInt16(daList[AddYear].Substring(14,2));
                //AddDay = Convert.ToInt16(daList[AddYear].Substring(16, 2));
                //conDate = Convert.ToDateTime(AddYear +"-"+ AddMonth + "-"+ AddDay);
                //t = vDate - conDate;
                //getDay = t.Days;

                //if(getDay < 0)
                //{
                //    AddYear = AddYear - 1;
                //    AddMonth = Convert.ToInt16(daList[AddYear].Substring(14,2));
                //    AddDay = Convert.ToInt16(daList[AddYear].Substring(16, 2));
                //    conDate = Convert.ToDateTime(AddYear +"-"+ AddMonth + "-"+ AddDay);
                //    t = vDate - conDate;
                //    getDay = t.Days;
                //}
                //AddDay = 1;
                //AddMonth = 1;
                //for(i=0;i<getDay;i++)
                //{
                //    AddDay=AddDay+1;
                //    if(AddDay == (30 + Convert.ToInt32(daList[AddYear].Substring(AddMonth-1,1))) || (RunYue && AddDay==(30 + Convert.ToInt32(daList[AddYear].Substring(12,1)))))
                //    {
                //        if(RunYue==false && AddMonth==Convert.ToInt32(Convert.ToInt32(daList[AddYear].Substring(13,1),16).ToString(),10))
                //        {
                //            RunYue = true;
                //        }
                //        else
                //        {
                //            RunYue = false;
                //            AddMonth = AddMonth + 1;
                //        }
                //        AddDay = 1;
                //    }
                //}
                //return Convert.ToDateTime(AddYear +"-"+ AddMonth + "-"+ AddDay);
			}
		}
	}
}
