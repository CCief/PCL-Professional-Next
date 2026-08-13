using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyDropShadow : Decorator
{
	private enum Placement
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight
	}

	public static readonly DependencyProperty ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(MyDropShadow), (PropertyMetadata)new FrameworkPropertyMetadata((object)Color.FromArgb((byte)113, (byte)0, (byte)0, (byte)0), (FrameworkPropertyMetadataOptions)16, new PropertyChangedCallback(ClearBrushes)));

	public static readonly DependencyProperty ShadowRadiusProperty = DependencyProperty.Register("ShadowRadius", typeof(double), typeof(MyDropShadow), (PropertyMetadata)new FrameworkPropertyMetadata((object)5.0, (FrameworkPropertyMetadataOptions)16, new PropertyChangedCallback(ClearBrushes)));

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MyDropShadow), (PropertyMetadata)new FrameworkPropertyMetadata((object)default(CornerRadius), (FrameworkPropertyMetadataOptions)16, new PropertyChangedCallback(ClearBrushes)), new ValidateValueCallback(IsCornerRadiusValid));

	private static Brush[] _commonBrushes;

	private static CornerRadius _commonCornerRadius;

	private static readonly object _resourceAccess = RuntimeHelpers.GetObjectValue(new object());

	private Brush[] _brushes;

	public Color Color
	{
		get
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			object value = base.GetValue(ColorProperty);
			if (value == null)
			{
				return default(Color);
			}
			return (Color)value;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			base.SetValue(ColorProperty, (object)value);
		}
	}

	public double ShadowRadius
	{
		get
		{
			return Conversions.ToDouble(base.GetValue(ShadowRadiusProperty));
		}
		set
		{
			base.SetValue(ShadowRadiusProperty, (object)value);
		}
	}

	public CornerRadius CornerRadius
	{
		get
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			object value = base.GetValue(CornerRadiusProperty);
			if (value == null)
			{
				return default(CornerRadius);
			}
			return (CornerRadius)value;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			base.SetValue(CornerRadiusProperty, (object)value);
		}
	}

	private static bool IsCornerRadiusValid(object value)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		CornerRadius val = ((value != null) ? ((CornerRadius)value) : default(CornerRadius));
		if (!(val.TopLeft < 0.0) && !(val.TopRight < 0.0) && !(val.BottomLeft < 0.0) && !(val.BottomRight < 0.0) && !double.IsNaN(val.TopLeft) && !double.IsNaN(val.TopRight) && !double.IsNaN(val.BottomLeft) && !double.IsNaN(val.BottomRight) && !double.IsInfinity(val.TopLeft) && !double.IsInfinity(val.TopRight) && !double.IsInfinity(val.BottomLeft))
		{
			return !double.IsInfinity(val.BottomRight);
		}
		return false;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Expected O, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected O, but got Unknown
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_0558: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_05a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d0: Expected O, but got Unknown
		//IL_05df: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ef: Expected O, but got Unknown
		//IL_068d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Expected O, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Expected O, but got Unknown
		CornerRadius cornerRadius = CornerRadius;
		Size renderSize = ((UIElement)this).RenderSize;
		double width = renderSize.Width;
		renderSize = ((UIElement)this).RenderSize;
		Rect val = default(Rect);
		val = new(0.0, 0.0, width, renderSize.Height);
		Color color = Color;
		if (!(val.Width > 0.0) || !(val.Height > 0.0) || color.A <= 0)
		{
			return;
		}
		double num = val.Right - val.Left - 2.0 * ShadowRadius;
		double num2 = val.Bottom - val.Top - 2.0 * ShadowRadius;
		double num3 = Math.Min(num * 0.5, num2 * 0.5);
		cornerRadius.TopLeft = Math.Min(cornerRadius.TopLeft, num3);
		cornerRadius.TopRight = Math.Min(cornerRadius.TopRight, num3);
		cornerRadius.BottomLeft = Math.Min(cornerRadius.BottomLeft, num3);
		cornerRadius.BottomRight = Math.Min(cornerRadius.BottomRight, num3);
		Brush[] brushes = GetBrushes(color, cornerRadius);
		double num4 = val.Top + ShadowRadius;
		double num5 = val.Left + ShadowRadius;
		double num6 = val.Right - ShadowRadius;
		double num7 = val.Bottom - ShadowRadius;
		double[] array = new double[6]
		{
			num5,
			num5 + cornerRadius.TopLeft,
			num6 - cornerRadius.TopRight,
			num5 + cornerRadius.BottomLeft,
			num6 - cornerRadius.BottomRight,
			num6
		};
		double[] array2 = new double[6]
		{
			num4,
			num4 + cornerRadius.TopLeft,
			num4 + cornerRadius.TopRight,
			num7 - cornerRadius.BottomLeft,
			num7 - cornerRadius.BottomRight,
			num7
		};
		drawingContext.PushGuidelineSet(new GuidelineSet(array, array2));
		cornerRadius.TopLeft = cornerRadius.TopLeft + ShadowRadius;
		cornerRadius.TopRight = cornerRadius.TopRight + ShadowRadius;
		cornerRadius.BottomLeft = cornerRadius.BottomLeft + ShadowRadius;
		cornerRadius.BottomRight = cornerRadius.BottomRight + ShadowRadius;
		Rect val2 = default(Rect);
		val2 = new(val.Left, val.Top, cornerRadius.TopLeft, cornerRadius.TopLeft);
		drawingContext.DrawRectangle(brushes[0], (Pen)null, val2);
		double num8 = array[2] - array[1];
		if (num8 > 0.0)
		{
			Rect val3 = default(Rect);
			val3 = new(array[1], val.Top, num8, ShadowRadius);
			drawingContext.DrawRectangle(brushes[1], (Pen)null, val3);
		}
		Rect val4 = default(Rect);
		val4 = new(array[2], val.Top, cornerRadius.TopRight, cornerRadius.TopRight);
		drawingContext.DrawRectangle(brushes[2], (Pen)null, val4);
		double num9 = array2[3] - array2[1];
		if (num9 > 0.0)
		{
			Rect val5 = default(Rect);
			val5 = new(val.Left, array2[1], ShadowRadius, num9);
			drawingContext.DrawRectangle(brushes[3], (Pen)null, val5);
		}
		double num10 = array2[4] - array2[2];
		if (num10 > 0.0)
		{
			Rect val6 = default(Rect);
			val6 = new(array[5], array2[2], ShadowRadius, num10);
			drawingContext.DrawRectangle(brushes[5], (Pen)null, val6);
		}
		Rect val7 = default(Rect);
		val7 = new(val.Left, array2[3], cornerRadius.BottomLeft, cornerRadius.BottomLeft);
		drawingContext.DrawRectangle(brushes[6], (Pen)null, val7);
		double num11 = array[4] - array[3];
		if (num11 > 0.0)
		{
			Rect val8 = default(Rect);
			val8 = new(array[3], array2[5], num11, ShadowRadius);
			drawingContext.DrawRectangle(brushes[7], (Pen)null, val8);
		}
		Rect val9 = default(Rect);
		val9 = new(array[4], array2[4], cornerRadius.BottomRight, cornerRadius.BottomRight);
		drawingContext.DrawRectangle(brushes[8], (Pen)null, val9);
		if (cornerRadius.TopLeft == ShadowRadius && cornerRadius.TopLeft == cornerRadius.TopRight && cornerRadius.TopLeft == cornerRadius.BottomLeft && cornerRadius.TopLeft == cornerRadius.BottomRight)
		{
			Rect val10 = default(Rect);
			val10 = new(array[0], array2[0], num, num2);
			drawingContext.DrawRectangle(brushes[4], (Pen)null, val10);
		}
		else
		{
			PathFigure val11 = new PathFigure();
			if (cornerRadius.TopLeft > ShadowRadius)
			{
				val11.StartPoint = new Point(array[1], array2[0]);
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[1], array2[1]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[0], array2[1]), true));
			}
			else
			{
				val11.StartPoint = new Point(array[0], array2[0]);
			}
			if (cornerRadius.BottomLeft > ShadowRadius)
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[0], array2[3]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[3], array2[3]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[3], array2[5]), true));
			}
			else
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[0], array2[5]), true));
			}
			if (cornerRadius.BottomRight > ShadowRadius)
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[4], array2[5]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[4], array2[4]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[5], array2[4]), true));
			}
			else
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[5], array2[5]), true));
			}
			if (cornerRadius.TopRight > ShadowRadius)
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[5], array2[2]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[2], array2[2]), true));
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[2], array2[0]), true));
			}
			else
			{
				val11.Segments.Add((PathSegment)new LineSegment(new Point(array[5], array2[0]), true));
			}
			val11.IsClosed = true;
			((Freezable)val11).Freeze();
			PathGeometry val12 = new PathGeometry();
			val12.Figures.Add(val11);
			((Freezable)val12).Freeze();
			drawingContext.DrawGeometry(brushes[4], (Pen)null, (Geometry)(object)val12);
		}
		drawingContext.Pop();
	}

	private static void ClearBrushes(DependencyObject o, DependencyPropertyChangedEventArgs e)
	{
		((MyDropShadow)(object)o)._brushes = null;
	}

	private GradientStopCollection CreateStops(Color c, double cornerRadius)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		double num = 1.0 / (ShadowRadius + cornerRadius);
		GradientStopCollection val = new GradientStopCollection();
		Color val2 = c;
		val.Add(new GradientStop(val2, (ShadowRadius * 0.1 + cornerRadius) * num));
		checked
		{
			val2.A = (byte)Math.Round(0.74336 * (double)unchecked((int)c.A));
			val.Add(new GradientStop(val2, (ShadowRadius * 0.3 + cornerRadius) * num));
			val2.A = (byte)Math.Round(0.38053 * (double)unchecked((int)c.A));
			val.Add(new GradientStop(val2, (ShadowRadius * 0.5 + cornerRadius) * num));
			val2.A = (byte)Math.Round(0.12389 * (double)unchecked((int)c.A));
			val.Add(new GradientStop(val2, (ShadowRadius * 0.7 + cornerRadius) * num));
			val2.A = (byte)Math.Round(0.02654 * (double)unchecked((int)c.A));
			val.Add(new GradientStop(val2, (ShadowRadius * 0.9 + cornerRadius) * num));
			val2.A = 0;
			val.Add(new GradientStop(val2, (ShadowRadius + cornerRadius) * num));
			((Freezable)val).Freeze();
			return val;
		}
	}

	private Brush[] CreateBrushes(Color c, CornerRadius cornerRadius)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		Brush[] obj = new Brush[9]
		{
			default(Brush),
			default(Brush),
			default(Brush),
			default(Brush),
			(Brush)new SolidColorBrush(c),
			default(Brush),
			default(Brush),
			default(Brush),
			default(Brush)
		};
		((Freezable)obj[4]).Freeze();
		GradientStopCollection val = CreateStops(c, 0.0);
		LinearGradientBrush val2 = new LinearGradientBrush(val, new Point(0.0, 1.0), new Point(0.0, 0.0));
		((Freezable)val2).Freeze();
		obj[1] = (Brush)val2;
		LinearGradientBrush val3 = new LinearGradientBrush(val, new Point(1.0, 0.0), new Point(0.0, 0.0));
		((Freezable)val3).Freeze();
		obj[3] = (Brush)val3;
		LinearGradientBrush val4 = new LinearGradientBrush(val, new Point(0.0, 0.0), new Point(1.0, 0.0));
		((Freezable)val4).Freeze();
		obj[5] = (Brush)val4;
		LinearGradientBrush val5 = new LinearGradientBrush(val, new Point(0.0, 0.0), new Point(0.0, 1.0));
		((Freezable)val5).Freeze();
		obj[7] = (Brush)val5;
		GradientStopCollection val6 = ((cornerRadius.TopLeft != 0.0) ? CreateStops(c, cornerRadius.TopLeft) : val);
		RadialGradientBrush val7 = new RadialGradientBrush(val6)
		{
			RadiusX = 1.0,
			RadiusY = 1.0,
			Center = new Point(1.0, 1.0),
			GradientOrigin = new Point(1.0, 1.0)
		};
		((Freezable)val7).Freeze();
		obj[0] = (Brush)val7;
		GradientStopCollection val8 = ((cornerRadius.TopRight == 0.0) ? val : ((cornerRadius.TopRight != cornerRadius.TopLeft) ? CreateStops(c, cornerRadius.TopRight) : val6));
		RadialGradientBrush val9 = new RadialGradientBrush(val8)
		{
			RadiusX = 1.0,
			RadiusY = 1.0,
			Center = new Point(0.0, 1.0),
			GradientOrigin = new Point(0.0, 1.0)
		};
		((Freezable)val9).Freeze();
		obj[2] = (Brush)val9;
		GradientStopCollection val10 = ((cornerRadius.BottomLeft == 0.0) ? val : ((cornerRadius.BottomLeft == cornerRadius.TopLeft) ? val6 : ((cornerRadius.BottomLeft != cornerRadius.TopRight) ? CreateStops(c, cornerRadius.BottomLeft) : val8)));
		RadialGradientBrush val11 = new RadialGradientBrush(val10)
		{
			RadiusX = 1.0,
			RadiusY = 1.0,
			Center = new Point(1.0, 0.0),
			GradientOrigin = new Point(1.0, 0.0)
		};
		((Freezable)val11).Freeze();
		obj[6] = (Brush)val11;
		GradientStopCollection val12 = ((cornerRadius.BottomRight == 0.0) ? val : ((cornerRadius.BottomRight == cornerRadius.TopLeft) ? val6 : ((cornerRadius.BottomRight == cornerRadius.TopRight) ? val8 : ((cornerRadius.BottomRight != cornerRadius.BottomLeft) ? CreateStops(c, cornerRadius.BottomRight) : val10))));
		RadialGradientBrush val13 = new RadialGradientBrush(val12)
		{
			RadiusX = 1.0,
			RadiusY = 1.0,
			Center = new Point(0.0, 0.0),
			GradientOrigin = new Point(0.0, 0.0)
		};
		((Freezable)val13).Freeze();
		obj[8] = (Brush)val13;
		return (Brush[])(object)obj;
	}

	private Brush[] GetBrushes(Color c, CornerRadius cornerRadius)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (_commonBrushes == null)
		{
			object resourceAccess = _resourceAccess;
			ObjectFlowControl.CheckForSyncLockOnValueType(resourceAccess);
			bool flag = false;
			try
			{
				Monitor.Enter(resourceAccess, ref flag);
				if (_commonBrushes == null)
				{
					_commonBrushes = CreateBrushes(c, cornerRadius);
					_commonCornerRadius = cornerRadius;
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(resourceAccess);
				}
			}
		}
		if (c == ((SolidColorBrush)_commonBrushes[4]).Color && cornerRadius == _commonCornerRadius)
		{
			_brushes = null;
			return _commonBrushes;
		}
		if (_brushes == null)
		{
			_brushes = CreateBrushes(c, cornerRadius);
		}
		return _brushes;
	}
}
