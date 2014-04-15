using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Common
{
	/// <summary>
	/// ͼƬ�༭�࣬��ʵ����
	/// </summary>
	public class ImageEdit
	{
		/// <summary>
		/// ʵ����ͼƬ�༭��
		/// </summary>
		public ImageEdit()
		{
		}

		/// <summary>
		/// ���ݱ�׼�ߴ�õ�ĳ�ߴ�ͼƬ������ͼ���³ߴ������һά����
		/// </summary>
		/// <param name="Width">Ԥ����ͼƬ�Ŀ�</param>
		/// <param name="Height">Ԥ����ͼƬ�ĸ�</param>
		/// <param name="StandardWidth">��׼�ߴ�Ŀ�</param>
		/// <param name="StandardHeight">��׼�ߴ�ĸ�</param>
		/// <returns>����ͼ�Ŀ����ɵ�����һά����</returns>
		public int[] ArrWidthHeight(int Width,int Height,int StandardWidth,int StandardHeight)
		{
			int[] Arr=new int[2];
			int newWidth=StandardWidth;
			int newHeight=StandardHeight;

			if(Width<=StandardWidth && Height<=StandardHeight)//����ԭ�ߴ�
			{
				Arr[0]=Width;
				Arr[1]=Height;
				return Arr;
			}

			Double iStandard=Convert.ToDouble(StandardWidth)/Convert.ToDouble(StandardHeight);//��׼ͼƬ�ı���
			Double i=Convert.ToDouble(Width)/Convert.ToDouble(Height);//Ԥ����ͼƬ�ı���
			
			if(iStandard>=i)//�Ը�Ϊ׼��С
			{
				newWidth=Convert.ToInt32(StandardHeight*i);
				newHeight=StandardHeight;
			}
			else//�Կ�Ϊ׼��С
			{
				newWidth=StandardWidth;
				newHeight=Convert.ToInt32(StandardWidth/i);
			}

			Arr[0]=newWidth;
			Arr[1]=newHeight;
			return Arr;
		}

		/// <summary>
		/// ��ָ��·����ͼƬ���ݱ�׼�ߴ������С��õ��³ߴ�����һά����
		/// </summary>
		/// <param name="strImagePath">ͼƬ������·����������ʱ����null</param>
		/// <param name="Width">��׼�ߴ�Ŀ�</param>
		/// <param name="Height">��׼�ߴ�ĸ�</param>
		/// <returns>��С��õ�������һά����</returns>
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
		/// ��ָ����ַ��ͼƬ����Ϊָ����С������ͼ�������浽ָ����ַ
		/// </summary>
		/// <param name="OriginalImagePath">Ҫ��С��ͼƬ�������ַ</param>
		/// <param name="ThumbnailImageSavePath">��������ͼ�������ַ</param>
		/// <param name="ThumbnailImageWidth">����ͼ�Ŀ�</param>
		/// <param name="ThumbnailImageHeight">����ͼ�ĸ�</param>
		/// <returns></returns>
		public bool GetThumbnail(string OriginalImagePath,string ThumbnailImageSavePath,int ThumbnailImageWidth,int ThumbnailImageHeight)
		{
			System.Drawing.Image image=null;
			try
			{
				image = System.Drawing.Image.FromFile(OriginalImagePath) as System.Drawing.Bitmap;
				int imageWidth=image.Width;
				int imageHeight=image.Height;

				//��������Լ��ߴ绹С��ͼƬ
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
			
				foreach(ImageCodecInfo codec in ImageCodecInfo.GetImageEncoders())//ȷ��ѹ��ѹͼƬ�ĸ�ʽ
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
		/// ��������ͼƬ�γ�����ͼ�󷵻�
		/// </summary>
		/// <param name="pic">Ҫ��С��ͼƬ����</param>
		/// <param name="ThumbnailImageWidth">����ͼ�Ŀ�</param>
		/// <param name="ThumbnailImageHeight">����ͼ�ĸ�</param>
		/// <returns></returns>
		public Image GetThumbnail(Image pic,int ThumbnailImageWidth,int ThumbnailImageHeight)
		{
			int[] iSize=ArrWidthHeight(pic.Width,pic.Height,ThumbnailImageWidth,ThumbnailImageHeight);
			return pic.GetThumbnailImage(iSize[0],iSize[1],null,new System.IntPtr());
		}

		/// <summary>
		/// ��ͼƬ�����γ�Byte[]���鷵�أ��Ա�ͨ��Response.BinaryWrite(Byte[])�����aspx
		/// </summary>
		/// <param name="ImagePath">ͼƬ�����ַ</param>
		/// <returns>����Byte[]����</returns>
		public Byte[] GetImageByte(string ImagePath)
		{
			byte[] buffer=null;
			if(System.IO.File.Exists(ImagePath)==false)
			{
				//û���ҵ��ļ�ʱ
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
