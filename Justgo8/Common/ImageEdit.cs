using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Common
{
	/// <summary>
	/// 图片编辑类，需实例化
	/// </summary>
	public class ImageEdit
	{
		/// <summary>
		/// 实例化图片编辑类
		/// </summary>
		public ImageEdit()
		{
		}

		/// <summary>
		/// 根据标准尺寸得到某尺寸图片的缩略图的新尺寸的整型一维数组
		/// </summary>
		/// <param name="Width">预处理图片的宽</param>
		/// <param name="Height">预处理图片的高</param>
		/// <param name="StandardWidth">标准尺寸的宽</param>
		/// <param name="StandardHeight">标准尺寸的高</param>
		/// <returns>缩略图的宽高组成的整型一维数组</returns>
		public int[] ArrWidthHeight(int Width,int Height,int StandardWidth,int StandardHeight)
		{
			int[] Arr=new int[2];
			int newWidth=StandardWidth;
			int newHeight=StandardHeight;

			if(Width<=StandardWidth && Height<=StandardHeight)//保持原尺寸
			{
				Arr[0]=Width;
				Arr[1]=Height;
				return Arr;
			}

			Double iStandard=Convert.ToDouble(StandardWidth)/Convert.ToDouble(StandardHeight);//标准图片的扁率
			Double i=Convert.ToDouble(Width)/Convert.ToDouble(Height);//预处理图片的扁率
			
			if(iStandard>=i)//以高为准缩小
			{
				newWidth=Convert.ToInt32(StandardHeight*i);
				newHeight=StandardHeight;
			}
			else//以宽为准缩小
			{
				newWidth=StandardWidth;
				newHeight=Convert.ToInt32(StandardWidth/i);
			}

			Arr[0]=newWidth;
			Arr[1]=newHeight;
			return Arr;
		}

		/// <summary>
		/// 将指定路径的图片根据标准尺寸进行缩小后得到新尺寸整型一维数组
		/// </summary>
		/// <param name="strImagePath">图片的物理路径，不存在时返回null</param>
		/// <param name="Width">标准尺寸的宽</param>
		/// <param name="Height">标准尺寸的高</param>
		/// <returns>缩小后得到的整型一维数组</returns>
		public int[] ArrImageSize(string strImagePath,int Width,int Height)
		{
			int _Width=0;
			int _Height=0;			
			try
			{
				if(File.Exists(strImagePath)==false)
					return null;
				System.Drawing.Image img=System.Drawing.Image.FromFile(strImagePath);
				_Width=img.Width;
				_Height=img.Height;
				img.Dispose();
			}
			catch
			{
				return null;
			}
			return ArrWidthHeight(_Width,_Height,Width,Height);
		}

		/// <summary>
		/// 将指定地址的图片保存为指定大小的缩略图，并保存到指定地址
		/// </summary>
		/// <param name="OriginalImagePath">要缩小的图片的物理地址</param>
		/// <param name="ThumbnailImageSavePath">保存缩略图的物理地址</param>
		/// <param name="ThumbnailImageWidth">缩略图的宽</param>
		/// <param name="ThumbnailImageHeight">缩略图的高</param>
		/// <returns></returns>
		public bool GetThumbnail(string OriginalImagePath,string ThumbnailImageSavePath,int ThumbnailImageWidth,int ThumbnailImageHeight)
		{
			System.Drawing.Image image=null;
			try
			{
				image = System.Drawing.Image.FromFile(OriginalImagePath) as System.Drawing.Bitmap;
				int imageWidth=image.Width;
				int imageHeight=image.Height;

				//不处理比自己尺寸还小的图片
				if(imageWidth<=ThumbnailImageWidth && imageHeight<=ThumbnailImageHeight)
				{
					if(image!=null)
						image.Dispose();
					return true;
				}

				System.Drawing.SizeF size = new System.Drawing.SizeF(imageWidth, imageHeight);
				int[] iSize=ArrWidthHeight(imageWidth,imageHeight,ThumbnailImageWidth,ThumbnailImageHeight);

				System.Drawing.Image bitmap = new System.Drawing.Bitmap(iSize[0], iSize[1]);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				g.Clear(Color.Transparent);
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				g.DrawImage(image, rect, new System.Drawing.Rectangle(0, 0, imageWidth, imageHeight), System.Drawing.GraphicsUnit.Pixel);
				ImageCodecInfo myImageCodecInfo=null;
				Encoder myEncoder;
				EncoderParameter myEncoderParameter;
				EncoderParameters myEncoderParameters;

				if(image!=null)
					image.Dispose();
			
				foreach(ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())//确定压缩压图片的格式
				{
					if(codec.MimeType=="image/jpeg")
						myImageCodecInfo=codec;
				}

				myEncoder = Encoder.Quality;
				myEncoderParameters = new EncoderParameters(1);
				myEncoderParameter = new EncoderParameter(myEncoder, 100L); // 0-100
				myEncoderParameters.Param[0] = myEncoderParameter;
				
				bitmap.Save(ThumbnailImageSavePath, myImageCodecInfo, myEncoderParameters);
				myEncoderParameter.Dispose();
				myEncoderParameters.Dispose();
				bitmap.Dispose();
				g.Dispose();
			}
			catch
			{
				return false;
			}
			finally
			{
				if(image!=null)
					image.Dispose();
			}
			return true;
		}

		/// <summary>
		/// 将传来的图片形成缩略图后返回
		/// </summary>
		/// <param name="pic">要缩小的图片对象</param>
		/// <param name="ThumbnailImageWidth">缩略图的宽</param>
		/// <param name="ThumbnailImageHeight">缩略图的高</param>
		/// <returns></returns>
		public Image GetThumbnail(Image pic,int ThumbnailImageWidth,int ThumbnailImageHeight)
		{
			int[] iSize=ArrWidthHeight(pic.Width,pic.Height,ThumbnailImageWidth,ThumbnailImageHeight);
			return pic.GetThumbnailImage(iSize[0],iSize[1],null,new System.IntPtr());
		}

		/// <summary>
		/// 将图片对象形成Byte[]数组返回，以便通过Response.BinaryWrite(Byte[])输出到aspx
		/// </summary>
		/// <param name="ImagePath">图片物理地址</param>
		/// <returns>返回Byte[]数组</returns>
		public Byte[] GetImageByte(string ImagePath)
		{
			byte[] buffer=null;
			if(System.IO.File.Exists(ImagePath)==false)
			{
				//没有找到文件时
			}
			else
			{
				FileStream fs=new FileStream(ImagePath,FileMode.Open,FileAccess.Read);
				System.IO.BinaryReader mbr=new BinaryReader(fs);   
				buffer= new byte[fs.Length];
				mbr.Read(buffer,0,(int)(fs.Length));
				fs.Close();
			}
			return buffer;
		}
	}
}
