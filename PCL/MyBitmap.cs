using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI.Media;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace PCL;

public class MyBitmap
{
	public static ConcurrentDictionary<string, MyBitmap> BitmapCache = new ConcurrentDictionary<string, MyBitmap>();

	public Bitmap Pic;

	public static implicit operator MyBitmap(Image Image)
	{
		if (Image == null)
		{
			return null;
		}
		return new MyBitmap(Image);
	}

	public static implicit operator Image(MyBitmap Image)
	{
		return (Image)(object)Image?.Pic;
	}

	public static implicit operator MyBitmap(ImageSource Image)
	{
		if (Image == null)
		{
			return null;
		}
		return new MyBitmap(Image);
	}

	public static implicit operator ImageSource(MyBitmap Image)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		if (Image == null)
		{
			return null;
		}
		Bitmap pic = Image.Pic;
		Rectangle val = default(Rectangle);
		val = new(0, 0, ((Image)pic).Width, ((Image)pic).Height);
		BitmapData val2 = pic.LockBits(val, (ImageLockMode)3, (PixelFormat)2498570);
		try
		{
			int num = checked(val.Width * val.Height * 4);
			return (ImageSource)(object)BitmapSource.Create(((Image)pic).Width, ((Image)pic).Height, (double)((Image)pic).HorizontalResolution, (double)((Image)pic).VerticalResolution, PixelFormats.Bgra32, (BitmapPalette)null, val2.Scan0, num, val2.Stride);
		}
		finally
		{
			pic.UnlockBits(val2);
		}
	}

	public static implicit operator MyBitmap(Bitmap Image)
	{
		if (Image == null)
		{
			return null;
		}
		return new MyBitmap(Image);
	}

	public static implicit operator Bitmap(MyBitmap Image)
	{
		return Image?.Pic;
	}

	public static implicit operator MyBitmap(ImageBrush Image)
	{
		if (Image == null)
		{
			return null;
		}
		return new MyBitmap(Image);
	}

	public static implicit operator ImageBrush(MyBitmap Image)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		if (Image == null)
		{
			return null;
		}
		return new ImageBrush((ImageSource)new MyBitmap(Image.Pic));
	}

	public MyBitmap()
	{
	}

	public MyBitmap(string FilePathOrResourceName)
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		try
		{
			FilePathOrResourceName = FilePathOrResourceName.Replace("pack://application:,,,/images/", ModBase.PathImage);
			if (ModBase.StartsWithF(FilePathOrResourceName, ModBase.PathImage))
			{
				if (BitmapCache.ContainsKey(FilePathOrResourceName))
				{
					Pic = BitmapCache[FilePathOrResourceName].Pic;
					return;
				}
				Pic = new MyBitmap((ImageSource)((TypeConverter)new ImageSourceConverter()).ConvertFromString(FilePathOrResourceName));
				BitmapCache.TryAdd(FilePathOrResourceName, (MyBitmap)Pic);
				return;
			}
			FileStream val = new FileStream(FilePathOrResourceName, (FileMode)3);
			try
			{
				if (val.Length > 2 && val.ReadByte() == 82 && val.ReadByte() == 73)
				{
					val.Seek(0L, (SeekOrigin)0);
					MemoryStream val2 = ((Stream)(object)val).FromWebpToPng();
					try
					{
						Pic = new Bitmap((Stream)(object)val2);
						return;
					}
					finally
					{
						((System.IDisposable)val2)?.Dispose();
					}
				}
				Pic = new Bitmap((Stream)(object)val);
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Pic = (Bitmap)Application.Current.TryFindResource((object)FilePathOrResourceName);
			if (Pic == null)
			{
				Pic = new Bitmap(1, 1);
				throw new System.Exception($"加载 MyBitmap 失败（{FilePathOrResourceName}）", ex2);
			}
			ModBase.Log(ex2, $"指定类型有误的 MyBitmap 加载（{FilePathOrResourceName}）", ModBase.LogLevel.Developer);
			ProjectData.ClearProjectError();
		}
	}

	public MyBitmap(ImageSource Image)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		MemoryStream val = new MemoryStream();
		try
		{
			PngBitmapEncoder val2 = new PngBitmapEncoder();
			((System.Collections.Generic.ICollection<BitmapFrame>)((BitmapEncoder)val2).Frames).Add(BitmapFrame.Create((BitmapSource)Image));
			((BitmapEncoder)val2).Save((Stream)(object)val);
			Pic = new Bitmap((Stream)(object)val);
		}
		finally
		{
			((System.IDisposable)val)?.Dispose();
		}
	}

	public MyBitmap(Image Image)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		Pic = (Bitmap)Image;
	}

	public MyBitmap(Bitmap Image)
	{
		Pic = Image;
	}

	public MyBitmap(ImageBrush Image)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		MemoryStream val = new MemoryStream();
		try
		{
			BmpBitmapEncoder val2 = new BmpBitmapEncoder();
			((System.Collections.Generic.ICollection<BitmapFrame>)((BitmapEncoder)val2).Frames).Add(BitmapFrame.Create((BitmapSource)Image.ImageSource));
			((BitmapEncoder)val2).Save((Stream)(object)val);
			Pic = new Bitmap((Stream)(object)val);
		}
		finally
		{
			((System.IDisposable)val)?.Dispose();
		}
	}

	public MyBitmap Clip(int X, int Y, int Width, int Height)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		Bitmap val = new Bitmap(Width, Height, ((Image)Pic).PixelFormat);
		val.SetResolution(((Image)Pic).HorizontalResolution, ((Image)Pic).VerticalResolution);
		Graphics val2 = Graphics.FromImage((Image)(object)val);
		checked
		{
			try
			{
				val2.InterpolationMode = (InterpolationMode)5;
				val2.TranslateTransform((float)(-X), (float)(-Y));
				val2.DrawImage((Image)(object)Pic, new Rectangle(0, 0, ((Image)Pic).Width, ((Image)Pic).Height));
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
			return val;
		}
	}

	public MyBitmap RotateFlip(RotateFlipType Type)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		Bitmap val = new Bitmap((Image)(object)Pic);
		val.SetResolution(((Image)Pic).HorizontalResolution, ((Image)Pic).VerticalResolution);
		((Image)val).RotateFlip(Type);
		return (MyBitmap)val;
	}

	public void Save(string FilePath)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		BitmapEncoder val = (BitmapEncoder)new PngBitmapEncoder();
		((System.Collections.Generic.ICollection<BitmapFrame>)val.Frames).Add(BitmapFrame.Create((BitmapSource)(ImageSource)this));
		FileStream val2 = new FileStream(FilePath, (FileMode)2);
		try
		{
			val.Save((Stream)(object)val2);
		}
		finally
		{
			((System.IDisposable)val2)?.Dispose();
		}
	}
}
