using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.UI.Controls;

namespace PCL;

[StandardModule]
internal sealed class ModStyle
{
	public class TimerRun : Run, System.IDisposable
	{
		public delegate void TimerTickDelegate(TimerRun sender);

		private DispatcherTimer _timer;

		public static readonly DependencyProperty UpdateIntervalProperty = DependencyProperty.Register("UpdateInterval", typeof(TimeSpan), typeof(TimerRun), new PropertyMetadata((object)TimeSpan.FromSeconds(1.0)));

		[CompilerGenerated]
		private TimerTickDelegate TimerTickEvent;

		private object _isDisposed;

		private object _isTimerRunning => _timer != null && _timer.IsEnabled;

		public TimeSpan UpdateInterval
		{
			get
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Unknown result type (might be due to invalid IL or missing references)
				object value = base.GetValue(UpdateIntervalProperty);
				if (value == null)
				{
					return default(TimeSpan);
				}
				return (TimeSpan)value;
			}
			set
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				if (value > TimeSpan.Zero)
				{
					base.SetValue(UpdateIntervalProperty, (object)value);
				}
			}
		}

		[field: CompilerGenerated]
		public bool AutoStart
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public event TimerTickDelegate TimerTick
		{
			[CompilerGenerated]
			add
			{
				TimerTickDelegate timerTickDelegate = TimerTickEvent;
				TimerTickDelegate timerTickDelegate2;
				do
				{
					timerTickDelegate2 = timerTickDelegate;
					TimerTickDelegate timerTickDelegate3 = (TimerTickDelegate)System.Delegate.Combine((System.Delegate)timerTickDelegate2, (System.Delegate)value);
					timerTickDelegate = Interlocked.CompareExchange<TimerTickDelegate>(ref TimerTickEvent, timerTickDelegate3, timerTickDelegate2);
				}
				while (timerTickDelegate != timerTickDelegate2);
			}
			[CompilerGenerated]
			remove
			{
				TimerTickDelegate timerTickDelegate = TimerTickEvent;
				TimerTickDelegate timerTickDelegate2;
				do
				{
					timerTickDelegate2 = timerTickDelegate;
					TimerTickDelegate timerTickDelegate3 = (TimerTickDelegate)System.Delegate.Remove((System.Delegate)timerTickDelegate2, (System.Delegate)value);
					timerTickDelegate = Interlocked.CompareExchange<TimerTickDelegate>(ref TimerTickEvent, timerTickDelegate3, timerTickDelegate2);
				}
				while (timerTickDelegate != timerTickDelegate2);
			}
		}

		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			base.OnPropertyChanged(e);
			if (e.Property == UpdateIntervalProperty && _timer != null)
			{
				_timer.Interval = UpdateInterval;
			}
		}

		public TimerRun(TimeSpan interval = default(TimeSpan), bool autoStart = false)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			((FrameworkContentElement)this).Loaded += new RoutedEventHandler(OnLoaded);
			((FrameworkContentElement)this).Unloaded += new RoutedEventHandler(OnUnloaded);
			_timer = null;
			_isDisposed = false;
			_timer = new DispatcherTimer();
			_timer.Tick += new EventHandler(_timerTick);
			UpdateInterval = ((interval == default(TimeSpan)) ? TimeSpan.FromSeconds(1.0) : interval);
			AutoStart = autoStart;
		}

		private void _timerTick(object sender, EventArgs e)
		{
			TimerTickEvent?.Invoke(this);
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			if (AutoStart)
			{
				StartTimer();
			}
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			StopTimer();
		}

		public void StartTimer()
		{
			if (((DispatcherObject)this).Dispatcher == null)
			{
				ModBase.Log("[TimerRun] Dispatcher is null, unable to run", ModBase.LogLevel.Critical);
			}
			else if (Conversions.ToBoolean(Operators.NotObject(_isTimerRunning)))
			{
				DispatcherTimer timer = _timer;
				if (timer != null)
				{
					timer.Start();
				}
			}
		}

		public void StopTimer()
		{
			if (Conversions.ToBoolean(_isTimerRunning))
			{
				DispatcherTimer timer = _timer;
				if (timer != null)
				{
					timer.Stop();
				}
			}
		}

		public void Dispose()
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			if (!Conversions.ToBoolean(_isDisposed))
			{
				_isDisposed = true;
				_timer.Tick -= new EventHandler(_timerTick);
				DispatcherTimer timer = _timer;
				if (timer != null)
				{
					timer.Stop();
				}
				_timer = null;
			}
		}

		void System.IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}
	}

	public class MinecraftFormatter
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _Closure_0024__
		{
			public static readonly _Closure_0024__ _0024I;

			public static TimerRun.TimerTickDelegate _0024I7_002D0;

			static _Closure_0024__()
			{
				_0024I = new _Closure_0024__();
			}

			[SpecialName]
			internal void _Lambda_0024__7_002D0(TimerRun sender)
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Expected O, but got Unknown
				checked
				{
					if (!string.IsNullOrEmpty(((Run)sender).Text))
					{
						StringBuilder val = new StringBuilder();
						int num = ((Run)sender).Text.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							val.Append(randomChars[random.Next(randomChars.Length)]);
						}
						((Run)sender).Text = val.ToString();
					}
				}
			}
		}

		private static Dictionary<string, string> colorMap;

		private static readonly Random random;

		private static readonly string randomChars;

		static MinecraftFormatter()
		{
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			Dictionary<string, string> obj = new Dictionary<string, string>();
			obj.Add("black", "0");
			obj.Add("dark_blue", "1");
			obj.Add("dark_green", "2");
			obj.Add("dark_aqua", "3");
			obj.Add("dark_red", "4");
			obj.Add("dark_purple", "5");
			obj.Add("gold", "6");
			obj.Add("gray", "7");
			obj.Add("dark_gray", "8");
			obj.Add("blue", "9");
			obj.Add("green", "a");
			obj.Add("aqua", "b");
			obj.Add("red", "c");
			obj.Add("light_purple", "d");
			obj.Add("yellow", "e");
			obj.Add("white", "f");
			colorMap = obj;
			random = new Random();
			randomChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^&*()_+-=[]{}|;:,.<>?/~";
		}

		public static string ConvertToMinecraftFormat(JObject data)
		{
			string text = "";
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<JToken>)data["extra"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					text += ProcessElement((JObject)current, new List<string>());
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			return text.Replace("§§", "§");
		}

		private static string ProcessElement(JObject element, List<string> currentFormat)
		{
			string text = "";
			List<string> val = new List<string>((System.Collections.Generic.IEnumerable<string>)currentFormat);
			if (element.ContainsKey("bold") && element["bold"].ToObject<bool>())
			{
				val.Add("l");
			}
			if (element.ContainsKey("color"))
			{
				string text2 = element["color"].ToString();
				string text3 = "f";
				if (colorMap.ContainsKey(text2))
				{
					text3 = colorMap[text2];
				}
				val.Insert(0, text3);
			}
			if (val.Count > 0)
			{
				text = text + "§" + string.Join("§", (System.Collections.Generic.IEnumerable<string>)val);
			}
			if (element.ContainsKey("text"))
			{
				text += element["text"].ToString();
			}
			if (element.ContainsKey("extra"))
			{
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)element["extra"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						text += ProcessElement((JObject)current, new List<string>((System.Collections.Generic.IEnumerable<string>)val));
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			return text;
		}

		public static void SetColorfulTextLab(string text, TextBlock lab, bool isDarkMode = true)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			if (lab == null)
			{
				ModBase.Log("[Style] SetColorfulTextLab: lab is null");
				return;
			}
			((TextElementCollection<Inline>)(object)lab.Inlines).Clear();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			string color = (isDarkMode ? "#FFFFFF" : "#888888");
			bool flag6 = false;
			TimerRun timerRun = new TimerRun();
			((TextElementCollection<Inline>)(object)lab.Inlines).Add((Inline)(object)timerRun);
			List<TimerRun> val = new List<TimerRun>();
			foreach (char c in text)
			{
				if (Operators.CompareString(Conversions.ToString(c), "§", false) == 0)
				{
					flag6 = true;
					continue;
				}
				if (flag6)
				{
					if (!MotdRenderer.TryGetColorFromCode(Conversions.ToString(c), isDarkMode, out color))
					{
						switch (c)
						{
						case 'K':
						case 'k':
							flag5 = true;
							if (!string.IsNullOrEmpty(((Run)timerRun).Text))
							{
								timerRun = new TimerRun();
								((TextElementCollection<Inline>)(object)lab.Inlines).Add((Inline)(object)timerRun);
							}
							timerRun.AutoStart = true;
							val.Add(timerRun);
							break;
						case 'l':
							flag4 = true;
							break;
						case 'o':
							flag = true;
							break;
						case 'n':
							flag3 = true;
							break;
						case 'm':
							flag2 = true;
							break;
						case 'r':
							color = (isDarkMode ? "#FFFFFF" : "#888888");
							flag4 = false;
							flag = false;
							flag3 = false;
							flag2 = false;
							flag5 = false;
							break;
						}
					}
					if (!string.IsNullOrEmpty(((Run)timerRun).Text) && Operators.CompareString(Conversions.ToString(c), "k", false) != 0 && Operators.CompareString(Conversions.ToString(c), "K", false) != 0)
					{
						timerRun = new TimerRun();
						((TextElementCollection<Inline>)(object)lab.Inlines).Add((Inline)(object)timerRun);
					}
					((TextElement)timerRun).Foreground = (Brush)new SolidColorBrush((Color)new ModBase.MyColor(color));
					((TextElement)timerRun).FontWeight = (flag4 ? FontWeights.Bold : FontWeights.Normal);
					((TextElement)timerRun).FontStyle = (flag ? FontStyles.Italic : FontStyles.Normal);
					((Inline)timerRun).TextDecorations = (flag3 ? TextDecorations.Strikethrough : null);
					((Inline)timerRun).TextDecorations = (flag2 ? TextDecorations.Underline : null);
				}
				else if (flag5)
				{
					TimerRun timerRun2;
					((Run)(timerRun2 = timerRun)).Text = ((Run)timerRun2).Text + Conversions.ToString(randomChars[random.Next(randomChars.Length)]);
				}
				else
				{
					TimerRun timerRun2;
					((Run)(timerRun2 = timerRun)).Text = ((Run)timerRun2).Text + Conversions.ToString(c);
				}
				if (flag6)
				{
					flag6 = false;
				}
			}
			if (val.Count <= 0)
			{
				return;
			}
			System.Collections.Generic.IEnumerator<TimerRun> enumerator = default(System.Collections.Generic.IEnumerator<TimerRun>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TimerRun current = enumerator.Current;
					current.UpdateInterval = TimeSpan.FromMilliseconds(20.0);
					current.TimerTick += ((_Closure_0024__._0024I7_002D0 == null) ? (_Closure_0024__._0024I7_002D0 = checked([SpecialName] (TimerRun sender) =>
					{
						//IL_000d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0013: Expected O, but got Unknown
						if (!string.IsNullOrEmpty(((Run)sender).Text))
						{
							StringBuilder val2 = new StringBuilder();
							int num = ((Run)sender).Text.Length - 1;
							for (int j = 0; j <= num; j++)
							{
								val2.Append(randomChars[random.Next(randomChars.Length)]);
							}
							((Run)sender).Text = val2.ToString();
						}
					})) : _Closure_0024__._0024I7_002D0);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}
}
