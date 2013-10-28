using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

/// <summary>
///CorrectCoordinate 的摘要说明
/// </summary>
public class CoordinateCorrection
{
    private static ArrayList array;
    public CoordinateCorrection()
    {
    }

    /// <summary>
    /// GPS坐标校正
    /// </summary>
    /// <param name="latlng">需要校正的坐标</param>
    /// <returns></returns>
    public static Coordinate GetCorrectCoordinate(Coordinate latlng)
    {
        return WGS2Mars(latlng.Lat, latlng.Lng);
    }

    #region GPS坐标校正 改编自c语言

    public class MapCoord
    {
        public int lng { set; get; }    //12151表示121.51  
        public int lat { set; get; }    //3130表示31.30  
        public int x_off { set; get; }  //地图x轴偏移像素值  
        public int y_off { set; get; }  //地图y轴偏移像素值  
    }

    /// <summary>  
    /// 自定义比较类  
    /// </summary>  
    public class myReverserClass : IComparer
    {
        public int Compare(object x, object y)
        {
            MapCoord data1 = (MapCoord)x, data2 = (MapCoord)y;
            int det_lng = data1.lng - data2.lng;
            if (det_lng != 0)
                return det_lng;
            else
                return data1.lat - data2.lat;
        }
    }

    //这就需要一个把经纬度转换成地图xy轴坐标的算法：  

    private static double lngToPixel(double lng, int zoom)
    {
        return (lng + 180) * (256L << zoom) / 360;
    }

    private static double latToPixel(double lat, int zoom)
    {
        double siny = Math.Sin(lat * Math.PI / 180);
        double y = Math.Log((1 + siny) / (1 - siny));
        return (128 << zoom) * (1 - y / (2 * Math.PI));
    }


    //xy轴坐标加上对应的地图xy轴的偏移量，最后还要反过来将最终正确的地图xy轴坐标转换成正确的经纬度  
    private static double pixelToLng(double pixelX, int zoom)
    {
        return pixelX * 360 / (256L << zoom) - 180;
    }

    private static double pixelToLat(double pixelY, int zoom)
    {
        double y = 2 * Math.PI * (1 - pixelY / (128 << zoom));
        double z = Math.Pow(Math.E, y);
        double siny = (z - 1) / (z + 1);
        return Math.Asin(siny) * 180 / Math.PI;
    }

    /// <summary>  
    /// 将字节转化为具体的数据对象  
    /// </summary>  
    /// <param name="buf"></param>  
    /// <returns></returns>  
    private static MapCoord getMapCoordFromBytes(byte[] buf)
    {
        //数据文档结构是八字节为一个坐标及其偏移量,分别为经度,纬度,x偏移量,y偏移量; 每两字节为一个数据  
        MapCoord coord = new MapCoord();
        byte[] b1 = new byte[2], b2 = new byte[2], b3 = new byte[2], b4 = new byte[2];
        Array.Copy(buf, 0, b1, 0, 2);
        Array.Copy(buf, 2, b2, 0, 2);
        Array.Copy(buf, 4, b3, 0, 2);
        Array.Copy(buf, 6, b4, 0, 2);
        coord.lng = System.BitConverter.ToInt16(b1, 0);
        coord.lat = System.BitConverter.ToInt16(b2, 0);
        coord.x_off = System.BitConverter.ToInt16(b3, 0);
        coord.y_off = System.BitConverter.ToInt16(b4, 0);
        return coord;
    }

    /// <summary>  
    /// WGS84(GPS)坐标转火星坐标  
    /// </summary>  
    /// <param name="lat">纬度</param>  
    /// <param name="lng">经度</param>  
    public static Coordinate WGS2Mars(double lat, double lng)
    {
        //读取数据文件  
        //这里读取文件的地方可以单独提出来, 读一次之后保存到内存里, 读取时比较耗时间. 或者放到数据库中去. 
        if (array == null)
        {
            array = new ArrayList();
            string file = System.Web.HttpContext.Current.Server.MapPath("~/files/offset.dat");
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int size = (int)fs.Length / 8;
            for (int i = 0; i < size; i++)
            {
                //按八个字节八个字节来读取, 放在MapCoord对象中,并添加到ArrayList中  
                byte[] source = br.ReadBytes(8);
                array.Add(getMapCoordFromBytes(source));
            }
        }

        //br.Close();
        //fs.Close();  
        //将要查找的坐标放置在MapCoord对象中  
        try
        {
            MapCoord search = new MapCoord();
            search.lat = (int)(lat * 100);
            search.lng = (int)(lng * 100);

            myReverserClass rc = new myReverserClass();
            //执行查找, 查询结果将返回array中的索引值  
            int x = array.BinarySearch(0, array.Count, search, rc);
            //取得查找到的结果并进行计算  
            MapCoord ret = (MapCoord)array[x];
            double pixY = latToPixel(lat, 18);
            double pixX = lngToPixel(lng, 18);

            pixY += ret.y_off;
            pixX += ret.x_off;
            lat = pixelToLat(pixY, 18);
            lng = pixelToLng(pixX, 18);
            Coordinate latlng = new Coordinate(lat, lng);
            return latlng;
        }
        catch
        {
            return new Coordinate(lat - 0.0024, lng + 0.006);
        }
    }

    #endregion

}
public class Coordinate
{
    public double Lat { set; get; }
    public double Lng { set; get; }
    public Coordinate(double lat, double lng)
    {
        this.Lat = lat;
        this.Lng = lng;
    }
    public Coordinate()
    { }
}