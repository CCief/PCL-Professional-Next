using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageInstanceExport : MyPageRight, IRefreshable, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_16_GetAllRules : System.Collections.Generic.IEnumerable<string>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<string>, System.IDisposable, System.Collections.IEnumerator
	{
		public int _0024State;

		public string _0024Current;

		public int _0024InitialThreadId;

		internal PageInstanceExport _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<string> _0024S0;

		internal System.Collections.Generic.IEnumerator<MyCheckBox> _0024S1;

		internal ExportOption _0024VB_0024ResumableLocal_TargetOption_00242;

		internal string[] _0024S3;

		internal int _0024S4;

		public string Current => _0024Current;

		object System.Collections.IEnumerator.Current => _0024Current;

		public VB_0024StateMachine_16_GetAllRules(int _0024State)
		{
			this._0024State = _0024State;
			_0024InitialThreadId = Environment.CurrentManagedThreadId;
		}

		private void Dispose()
		{
			switch (_0024State)
			{
			case 1:
				_0024State = -3;
				break;
			case 6:
			case 7:
			case 8:
				_0024State = -4;
				break;
			default:
				_0024State = -1;
				break;
			}
			MoveNext();
			_0024State = -2;
		}

		void System.IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		[CompilerGenerated]
		private bool MoveNext()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			checked
			{
				switch (num)
				{
				default:
					return false;
				case 0:
					num = (_0024State = -1);
					if (_0024VB_0024Me.RulesOverrides == null)
					{
						_0024Current = "";
						num = (_0024State = 2);
						return true;
					}
					goto case -3;
				case -3:
				case 1:
					try
					{
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return true;
						default:
							_0024S0 = _0024VB_0024Me.RulesOverrides.GetEnumerator();
							break;
						case 1:
							num = (_0024State = -1);
							break;
						}
						if (_0024S0.MoveNext())
						{
							string current2 = _0024S0.Current;
							_0024Current = current2;
							num = (_0024State = 1);
							return true;
						}
					}
					finally
					{
						if (num < 0)
						{
							((System.IDisposable)_0024S0)?.Dispose();
						}
					}
					break;
				case 2:
					num = (_0024State = -1);
					_0024Current = "# 修改下方的规则以控制需要导出的内容。";
					num = (_0024State = 3);
					return true;
				case 3:
					num = (_0024State = -1);
					_0024Current = "# 以 ! 开头以反选。可以使用 *、?、[] 通配符。靠后的行覆盖靠前的。";
					num = (_0024State = 4);
					return true;
				case 4:
					num = (_0024State = -1);
					_0024Current = "";
					num = (_0024State = 5);
					return true;
				case 5:
					num = (_0024State = -1);
					goto case -4;
				case -4:
				case 6:
				case 7:
				case 8:
					try
					{
						switch (num)
						{
						case -4:
							num = (_0024State = -1);
							return true;
						default:
							_0024S1 = _0024VB_0024Me.GetAllOptions(IncludeHidden: false).GetEnumerator();
							break;
						case 6:
							num = (_0024State = -1);
							_0024S3 = _0024VB_0024ResumableLocal_TargetOption_00242.Rules.Split('|', (StringSplitOptions)0);
							_0024S4 = 0;
							goto IL_02bb;
						case 7:
							num = (_0024State = -1);
							_0024S4++;
							goto IL_02bb;
						case 8:
							{
								num = (_0024State = -1);
								break;
							}
							IL_02bb:
							if (_0024S4 < _0024S3.Length)
							{
								string text = _0024S3[_0024S4];
								_0024Current = text;
								num = (_0024State = 7);
								return true;
							}
							_0024Current = "";
							num = (_0024State = 8);
							return true;
						}
						while (((System.Collections.IEnumerator)_0024S1).MoveNext())
						{
							MyCheckBox current = _0024S1.Current;
							bool? @checked = current.Checked;
							if (!((!@checked) ?? @checked).GetValueOrDefault())
							{
								_0024VB_0024ResumableLocal_TargetOption_00242 = _0024VB_0024Me.GetExportOption(current);
								if (_0024VB_0024ResumableLocal_TargetOption_00242.Rules != null)
								{
									_0024Current = $"# {_0024VB_0024ResumableLocal_TargetOption_00242.Title}";
									num = (_0024State = 6);
									return true;
								}
							}
						}
					}
					finally
					{
						if (num < 0 && _0024S1 != null)
						{
							((System.IDisposable)_0024S1).Dispose();
						}
					}
					_0024Current = "# 排除的文件";
					num = (_0024State = 9);
					return true;
				case 9:
					num = (_0024State = -1);
					_0024Current = "!*.log";
					num = (_0024State = 10);
					return true;
				case 10:
					num = (_0024State = -1);
					_0024Current = "!*.dat_old";
					num = (_0024State = 11);
					return true;
				case 11:
					num = (_0024State = -1);
					_0024Current = "!*.BakaCoreInfo";
					num = (_0024State = 12);
					return true;
				case 12:
					num = (_0024State = -1);
					_0024Current = "!hmclversion.cfg";
					num = (_0024State = 13);
					return true;
				case 13:
					num = (_0024State = -1);
					_0024Current = "!log4j2.xml";
					num = (_0024State = 14);
					return true;
				case 14:
					num = (_0024State = -1);
					_0024Current = "";
					num = (_0024State = 15);
					return true;
				case 15:
					num = (_0024State = -1);
					break;
				}
				return false;
			}
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private System.Collections.Generic.IEnumerator<string> GetEnumerator()
		{
			VB_0024StateMachine_16_GetAllRules result;
			if (_0024State == -2 && _0024InitialThreadId == Environment.CurrentManagedThreadId)
			{
				_0024State = 0;
				result = this;
			}
			else
			{
				result = new VB_0024StateMachine_16_GetAllRules(0)
				{
					_0024VB_0024Me = _0024VB_0024Me
				};
			}
			return result;
		}

		System.Collections.Generic.IEnumerator<string> System.Collections.Generic.IEnumerable<string>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (System.Collections.IEnumerator)GetEnumerator();
		}

		private void Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		void System.Collections.IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_18_GetExtraFileLines : System.Collections.Generic.IEnumerable<string>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<string>, System.IDisposable, System.Collections.IEnumerator
	{
		public int _0024State;

		public string _0024Current;

		public int _0024InitialThreadId;

		internal PageInstanceExport _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<string> _0024S0;

		public string Current => _0024Current;

		object System.Collections.IEnumerator.Current => _0024Current;

		public VB_0024StateMachine_18_GetExtraFileLines(int _0024State)
		{
			this._0024State = _0024State;
			_0024InitialThreadId = Environment.CurrentManagedThreadId;
		}

		private void Dispose()
		{
			int num = _0024State;
			if (num == 1)
			{
				_0024State = -3;
			}
			else
			{
				_0024State = -1;
			}
			MoveNext();
			_0024State = -2;
		}

		void System.IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		[CompilerGenerated]
		private bool MoveNext()
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			switch (num)
			{
			default:
				return false;
			case 0:
				num = (_0024State = -1);
				if (_0024VB_0024Me.ExtraFiles == null)
				{
					_0024Current = "";
					num = (_0024State = 2);
					return true;
				}
				goto case -3;
			case -3:
			case 1:
				try
				{
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return true;
					default:
						_0024S0 = _0024VB_0024Me.ExtraFiles.GetEnumerator();
						break;
					case 1:
						num = (_0024State = -1);
						break;
					}
					if (_0024S0.MoveNext())
					{
						string current = _0024S0.Current;
						_0024Current = current;
						num = (_0024State = 1);
						return true;
					}
				}
				finally
				{
					if (num < 0)
					{
						((System.IDisposable)_0024S0)?.Dispose();
					}
				}
				break;
			case 2:
				num = (_0024State = -1);
				_0024Current = "# 如果想将额外的文件自动放到压缩包根目录中，可以将它们的路径写在下方。";
				num = (_0024State = 3);
				return true;
			case 3:
				num = (_0024State = -1);
				_0024Current = "# 必须是完整路径。每行中，若以 \\ 结尾则代表是文件夹，不以 \\ 结尾则代表是文件。";
				num = (_0024State = 4);
				return true;
			case 4:
				num = (_0024State = -1);
				_0024Current = "";
				num = (_0024State = 5);
				return true;
			case 5:
				num = (_0024State = -1);
				break;
			}
			return false;
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private System.Collections.Generic.IEnumerator<string> GetEnumerator()
		{
			VB_0024StateMachine_18_GetExtraFileLines result;
			if (_0024State == -2 && _0024InitialThreadId == Environment.CurrentManagedThreadId)
			{
				_0024State = 0;
				result = this;
			}
			else
			{
				result = new VB_0024StateMachine_18_GetExtraFileLines(0)
				{
					_0024VB_0024Me = _0024VB_0024Me
				};
			}
			return result;
		}

		System.Collections.Generic.IEnumerator<string> System.Collections.Generic.IEnumerable<string>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (System.Collections.IEnumerator)GetEnumerator();
		}

		private void Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		void System.Collections.IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_8_StandardizeLines : System.Collections.Generic.IEnumerable<string>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<string>, System.IDisposable, System.Collections.IEnumerator
	{
		public int _0024State;

		public string _0024Current;

		public int _0024InitialThreadId;

		internal System.Collections.Generic.IEnumerable<string> _0024VB_0024Local_Raw;

		internal System.Collections.Generic.IEnumerable<string> _0024P_Raw;

		internal bool _0024VB_0024Local_AddSuffixStarToFolderPath;

		internal bool _0024P_AddSuffixStarToFolderPath;

		internal PageInstanceExport _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<string> _0024S0;

		public string Current => _0024Current;

		object System.Collections.IEnumerator.Current => _0024Current;

		public VB_0024StateMachine_8_StandardizeLines(int _0024State)
		{
			this._0024State = _0024State;
			_0024InitialThreadId = Environment.CurrentManagedThreadId;
		}

		private void Dispose()
		{
			int num = _0024State;
			if (num == 1)
			{
				_0024State = -3;
			}
			else
			{
				_0024State = -1;
			}
			MoveNext();
			_0024State = -2;
		}

		void System.IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		[CompilerGenerated]
		private bool MoveNext()
		{
			int num = _0024State;
			switch (num)
			{
			default:
				return false;
			case 0:
				num = (_0024State = -1);
				break;
			case -3:
			case 1:
				break;
			}
			try
			{
				switch (num)
				{
				case -3:
					num = (_0024State = -1);
					return true;
				default:
					_0024S0 = _0024VB_0024Local_Raw.GetEnumerator();
					break;
				case 1:
					num = (_0024State = -1);
					break;
				}
				while (((System.Collections.IEnumerator)_0024S0).MoveNext())
				{
					string current = _0024S0.Current;
					current = current.Trim();
					if (Operators.CompareString(current, "", false) != 0 && !ModBase.StartsWithF(current, "#") && !ModBase.StartsWithF(current, "="))
					{
						current = current.Replace("/", "\\");
						_0024Current = current + ((ModBase.EndsWithF(current, "\\") && _0024VB_0024Local_AddSuffixStarToFolderPath) ? "*" : "");
						num = (_0024State = 1);
						return true;
					}
				}
			}
			finally
			{
				if (num < 0 && _0024S0 != null)
				{
					((System.IDisposable)_0024S0)?.Dispose();
				}
			}
			return false;
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private System.Collections.Generic.IEnumerator<string> GetEnumerator()
		{
			VB_0024StateMachine_8_StandardizeLines vB_0024StateMachine_8_StandardizeLines;
			if (_0024State == -2 && _0024InitialThreadId == Environment.CurrentManagedThreadId)
			{
				_0024State = 0;
				vB_0024StateMachine_8_StandardizeLines = this;
			}
			else
			{
				vB_0024StateMachine_8_StandardizeLines = new VB_0024StateMachine_8_StandardizeLines(0)
				{
					_0024VB_0024Me = _0024VB_0024Me
				};
			}
			vB_0024StateMachine_8_StandardizeLines._0024VB_0024Local_Raw = _0024P_Raw;
			vB_0024StateMachine_8_StandardizeLines._0024VB_0024Local_AddSuffixStarToFolderPath = _0024P_AddSuffixStarToFolderPath;
			return vB_0024StateMachine_8_StandardizeLines;
		}

		System.Collections.Generic.IEnumerator<string> System.Collections.Generic.IEnumerable<string>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (System.Collections.IEnumerator)GetEnumerator();
		}

		private void Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		void System.Collections.IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_9_GetAllOptions : System.Collections.Generic.IEnumerable<MyCheckBox>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<MyCheckBox>, System.IDisposable, System.Collections.IEnumerator
	{
		public int _0024State;

		public MyCheckBox _0024Current;

		public int _0024InitialThreadId;

		internal bool _0024VB_0024Local_IncludeHidden;

		internal bool _0024P_IncludeHidden;

		internal PageInstanceExport _0024VB_0024Me;

		internal System.Collections.IEnumerator _0024S0;

		internal System.Collections.IEnumerator _0024S1;

		public MyCheckBox Current => _0024Current;

		object System.Collections.IEnumerator.Current => _0024Current;

		public VB_0024StateMachine_9_GetAllOptions(int _0024State)
		{
			this._0024State = _0024State;
			_0024InitialThreadId = Environment.CurrentManagedThreadId;
		}

		private void Dispose()
		{
			switch (_0024State)
			{
			case 1:
				_0024State = -3;
				break;
			case 2:
				_0024State = -4;
				break;
			default:
				_0024State = -1;
				break;
			}
			MoveNext();
			_0024State = -2;
		}

		void System.IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		[CompilerGenerated]
		private bool MoveNext()
		{
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			switch (num)
			{
			default:
				return false;
			case 0:
				num = (_0024State = -1);
				break;
			case -4:
			case -3:
			case 1:
			case 2:
				break;
			}
			try
			{
				object objectValue = default(object);
				switch (num)
				{
				case -3:
					num = (_0024State = -1);
					return true;
				default:
					_0024S0 = ((Panel)_0024VB_0024Me.PanOptions).Children.GetEnumerator();
					goto IL_01d9;
				case 1:
					num = (_0024State = -1);
					goto IL_01d9;
				case -4:
				case 2:
					{
						try
						{
							switch (num)
							{
							case -4:
								num = (_0024State = -1);
								return true;
							default:
								_0024S1 = ((Panel)(StackPanel)objectValue).Children.GetEnumerator();
								break;
							case 2:
								num = (_0024State = -1);
								break;
							}
							while (_0024S1.MoveNext())
							{
								object objectValue2 = RuntimeHelpers.GetObjectValue(_0024S1.Current);
								if ((_0024VB_0024Local_IncludeHidden || !Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false)) && objectValue2 is MyCheckBox)
								{
									_0024Current = (MyCheckBox)objectValue2;
									num = (_0024State = 2);
									return true;
								}
							}
						}
						finally
						{
							if (num < 0 && _0024S1 is System.IDisposable)
							{
								(_0024S1 as System.IDisposable).Dispose();
							}
						}
						goto IL_01d9;
					}
					IL_01d9:
					while (_0024S0.MoveNext())
					{
						objectValue = RuntimeHelpers.GetObjectValue(_0024S0.Current);
						if (!_0024VB_0024Local_IncludeHidden && Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false))
						{
							continue;
						}
						if (objectValue is MyCheckBox)
						{
							_0024Current = (MyCheckBox)objectValue;
							num = (_0024State = 1);
							return true;
						}
						if (!(objectValue is StackPanel))
						{
							continue;
						}
						goto case -4;
					}
					break;
				}
			}
			finally
			{
				if (num < 0 && _0024S0 is System.IDisposable)
				{
					(_0024S0 as System.IDisposable).Dispose();
				}
			}
			return false;
		}

		bool System.Collections.IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private System.Collections.Generic.IEnumerator<MyCheckBox> GetEnumerator()
		{
			VB_0024StateMachine_9_GetAllOptions vB_0024StateMachine_9_GetAllOptions;
			if (_0024State == -2 && _0024InitialThreadId == Environment.CurrentManagedThreadId)
			{
				_0024State = 0;
				vB_0024StateMachine_9_GetAllOptions = this;
			}
			else
			{
				vB_0024StateMachine_9_GetAllOptions = new VB_0024StateMachine_9_GetAllOptions(0)
				{
					_0024VB_0024Me = _0024VB_0024Me
				};
			}
			vB_0024StateMachine_9_GetAllOptions._0024VB_0024Local_IncludeHidden = _0024P_IncludeHidden;
			return vB_0024StateMachine_9_GetAllOptions;
		}

		System.Collections.Generic.IEnumerator<MyCheckBox> System.Collections.Generic.IEnumerable<MyCheckBox>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return (System.Collections.IEnumerator)GetEnumerator();
		}

		private void Reset()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			throw new NotSupportedException();
		}

		void System.Collections.IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<DirectoryInfo, System.DateTime> _0024I6_002D1;

		public static Func<FileInfo, string> _0024I7_002D3;

		public static Func<ModLocalComp.LocalCompFile, string> _0024I24_002D5;

		public static Func<ModLocalComp.LocalCompFile, uint> _0024I24_002D7;

		public static Func<string, bool> _0024I24_002D10;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__6_002D1(DirectoryInfo f)
		{
			return ((FileSystemInfo)f).LastWriteTime;
		}

		[SpecialName]
		internal string _Lambda_0024__7_002D3(FileInfo f)
		{
			return f.Name;
		}

		[SpecialName]
		internal string _Lambda_0024__24_002D5(ModLocalComp.LocalCompFile m)
		{
			return m.ModrinthHash;
		}

		[SpecialName]
		internal uint _Lambda_0024__24_002D7(ModLocalComp.LocalCompFile m)
		{
			return m.CurseForgeHash;
		}

		[SpecialName]
		internal bool _Lambda_0024__24_002D10(string u)
		{
			return u.Contains("modrinth.com");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D0
	{
		public string _0024VB_0024Local_PathIndie;

		public List<string> _0024VB_0024Local_AllRules;

		public string _0024VB_0024Local_OverridesFolder;

		public bool _0024VB_0024Local_CheckHostedAssets;

		public bool _0024VB_0024Local_IncludePCL;

		public string _0024VB_0024Local_CacheFolder;

		public List<string> _0024VB_0024Local_AllExtraFiles;

		public ModMinecraft.McInstance _0024VB_0024Local_McInstance;

		public bool _0024VB_0024Local_IncludePCLCustom;

		public string _0024VB_0024Local_LoaderName;

		public bool _0024VB_0024Local_ModrinthUploadMode;

		public string _0024VB_0024Local_PackVersion;

		public string _0024VB_0024Local_PackName;

		public string _0024VB_0024Local_PackPath;

		public _Closure_0024__24_002D0(_Closure_0024__24_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_PathIndie = arg0._0024VB_0024Local_PathIndie;
				_0024VB_0024Local_AllRules = arg0._0024VB_0024Local_AllRules;
				_0024VB_0024Local_OverridesFolder = arg0._0024VB_0024Local_OverridesFolder;
				_0024VB_0024Local_CheckHostedAssets = arg0._0024VB_0024Local_CheckHostedAssets;
				_0024VB_0024Local_IncludePCL = arg0._0024VB_0024Local_IncludePCL;
				_0024VB_0024Local_CacheFolder = arg0._0024VB_0024Local_CacheFolder;
				_0024VB_0024Local_AllExtraFiles = arg0._0024VB_0024Local_AllExtraFiles;
				_0024VB_0024Local_McInstance = arg0._0024VB_0024Local_McInstance;
				_0024VB_0024Local_IncludePCLCustom = arg0._0024VB_0024Local_IncludePCLCustom;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
				_0024VB_0024Local_ModrinthUploadMode = arg0._0024VB_0024Local_ModrinthUploadMode;
				_0024VB_0024Local_PackVersion = arg0._0024VB_0024Local_PackVersion;
				_0024VB_0024Local_PackName = arg0._0024VB_0024Local_PackName;
				_0024VB_0024Local_PackPath = arg0._0024VB_0024Local_PackPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<int, List<ModLocalComp.LocalCompFile>> Loader)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			_Closure_0024__24_002D1 arg = default(_Closure_0024__24_002D1);
			_Closure_0024__24_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D1(null);
			CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output = new List<ModLocalComp.LocalCompFile>();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Progress = 0;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SearchFolder = checked([SpecialName] (DirectoryInfo Folder) =>
			{
				//IL_0114: Unknown result type (might be due to invalid IL or missing references)
				//IL_0119: Unknown result type (might be due to invalid IL or missing references)
				System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
				try
				{
					enumerator2 = Folder.EnumerateDirectories("*", (SearchOption)0).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						DirectoryInfo current2 = enumerator2.Current;
						if ((Operators.CompareString(((FileSystemInfo)Folder).FullName, CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, false) != 0 || !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "assets", "versions", "libraries" }, current2.Name)) && !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }, current2.Name))
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_SearchFolder.Invoke(current2);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
				System.Collections.Generic.IEnumerator<FileInfo> enumerator3 = default(System.Collections.Generic.IEnumerator<FileInfo>);
				try
				{
					enumerator3 = Folder.EnumerateFiles("*", (SearchOption)0).GetEnumerator();
					_Closure_0024__24_002D2 closure_0024__24_002D = default(_Closure_0024__24_002D2);
					System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
					while (((System.Collections.IEnumerator)enumerator3).MoveNext())
					{
						FileInfo current3 = enumerator3.Current;
						closure_0024__24_002D = new _Closure_0024__24_002D2(closure_0024__24_002D)
						{
							_0024VB_0024Local_RelativePath = ModBase.AfterFirst(((FileSystemInfo)current3).FullName, CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie)
						};
						bool flag = false;
						try
						{
							enumerator4 = CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string current4 = enumerator4.Current;
								bool flag2 = current4.StartsWith("!");
								if (LikeOperator.LikeString(closure_0024__24_002D._0024VB_0024Local_RelativePath, current4.TrimStart('!'), (CompareMethod)0))
								{
									flag = !flag2;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator4).Dispose();
						}
						if (flag)
						{
							string text2 = CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + closure_0024__24_002D._0024VB_0024Local_RelativePath;
							ModBase.CopyFile(((FileSystemInfo)current3).FullName, text2);
							if (CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { ".zip", ".rar", ".jar", ".disabled", ".old" }, ((FileSystemInfo)current3).Extension.ToLower()) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "mods", "packs", "openloader", "resource" }, (Func<string, bool>)closure_0024__24_002D._Lambda_0024__2))
							{
								ModLocalComp.LocalCompFile localCompFile = new ModLocalComp.LocalCompFile(text2);
								_ = localCompFile.ModrinthHash;
								Conversions.ToString(localCompFile.CurseForgeHash);
								CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output.Add(localCompFile);
							}
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Progress++;
							if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Progress == 25)
							{
								CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress += (0.94 - CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress) * 0.012;
								CS_0024_003C_003E8__locals0._0024VB_0024Local_Progress = 0;
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3)?.Dispose();
				}
			});
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SearchFolder.Invoke(new DirectoryInfo(_0024VB_0024Local_PathIndie));
			ModBase.Log($"[Export] 复制 overrides 文件完成，有 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output.Count} 个文件需要联网检查");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = 0.95;
			string text = (_0024VB_0024Local_IncludePCL ? _0024VB_0024Local_CacheFolder : (_0024VB_0024Local_CacheFolder + "modpack\\"));
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = _0024VB_0024Local_AllExtraFiles.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (ModBase.EndsWithF(current, "\\") || ModBase.EndsWithF(current, "/"))
					{
						if (Directory.Exists(current))
						{
							ModBase.CopyDirectory(current, text + ModBase.GetFolderNameFromPath(current) + "\\");
						}
						else
						{
							ModMain.Hint($"未找到配置文件中指定的文件夹：{current}", ModMain.HintType.Critical);
						}
					}
					else if (File.Exists(current))
					{
						ModBase.CopyFile(current, text + ModBase.GetFileNameFromPath(current));
					}
					else
					{
						ModMain.Hint($"未找到配置文件中指定的单个文件：{current}", ModMain.HintType.Critical);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = 0.97;
			ModBase.CopyDirectory(_0024VB_0024Local_McInstance.Path + "PCL\\", _0024VB_0024Local_OverridesFolder + "PCL\\");
			if (_0024VB_0024Local_IncludePCL)
			{
				ModBase.CopyFile(ModBase.ExePathWithName, _0024VB_0024Local_CacheFolder + "Plain Craft Launcher.exe");
			}
			if (_0024VB_0024Local_IncludePCLCustom)
			{
				if (Directory.Exists(ModBase.ExePath + "PCL\\Pictures\\"))
				{
					ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Pictures\\", _0024VB_0024Local_CacheFolder + "PCL\\Pictures\\");
				}
				if (Directory.Exists(ModBase.ExePath + "PCL\\Musics\\"))
				{
					ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Musics\\", _0024VB_0024Local_CacheFolder + "PCL\\Musics\\");
				}
				if (Directory.Exists(ModBase.ExePath + "PCL\\Help\\"))
				{
					ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Help\\", _0024VB_0024Local_CacheFolder + "PCL\\Help\\");
				}
				if (File.Exists(ModBase.ExePath + "PCL\\Custom.xaml"))
				{
					ModBase.CopyFile(ModBase.ExePath + "PCL\\Custom.xaml", _0024VB_0024Local_CacheFolder + "PCL\\Custom.xaml");
				}
				if (File.Exists(ModBase.ExePath + "PCL\\Setup.ini"))
				{
					ModBase.CopyFile(ModBase.ExePath + "PCL\\Setup.ini", _0024VB_0024Local_CacheFolder + "PCL\\Setup.ini");
				}
				if (File.Exists(ModBase.ExePath + "PCL\\hints.txt"))
				{
					ModBase.CopyFile(ModBase.ExePath + "PCL\\hints.txt", _0024VB_0024Local_CacheFolder + "PCL\\hints.txt");
				}
				if (File.Exists(ModBase.ExePath + "PCL\\Logo.png"))
				{
					ModBase.CopyFile(ModBase.ExePath + "PCL\\Logo.png", _0024VB_0024Local_CacheFolder + "PCL\\Logo.png");
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(ModLoader.LoaderTask<List<ModLocalComp.LocalCompFile>, Dictionary<ModLocalComp.LocalCompFile, List<string>>> Loader)
		{
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			_Closure_0024__24_002D3 arg = default(_Closure_0024__24_002D3);
			_Closure_0024__24_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D3(null);
			CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3 = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output = new Dictionary<ModLocalComp.LocalCompFile, List<string>>();
			if (!_0024VB_0024Local_CheckHostedAssets)
			{
				ModBase.Log("[Export] 要求跳过联网获取步骤");
				return;
			}
			if (!Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input))
			{
				ModBase.Log("[Export] 没有需要联网检查的文件，跳过联网获取步骤");
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount = 0;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions = new List<System.Exception>();
			checked
			{
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					//IL_0075: Unknown result type (might be due to invalid IL or missing references)
					//IL_007a: Unknown result type (might be due to invalid IL or missing references)
					try
					{
						System.Collections.Generic.IEnumerable<string> list2 = Enumerable.Select<ModLocalComp.LocalCompFile, string>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.ModrinthHash));
						JObject jObject2 = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", (object)ModBase.Join((System.Collections.IEnumerable)list2, "\",\"")), "application/json"));
						System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
						try
						{
							enumerator2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ModLocalComp.LocalCompFile current = enumerator2.Current;
								if (jObject2.ContainsKey(current.ModrinthHash) && !((string?)jObject2[current.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != current.ModrinthHash))
								{
									ModBase.AddToList(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output, current, (string?)jObject2[current.ModrinthHash]["files"][0]["url"]);
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator2).Dispose();
						}
						ModBase.Log($"[Export] 从 Modrinth 获取到 {jObject2.Count} 个本地资源项的对应信息");
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "从 Modrinth 获取本地 Mod 信息失败");
						CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions.Add(ex4);
						ProjectData.ClearProjectError();
					}
					finally
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount++;
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress += 0.45;
					}
				}), "Modrinth - " + _0024VB_0024Local_LoaderName, (ThreadPriority)2);
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					try
					{
						if (!CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
						{
							System.Collections.Generic.IEnumerable<uint> list = Enumerable.Select<ModLocalComp.LocalCompFile, uint>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, uint>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.CurseForgeHash));
							JContainer jContainer = (JContainer)((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432/", "POST", string.Format("{{\"fingerprints\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)list, ",")), "application/json")))["data"]["exactMatches"];
							System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
								_Closure_0024__24_002D4 closure_0024__24_002D = default(_Closure_0024__24_002D4);
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									JObject jObject = (JObject)enumerator.Current;
									closure_0024__24_002D = new _Closure_0024__24_002D4(closure_0024__24_002D);
									if (jObject.ContainsKey("file"))
									{
										closure_0024__24_002D._0024VB_0024Local_File = (JObject)jObject["file"];
										if (!string.IsNullOrEmpty((string?)closure_0024__24_002D._0024VB_0024Local_File["downloadUrl"]))
										{
											ModLocalComp.LocalCompFile localCompFile = Enumerable.FirstOrDefault<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, bool>)closure_0024__24_002D._Lambda_0024__8);
											if (localCompFile != null)
											{
												ModBase.AddToList(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output, localCompFile, ModComp.CompFile.HandleCurseForgeDownloadUrls(closure_0024__24_002D._0024VB_0024Local_File["downloadUrl"].ToString()));
											}
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
							ModBase.Log($"[Export] 从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息");
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "从 CurseForge 获取本地 Mod 信息失败");
						CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions.Add(ex2);
						ProjectData.ClearProjectError();
					}
					finally
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount++;
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress += 0.45;
					}
				}), "CurseForge - " + _0024VB_0024Local_LoaderName, (ThreadPriority)2);
				while (true)
				{
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount != 2)
					{
						if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAborted)
						{
							Thread.Sleep(10);
							continue;
						}
						break;
					}
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions.Count == 1)
					{
						if (ModMain.MyMsgBox("联网获取部分文件信息失败，是否继续导出？\r\n\r\n若继续，无法获取信息的文件将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "部分文件信息获取失败", "继续", "取消") == 2)
						{
							throw Enumerable.First<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions);
						}
						break;
					}
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions.Count > 1 && ModMain.MyMsgBox("联网获取文件信息失败，是否继续导出？\r\n\r\n若继续，所有文件都将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "文件信息获取失败", "继续", "取消") == 2)
					{
						throw Enumerable.First<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)CS_0024_003C_003E8__locals0._0024VB_0024Local_FailedExceptions);
					}
					break;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__9(ModLoader.LoaderTask<Dictionary<ModLocalComp.LocalCompFile, List<string>>, int> Loader)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			JArray jArray = new JArray();
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLocalComp.LocalCompFile, List<string>>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLocalComp.LocalCompFile, List<string>>>);
			try
			{
				enumerator = Loader.Input.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<ModLocalComp.LocalCompFile, List<string>> current = enumerator.Current;
					ModLocalComp.LocalCompFile key = current.Key;
					jArray.Add(new JObject
					{
						{
							"path",
							ModBase.AfterFirst(key.Path, _0024VB_0024Local_OverridesFolder).Replace("\\", "/")
						},
						{
							"hashes",
							new JObject
							{
								{ "sha1", key.ModrinthHash },
								{
									"sha512",
									ModBase.GetFileSHA512(key.Path)
								}
							}
						},
						{
							"downloads",
							new JArray(Enumerable.OrderByDescending<string, bool>((System.Collections.Generic.IEnumerable<string>)current.Value, (_Closure_0024__._0024I24_002D10 == null) ? (_Closure_0024__._0024I24_002D10 = [SpecialName] (string u) => u.Contains("modrinth.com")) : _Closure_0024__._0024I24_002D10))
						},
						{
							"fileSize",
							new FileInfo(key.Path).Length
						}
					});
					File.Delete(key.Path);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			Loader.Progress = 0.2;
			JObject jObject = new JObject { 
			{
				"minecraft",
				_0024VB_0024Local_McInstance.Version.McName
			} };
			if (_0024VB_0024Local_McInstance.Version.HasForge)
			{
				jObject.Add("forge", _0024VB_0024Local_McInstance.Version.ForgeVersion);
			}
			if (_0024VB_0024Local_McInstance.Version.HasFabric)
			{
				jObject.Add("fabric-loader", _0024VB_0024Local_McInstance.Version.FabricVersion);
			}
			if (_0024VB_0024Local_McInstance.Version.HasNeoForge)
			{
				jObject.Add("neoforge", _0024VB_0024Local_McInstance.Version.NeoForgeVersion);
			}
			JObject jObject2 = new JObject
			{
				{ "game", "minecraft" },
				{ "formatVersion", 1 },
				{ "versionId", _0024VB_0024Local_PackVersion },
				{ "name", _0024VB_0024Local_PackName },
				{ "summary", _0024VB_0024Local_McInstance.Info },
				{ "files", jArray },
				{ "dependencies", jObject }
			};
			File.WriteAllText(_0024VB_0024Local_CacheFolder + "modpack\\modrinth.index.json", jObject2.ToString(Formatting.Indented));
			Directory.CreateDirectory(ModBase.GetPathFromFullPath(_0024VB_0024Local_PackPath));
			if (File.Exists(_0024VB_0024Local_PackPath))
			{
				File.Delete(_0024VB_0024Local_PackPath);
			}
			if (_0024VB_0024Local_IncludePCL)
			{
				ZipFile.CreateFromDirectory(_0024VB_0024Local_CacheFolder + "modpack\\", _0024VB_0024Local_CacheFolder + "modpack.mrpack");
				Loader.Progress = 0.5;
				Directory.Delete(_0024VB_0024Local_CacheFolder + "modpack\\", true);
				Loader.Progress = 0.6;
				ZipFile.CreateFromDirectory(_0024VB_0024Local_CacheFolder, _0024VB_0024Local_PackPath);
				Loader.Progress = 0.9;
			}
			else
			{
				ZipFile.CreateFromDirectory(_0024VB_0024Local_CacheFolder + "modpack\\", _0024VB_0024Local_PackPath);
				Loader.Progress = 0.8;
			}
			Directory.Delete(_0024VB_0024Local_CacheFolder, true);
			ModBase.OpenExplorer(_0024VB_0024Local_PackPath);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D1
	{
		public Action<DirectoryInfo> _0024VB_0024Local_SearchFolder;

		public ModLoader.LoaderTask<int, List<ModLocalComp.LocalCompFile>> _0024VB_0024Local_Loader;

		public int _0024VB_0024Local_Progress;

		public _Closure_0024__24_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__24_002D1(_Closure_0024__24_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SearchFolder = arg0._0024VB_0024Local_SearchFolder;
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_Progress = arg0._0024VB_0024Local_Progress;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(DirectoryInfo Folder)
		{
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
			try
			{
				enumerator = Folder.EnumerateDirectories("*", (SearchOption)0).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					DirectoryInfo current = enumerator.Current;
					if ((Operators.CompareString(((FileSystemInfo)Folder).FullName, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, false) != 0 || !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "assets", "versions", "libraries" }, current.Name)) && !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }, current.Name))
					{
						_0024VB_0024Local_SearchFolder.Invoke(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			checked
			{
				System.Collections.Generic.IEnumerator<FileInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<FileInfo>);
				try
				{
					enumerator2 = Folder.EnumerateFiles("*", (SearchOption)0).GetEnumerator();
					_Closure_0024__24_002D2 closure_0024__24_002D = default(_Closure_0024__24_002D2);
					System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						FileInfo current2 = enumerator2.Current;
						closure_0024__24_002D = new _Closure_0024__24_002D2(closure_0024__24_002D)
						{
							_0024VB_0024Local_RelativePath = ModBase.AfterFirst(((FileSystemInfo)current2).FullName, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie)
						};
						bool flag = false;
						try
						{
							enumerator3 = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								string current3 = enumerator3.Current;
								bool flag2 = current3.StartsWith("!");
								if (LikeOperator.LikeString(closure_0024__24_002D._0024VB_0024Local_RelativePath, current3.TrimStart('!'), (CompareMethod)0))
								{
									flag = !flag2;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator3).Dispose();
						}
						if (flag)
						{
							string text = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + closure_0024__24_002D._0024VB_0024Local_RelativePath;
							ModBase.CopyFile(((FileSystemInfo)current2).FullName, text);
							if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { ".zip", ".rar", ".jar", ".disabled", ".old" }, ((FileSystemInfo)current2).Extension.ToLower()) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "mods", "packs", "openloader", "resource" }, (Func<string, bool>)closure_0024__24_002D._Lambda_0024__2))
							{
								ModLocalComp.LocalCompFile localCompFile = new ModLocalComp.LocalCompFile(text);
								_ = localCompFile.ModrinthHash;
								Conversions.ToString(localCompFile.CurseForgeHash);
								_0024VB_0024Local_Loader.Output.Add(localCompFile);
							}
							_0024VB_0024Local_Progress++;
							if (_0024VB_0024Local_Progress == 25)
							{
								_0024VB_0024Local_Loader.Progress += (0.94 - _0024VB_0024Local_Loader.Progress) * 0.012;
								_0024VB_0024Local_Progress = 0;
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D2
	{
		public string _0024VB_0024Local_RelativePath;

		public _Closure_0024__24_002D2(_Closure_0024__24_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_RelativePath = arg0._0024VB_0024Local_RelativePath;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(string s)
		{
			return _0024VB_0024Local_RelativePath.Contains(s);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D3
	{
		public ModLoader.LoaderTask<List<ModLocalComp.LocalCompFile>, Dictionary<ModLocalComp.LocalCompFile, List<string>>> _0024VB_0024Local_Loader;

		public List<System.Exception> _0024VB_0024Local_FailedExceptions;

		public int _0024VB_0024Local_EndedThreadCount;

		public _Closure_0024__24_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__24_002D3(_Closure_0024__24_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_FailedExceptions = arg0._0024VB_0024Local_FailedExceptions;
				_0024VB_0024Local_EndedThreadCount = arg0._0024VB_0024Local_EndedThreadCount;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					System.Collections.Generic.IEnumerable<string> list = Enumerable.Select<ModLocalComp.LocalCompFile, string>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.ModrinthHash));
					JObject jObject = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", (object)ModBase.Join((System.Collections.IEnumerable)list, "\",\"")), "application/json"));
					System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
					try
					{
						enumerator = _0024VB_0024Local_Loader.Input.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ModLocalComp.LocalCompFile current = enumerator.Current;
							if (jObject.ContainsKey(current.ModrinthHash) && !((string?)jObject[current.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != current.ModrinthHash))
							{
								ModBase.AddToList(_0024VB_0024Local_Loader.Output, current, (string?)jObject[current.ModrinthHash]["files"][0]["url"]);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					ModBase.Log($"[Export] 从 Modrinth 获取到 {jObject.Count} 个本地资源项的对应信息");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 Modrinth 获取本地 Mod 信息失败");
					_0024VB_0024Local_FailedExceptions.Add(ex2);
					ProjectData.ClearProjectError();
				}
				finally
				{
					_0024VB_0024Local_EndedThreadCount++;
					_0024VB_0024Local_Loader.Progress += 0.45;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__6()
		{
			checked
			{
				try
				{
					if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
					{
						return;
					}
					System.Collections.Generic.IEnumerable<uint> list = Enumerable.Select<ModLocalComp.LocalCompFile, uint>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, uint>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.CurseForgeHash));
					JContainer jContainer = (JContainer)((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432/", "POST", string.Format("{{\"fingerprints\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)list, ",")), "application/json")))["data"]["exactMatches"];
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
						_Closure_0024__24_002D4 closure_0024__24_002D = default(_Closure_0024__24_002D4);
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JObject jObject = (JObject)enumerator.Current;
							closure_0024__24_002D = new _Closure_0024__24_002D4(closure_0024__24_002D);
							if (!jObject.ContainsKey("file"))
							{
								continue;
							}
							closure_0024__24_002D._0024VB_0024Local_File = (JObject)jObject["file"];
							if (!string.IsNullOrEmpty((string?)closure_0024__24_002D._0024VB_0024Local_File["downloadUrl"]))
							{
								ModLocalComp.LocalCompFile localCompFile = Enumerable.FirstOrDefault<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, bool>)closure_0024__24_002D._Lambda_0024__8);
								if (localCompFile != null)
								{
									ModBase.AddToList(_0024VB_0024Local_Loader.Output, localCompFile, ModComp.CompFile.HandleCurseForgeDownloadUrls(closure_0024__24_002D._0024VB_0024Local_File["downloadUrl"].ToString()));
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					ModBase.Log($"[Export] 从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 CurseForge 获取本地 Mod 信息失败");
					_0024VB_0024Local_FailedExceptions.Add(ex2);
					ProjectData.ClearProjectError();
				}
				finally
				{
					_0024VB_0024Local_EndedThreadCount++;
					_0024VB_0024Local_Loader.Progress += 0.45;
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D4
	{
		public JObject _0024VB_0024Local_File;

		public _Closure_0024__24_002D4(_Closure_0024__24_002D4 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_File = arg0._0024VB_0024Local_File;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__8(ModLocalComp.LocalCompFile m)
		{
			return m.CurseForgeHash == _0024VB_0024Local_File["fileFingerprint"].ToObject<uint>();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public FileInfo _0024VB_0024Local_File;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_File = arg0._0024VB_0024Local_File;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string b)
		{
			return ModBase.ContainsF(_0024VB_0024Local_File.Name, b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D1
	{
		public DirectoryInfo _0024VB_0024Local_SubFolder;

		public _Closure_0024__6_002D1(_Closure_0024__6_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(string b)
		{
			return ModBase.ContainsF(_0024VB_0024Local_SubFolder.Name, b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D0
	{
		public FileSystemInfo _0024VB_0024Local_i;

		public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(string b)
		{
			return ModBase.ContainsF(_0024VB_0024Local_i.Name, b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D1
	{
		public DirectoryInfo _0024VB_0024Local_SubFolder;

		public _Closure_0024__7_002D1(_Closure_0024__7_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SubFolder = arg0._0024VB_0024Local_SubFolder;
			}
		}

		[SpecialName]
		internal string _Lambda_0024__4(FileInfo f)
		{
			return $"{_0024VB_0024Local_SubFolder.Name}\\{f.Name}";
		}

		[SpecialName]
		internal string _Lambda_0024__5(DirectoryInfo d)
		{
			return $"{_0024VB_0024Local_SubFolder.Name}\\{d.Name}\\";
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D2
	{
		public List<string> _0024VB_0024Local_AllEntries;

		public VB_0024AnonymousDelegate_20<DirectoryInfo, bool> _0024VB_0024Local_IsValidDirectory;

		public PageInstanceExport _0024VB_0024Me;

		public Func<string, bool> _0024I7;

		public _Closure_0024__7_002D2(_Closure_0024__7_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_AllEntries = arg0._0024VB_0024Local_AllEntries;
				_0024VB_0024Local_IsValidDirectory = arg0._0024VB_0024Local_IsValidDirectory;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(ExportOption TargetOption)
		{
			if (TargetOption.RequireOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine)
			{
				return false;
			}
			if (TargetOption.RequireModLoader && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			if (TargetOption.RequireModLoaderOrOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			return Enumerable.Any<string>(_0024VB_0024Me.StandardizeLines((TargetOption.Rules ?? TargetOption.ShowRules).Split('|', (StringSplitOptions)0), AddSuffixStarToFolderPath: true), (Func<string, bool>)([SpecialName] (string Rule) =>
			{
				//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Expected O, but got Unknown
				_Closure_0024__7_002D3 arg = default(_Closure_0024__7_002D3);
				_Closure_0024__7_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__7_002D3(null)
				{
					_0024VB_0024Local_Rule = Rule
				};
				bool result;
				if (ModBase.StartsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, "!"))
				{
					result = false;
				}
				else
				{
					try
					{
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_AllEntries, (Func<string, bool>)([SpecialName] (string Entry) => LikeOperator.LikeString(Entry, CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, (CompareMethod)0))))
						{
							result = true;
							goto IL_010e;
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"错误的规则：{CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule}", ModBase.LogLevel.Hint);
						result = false;
						ProjectData.ClearProjectError();
						goto IL_010e;
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
					result = Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule.Split(new char[] { '\\' }, (StringSplitOptions)1)) >= 3 && ((!ModBase.EndsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, "\\")) ? File.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule) : _0024VB_0024Local_IsValidDirectory(new DirectoryInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule)));
				}
				goto IL_010e;
				IL_010e:
				return result;
			}));
		}

		[SpecialName]
		internal bool _Lambda_0024__7(string Rule)
		{
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Expected O, but got Unknown
			_Closure_0024__7_002D3 arg = default(_Closure_0024__7_002D3);
			_Closure_0024__7_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__7_002D3(null)
			{
				_0024VB_0024Local_Rule = Rule
			};
			bool result;
			if (ModBase.StartsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, "!"))
			{
				result = false;
			}
			else
			{
				try
				{
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_AllEntries, (Func<string, bool>)([SpecialName] (string Entry) => LikeOperator.LikeString(Entry, CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, (CompareMethod)0))))
					{
						result = true;
						goto IL_010e;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, $"错误的规则：{CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule}", ModBase.LogLevel.Hint);
					result = false;
					ProjectData.ClearProjectError();
					goto IL_010e;
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
				result = Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule.Split(new char[] { '\\' }, (StringSplitOptions)1)) >= 3 && ((!ModBase.EndsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule, "\\")) ? File.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule) : _0024VB_0024Local_IsValidDirectory(new DirectoryInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals0._0024VB_0024Local_Rule)));
			}
			goto IL_010e;
			IL_010e:
			return result;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D3
	{
		public string _0024VB_0024Local_Rule;

		public _Closure_0024__7_002D3(_Closure_0024__7_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Rule = arg0._0024VB_0024Local_Rule;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__8(string Entry)
		{
			return LikeOperator.LikeString(Entry, _0024VB_0024Local_Rule, (CompareMethod)0);
		}
	}

	private string CurrentVersion;

	private string[] SubOptionBlackList;

	private const string Sperator = "==============================================================";

	private List<string> _RulesOverrides;

	private List<string> ExtraFiles;

	private string ConfigPackPath;

	[CompilerGenerated]
	[AccessedThroughProperty("TextExportName")]
	private MyTextBox _TextExportName;

	[CompilerGenerated]
	[AccessedThroughProperty("CardOptions")]
	private MyCard _CardOptions;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvancedInclude")]
	private MyCheckBox _CheckAdvancedInclude;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvancedModrinth")]
	private MyCheckBox _CheckAdvancedModrinth;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAdvancedImport")]
	private MyButton _BtnAdvancedImport;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAdvancedExport")]
	private MyButton _BtnAdvancedExport;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExport")]
	private MyExtraTextButton _BtnExport;

	private bool _contentLoaded;

	private List<string> RulesOverrides
	{
		get
		{
			return _RulesOverrides;
		}
		set
		{
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			_RulesOverrides = value;
			if (value == null)
			{
				((UIElement)BtnOverrideCancel).Visibility = (Visibility)2;
				((UIElement)PanOptions).Visibility = (Visibility)0;
				((TextElementCollection<Inline>)(object)CardOptions.Inlines).Clear();
				((TextElementCollection<Inline>)(object)CardOptions.Inlines).Add((Inline)new Run("导出内容列表")
				{
					FontWeight = FontWeights.Bold
				});
			}
			else
			{
				((UIElement)BtnOverrideCancel).Visibility = (Visibility)0;
				((UIElement)PanOptions).Visibility = (Visibility)2;
				((TextElementCollection<Inline>)(object)CardOptions.Inlines).Clear();
				((TextElementCollection<Inline>)(object)CardOptions.Inlines).Add((Inline)new Run("导出内容列表:\u200a\u200a\u200a\u200a")
				{
					FontWeight = FontWeights.Bold
				});
				((TextElementCollection<Inline>)(object)CardOptions.Inlines).Add((Inline)new Run("从配置文件中读取")
				{
					FontWeight = FontWeights.Normal
				});
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyScrollViewer PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintOptiFine")]
	internal virtual MyHint HintOptiFine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextExportName
	{
		[CompilerGenerated]
		get
		{
			return _TextExportName;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				TextExportName_GotFocus();
			});
			MyTextBox textExportName = _TextExportName;
			if (textExportName != null)
			{
				((UIElement)textExportName).GotFocus -= val;
			}
			_TextExportName = value;
			textExportName = _TextExportName;
			if (textExportName != null)
			{
				((UIElement)textExportName).GotFocus += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextExportVersion")]
	internal virtual MyTextBox TextExportVersion
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardOptions
	{
		[CompilerGenerated]
		get
		{
			return _CardOptions;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				CardOptions_MouseLeftButtonDown();
			});
			MyCard cardOptions = _CardOptions;
			if (cardOptions != null)
			{
				((UIElement)cardOptions).MouseLeftButtonDown -= val;
			}
			_CardOptions = value;
			cardOptions = _CardOptions;
			if (cardOptions != null)
			{
				((UIElement)cardOptions).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnOverrideCancel")]
	internal virtual MyIconTextButton BtnOverrideCancel
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptions")]
	internal virtual StackPanel PanOptions
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsBasic")]
	internal virtual MyCheckBox CheckOptionsBasic
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsOptions")]
	internal virtual MyCheckBox CheckOptionsOptions
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsMod")]
	internal virtual MyCheckBox CheckOptionsMod
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsResourcePacks")]
	internal virtual MyCheckBox CheckOptionsResourcePacks
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptionsResourcePacks")]
	internal virtual StackPanel PanOptionsResourcePacks
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsShaderPacks")]
	internal virtual MyCheckBox CheckOptionsShaderPacks
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptionsShaderPacks")]
	internal virtual StackPanel PanOptionsShaderPacks
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsSaves")]
	internal virtual MyCheckBox CheckOptionsSaves
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptionsSaves")]
	internal virtual StackPanel PanOptionsSaves
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsPcl")]
	internal virtual MyCheckBox CheckOptionsPcl
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckOptionsPclCustom")]
	internal virtual MyCheckBox CheckOptionsPclCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckAdvancedInclude
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvancedInclude;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = CheckAdvancedInclude_Change;
			MyCheckBox checkAdvancedInclude = _CheckAdvancedInclude;
			if (checkAdvancedInclude != null)
			{
				checkAdvancedInclude.Change -= obj;
			}
			_CheckAdvancedInclude = value;
			checkAdvancedInclude = _CheckAdvancedInclude;
			if (checkAdvancedInclude != null)
			{
				checkAdvancedInclude.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvancedModrinth
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvancedModrinth;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = CheckAdvancedModrinth_Change;
			MyCheckBox checkAdvancedModrinth = _CheckAdvancedModrinth;
			if (checkAdvancedModrinth != null)
			{
				checkAdvancedModrinth.Change -= obj;
			}
			_CheckAdvancedModrinth = value;
			checkAdvancedModrinth = _CheckAdvancedModrinth;
			if (checkAdvancedModrinth != null)
			{
				checkAdvancedModrinth.Change += obj;
			}
		}
	}

	internal virtual MyButton BtnAdvancedImport
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdvancedImport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				ImportConfig();
			};
			MyButton btnAdvancedImport = _BtnAdvancedImport;
			if (btnAdvancedImport != null)
			{
				btnAdvancedImport.Click -= obj;
			}
			_BtnAdvancedImport = value;
			btnAdvancedImport = _BtnAdvancedImport;
			if (btnAdvancedImport != null)
			{
				btnAdvancedImport.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnAdvancedExport
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdvancedExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				ExportConfig();
			};
			MyButton btnAdvancedExport = _BtnAdvancedExport;
			if (btnAdvancedExport != null)
			{
				btnAdvancedExport.Click -= obj;
			}
			_BtnAdvancedExport = value;
			btnAdvancedExport = _BtnAdvancedExport;
			if (btnAdvancedExport != null)
			{
				btnAdvancedExport.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnAdvancedHelp")]
	internal virtual MyButton BtnAdvancedHelp
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyExtraTextButton BtnExport
	{
		[CompilerGenerated]
		get
		{
			return _BtnExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				StartExport();
			};
			MyExtraTextButton btnExport = _BtnExport;
			if (btnExport != null)
			{
				btnExport.Click -= obj;
			}
			_BtnExport = value;
			btnExport = _BtnExport;
			if (btnExport != null)
			{
				btnExport.Click += obj;
			}
		}
	}

	public PageInstanceExport()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			PageInstanceExport_Loaded();
		});
		CurrentVersion = "";
		SubOptionBlackList = new string[] { "Quark Programmer Art.zip", "+ EuphoriaPatches_" };
		_RulesOverrides = null;
		ExtraFiles = null;
		ConfigPackPath = null;
		InitializeComponent();
	}

	private void PageInstanceExport_Loaded()
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (Operators.CompareString(CurrentVersion, PageInstanceLeft.Instance.Path, false) != 0)
			{
				RefreshAll();
			}
			BtnAdvancedHelp.EventData = "指南/整合包制作.json";
			ModAnimation.AniControlEnabled--;
		}
	}

	public void RefreshAll()
	{
		ModBase.Log("[Export] 刷新导出页面");
		((UIElement)HintOptiFine).Visibility = (Visibility)((!PageInstanceLeft.Instance.Version.HasOptiFine) ? 2 : 0);
		CurrentVersion = PageInstanceLeft.Instance.Path;
		((TextBox)TextExportName).Text = "";
		TextExportName.HintText = PageInstanceLeft.Instance.Name;
		((TextBox)TextExportVersion).Text = "";
		TextExportVersion.HintText = "1.0.0";
		CheckAdvancedInclude.Checked = false;
		CheckAdvancedModrinth.Checked = false;
		GetExportOption(CheckOptionsBasic).Description = PageInstanceLeft.Instance.GetDefaultDescription();
		ResetConfigOverrides();
		ReloadAllSubOptions();
		RefreshAllOptionsUI();
		((ScrollViewer)PanBack).ScrollToHome();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshAll
		this.RefreshAll();
	}

	private void ReloadAllSubOptions()
	{
		ReloadSubOptions(PanOptionsResourcePacks, true, true, "resourcepacks", "texturepacks");
		ReloadSubOptions(PanOptionsSaves, false, true, "saves");
		ReloadSubOptions(PanOptionsShaderPacks, true, true, "shaderpacks");
	}

	private void ReloadSubOptions(StackPanel Panel, bool AcceptCompressedFile, bool AcceptFolder, params string[] Folders)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		((Panel)Panel).Children.Clear();
		System.Collections.Generic.IEnumerator<FileInfo> enumerator = default(System.Collections.Generic.IEnumerator<FileInfo>);
		_Closure_0024__6_002D0 closure_0024__6_002D = default(_Closure_0024__6_002D0);
		System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
		_Closure_0024__6_002D1 closure_0024__6_002D2 = default(_Closure_0024__6_002D1);
		foreach (string text in Folders)
		{
			DirectoryInfo val = new DirectoryInfo(PageInstanceLeft.Instance.PathIndie + text);
			if (!val.Exists)
			{
				continue;
			}
			if (AcceptCompressedFile)
			{
				try
				{
					enumerator = Enumerable.Concat<FileInfo>(val.EnumerateFiles("*.zip"), val.EnumerateFiles("*.rar")).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						closure_0024__6_002D = new _Closure_0024__6_002D0(closure_0024__6_002D);
						closure_0024__6_002D._0024VB_0024Local_File = enumerator.Current;
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)SubOptionBlackList, (Func<string, bool>)closure_0024__6_002D._Lambda_0024__0))
						{
							continue;
						}
						UIElementCollection children = ((Panel)Panel).Children;
						MyCheckBox myCheckBox = new MyCheckBox();
						((FrameworkElement)myCheckBox).Tag = new ExportOption
						{
							Title = closure_0024__6_002D._0024VB_0024Local_File.Name,
							DefaultChecked = true,
							Rules = ModBase.EscapeLikePattern($"{text}/{closure_0024__6_002D._0024VB_0024Local_File.Name}")
						};
						children.Add((UIElement)(object)myCheckBox);
						if (Operators.CompareString(text, "shaderpacks", false) == 0)
						{
							FileInfo val2 = new FileInfo(Path.Combine(((FileSystemInfo)closure_0024__6_002D._0024VB_0024Local_File.Directory).FullName, $"{Path.GetFileNameWithoutExtension(closure_0024__6_002D._0024VB_0024Local_File.Name)}.txt"));
							if (val2.Exists)
							{
								UIElementCollection children2 = ((Panel)Panel).Children;
								MyCheckBox myCheckBox2 = new MyCheckBox();
								((FrameworkElement)myCheckBox2).Tag = new ExportOption
								{
									Title = $"{val2.Name} (光影配置文件)",
									DefaultChecked = true,
									Rules = ModBase.EscapeLikePattern($"{text}/{val2.Name}")
								};
								children2.Add((UIElement)(object)myCheckBox2);
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			if (!AcceptFolder)
			{
				continue;
			}
			try
			{
				enumerator2 = ((System.Collections.Generic.IEnumerable<DirectoryInfo>)Enumerable.OrderByDescending<DirectoryInfo, System.DateTime>(val.EnumerateDirectories(), (Func<DirectoryInfo, System.DateTime>)([SpecialName] (DirectoryInfo f) => ((FileSystemInfo)f).LastWriteTime))).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					closure_0024__6_002D2 = new _Closure_0024__6_002D1(closure_0024__6_002D2);
					closure_0024__6_002D2._0024VB_0024Local_SubFolder = enumerator2.Current;
					if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)SubOptionBlackList, (Func<string, bool>)closure_0024__6_002D2._Lambda_0024__2) && Enumerable.Any<FileSystemInfo>(closure_0024__6_002D2._0024VB_0024Local_SubFolder.EnumerateFileSystemInfos()))
					{
						MyCheckBox myCheckBox3 = new MyCheckBox();
						((FrameworkElement)myCheckBox3).Tag = new ExportOption
						{
							Title = closure_0024__6_002D2._0024VB_0024Local_SubFolder.Name,
							DefaultChecked = true,
							Rules = ModBase.EscapeLikePattern($"{text}/{closure_0024__6_002D2._0024VB_0024Local_SubFolder.Name}/")
						};
						MyCheckBox myCheckBox4 = myCheckBox3;
						if (Panel == PanOptionsSaves)
						{
							GetExportOption(myCheckBox4).Description = ((FileSystemInfo)closure_0024__6_002D2._0024VB_0024Local_SubFolder).LastWriteTime.ToString("yyyy'/'MM'/'dd HH':'mm");
						}
						((Panel)Panel).Children.Add((UIElement)(object)myCheckBox4);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
		}
	}

	private void RefreshAllOptionsUI()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		_Closure_0024__7_002D2 arg = default(_Closure_0024__7_002D2);
		_Closure_0024__7_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__7_002D2(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries = new List<string>();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IsValidDirectory = [SpecialName] [CompilerGenerated] (DirectoryInfo Folder) =>
		{
			bool result2;
			try
			{
				result2 = Folder.Exists && Enumerable.Any<FileSystemInfo>(Folder.EnumerateFileSystemInfos(), (Func<FileSystemInfo, bool>)([SpecialName] [CompilerGenerated] (FileSystemInfo i) =>
				{
					_Closure_0024__7_002D0 arg3 = default(_Closure_0024__7_002D0);
					_Closure_0024__7_002D0 CS_0024_003C_003E8__locals2 = new _Closure_0024__7_002D0(null);
					CS_0024_003C_003E8__locals2._0024VB_0024Local_i = i;
					return !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)SubOptionBlackList, (Func<string, bool>)([SpecialName] (string b) => ModBase.ContainsF(CS_0024_003C_003E8__locals2._0024VB_0024Local_i.Name, b)));
				}));
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result2 = false;
				ProjectData.ClearProjectError();
			}
			return result2;
		};
		DirectoryInfo val = new DirectoryInfo(PageInstanceLeft.Instance.PathIndie);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries.AddRange(Enumerable.Select<FileInfo, string>(val.EnumerateFiles(), (Func<FileInfo, string>)([SpecialName] (FileInfo f) => f.Name)));
		System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
		try
		{
			System.Collections.Generic.IEnumerable<DirectoryInfo> enumerable = val.EnumerateDirectories();
			VB_0024AnonymousDelegate_20<DirectoryInfo, bool> _0024VB_0024Local_IsValidDirectory = CS_0024_003C_003E8__locals0._0024VB_0024Local_IsValidDirectory;
			enumerator = Enumerable.Where<DirectoryInfo>(enumerable, (_0024VB_0024Local_IsValidDirectory == null) ? null : new Func<DirectoryInfo, bool>(_0024VB_0024Local_IsValidDirectory.Invoke)).GetEnumerator();
			_Closure_0024__7_002D1 closure_0024__7_002D = default(_Closure_0024__7_002D1);
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				closure_0024__7_002D = new _Closure_0024__7_002D1(closure_0024__7_002D);
				closure_0024__7_002D._0024VB_0024Local_SubFolder = enumerator.Current;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries.Add($"{closure_0024__7_002D._0024VB_0024Local_SubFolder.Name}\\");
				CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries.AddRange(Enumerable.Select<FileInfo, string>(closure_0024__7_002D._0024VB_0024Local_SubFolder.EnumerateFiles(), (Func<FileInfo, string>)closure_0024__7_002D._Lambda_0024__4));
				List<string> _0024VB_0024Local_AllEntries = CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries;
				System.Collections.Generic.IEnumerable<DirectoryInfo> enumerable2 = closure_0024__7_002D._0024VB_0024Local_SubFolder.EnumerateDirectories();
				_0024VB_0024Local_IsValidDirectory = CS_0024_003C_003E8__locals0._0024VB_0024Local_IsValidDirectory;
				_0024VB_0024Local_AllEntries.AddRange(Enumerable.Select<DirectoryInfo, string>(Enumerable.Where<DirectoryInfo>(enumerable2, (_0024VB_0024Local_IsValidDirectory == null) ? null : new Func<DirectoryInfo, bool>(_0024VB_0024Local_IsValidDirectory.Invoke)), (Func<DirectoryInfo, string>)closure_0024__7_002D._Lambda_0024__5));
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		ModBase.Log($"[Export] 共发现 {CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries.Count} 个可行的二级文件/文件夹");
		VB_0024AnonymousDelegate_21<ExportOption, bool> vB_0024AnonymousDelegate_ = [SpecialName] (ExportOption TargetOption) =>
		{
			if (TargetOption.RequireOptiFine && !PageInstanceLeft.Instance.Version.HasOptiFine)
			{
				return false;
			}
			if (TargetOption.RequireModLoader && !PageInstanceLeft.Instance.Modable)
			{
				return false;
			}
			return (!TargetOption.RequireModLoaderOrOptiFine || PageInstanceLeft.Instance.Version.HasOptiFine || PageInstanceLeft.Instance.Modable) && Enumerable.Any<string>(CS_0024_003C_003E8__locals0._0024VB_0024Me.StandardizeLines((TargetOption.Rules ?? TargetOption.ShowRules).Split('|', (StringSplitOptions)0), AddSuffixStarToFolderPath: true), (Func<string, bool>)([SpecialName] (string Rule) =>
			{
				//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Expected O, but got Unknown
				_Closure_0024__7_002D3 arg2 = default(_Closure_0024__7_002D3);
				_Closure_0024__7_002D3 CS_0024_003C_003E8__locals1 = new _Closure_0024__7_002D3(null);
				CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule = Rule;
				bool result;
				if (ModBase.StartsWithF(CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule, "!"))
				{
					result = false;
				}
				else
				{
					try
					{
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_AllEntries, (Func<string, bool>)([SpecialName] (string Entry) => LikeOperator.LikeString(Entry, CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule, (CompareMethod)0))))
						{
							result = true;
							goto IL_010e;
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"错误的规则：{CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule}", ModBase.LogLevel.Hint);
						result = false;
						ProjectData.ClearProjectError();
						goto IL_010e;
					}
					CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule = CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule.Trim("*?".ToCharArray());
					result = Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule.Split(new char[] { '\\' }, (StringSplitOptions)1)) >= 3 && ((!ModBase.EndsWithF(CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule, "\\")) ? File.Exists(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule) : CS_0024_003C_003E8__locals0._0024VB_0024Local_IsValidDirectory(new DirectoryInfo(PageInstanceLeft.Instance.PathIndie + CS_0024_003C_003E8__locals1._0024VB_0024Local_Rule)));
				}
				goto IL_010e;
				IL_010e:
				return result;
			}));
		};
		System.Collections.Generic.IEnumerator<MyCheckBox> enumerator2 = default(System.Collections.Generic.IEnumerator<MyCheckBox>);
		try
		{
			enumerator2 = GetAllOptions(IncludeHidden: true).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				MyCheckBox current = enumerator2.Current;
				ExportOption exportOption = GetExportOption(current);
				((TextElementCollection<Inline>)(object)current.Inlines).Clear();
				((TextElementCollection<Inline>)(object)current.Inlines).Add((Inline)new Run(exportOption.Title));
				if (!string.IsNullOrEmpty(exportOption.Description))
				{
					((TextElementCollection<Inline>)(object)current.Inlines).Add((Inline)new Run("   " + exportOption.Description)
					{
						Foreground = ModSecret.ColorGray5
					});
				}
				if (string.IsNullOrEmpty(exportOption.Rules) && string.IsNullOrEmpty(exportOption.ShowRules))
				{
					((UIElement)current).Visibility = (Visibility)0;
					current.Checked = exportOption.DefaultChecked;
				}
				else
				{
					bool flag = vB_0024AnonymousDelegate_(exportOption);
					((UIElement)current).Visibility = (Visibility)((!flag) ? 2 : 0);
					current.Checked = exportOption.DefaultChecked && flag;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
	}

	[IteratorStateMachine(typeof(VB_0024StateMachine_8_StandardizeLines))]
	private System.Collections.Generic.IEnumerable<string> StandardizeLines(System.Collections.Generic.IEnumerable<string> Raw, bool AddSuffixStarToFolderPath)
	{
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Raw.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				current = current.Trim();
				if (Operators.CompareString(current, "", false) != 0 && !ModBase.StartsWithF(current, "#") && !ModBase.StartsWithF(current, "="))
				{
					current = current.Replace("/", "\\");
					yield return current + ((ModBase.EndsWithF(current, "\\") && AddSuffixStarToFolderPath) ? "*" : "");
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
	}

	[IteratorStateMachine(typeof(VB_0024StateMachine_9_GetAllOptions))]
	private System.Collections.Generic.IEnumerable<MyCheckBox> GetAllOptions(bool IncludeHidden)
	{
		foreach (object child in ((Panel)PanOptions).Children)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(child);
			if (!IncludeHidden && Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue, (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false))
			{
				continue;
			}
			if (objectValue is MyCheckBox)
			{
				yield return (MyCheckBox)objectValue;
			}
			else
			{
				if (!(objectValue is StackPanel))
				{
					continue;
				}
				foreach (object child2 in ((Panel)(StackPanel)objectValue).Children)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(child2);
					if ((IncludeHidden || !Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false)) && objectValue2 is MyCheckBox)
					{
						yield return (MyCheckBox)objectValue2;
					}
				}
			}
		}
	}

	private ExportOption GetExportOption(MyCheckBox CheckBox)
	{
		return (ExportOption)((FrameworkElement)CheckBox).Tag;
	}

	[IteratorStateMachine(typeof(VB_0024StateMachine_16_GetAllRules))]
	private System.Collections.Generic.IEnumerable<string> GetAllRules()
	{
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		if (RulesOverrides != null)
		{
			try
			{
				enumerator = RulesOverrides.GetEnumerator();
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
				yield break;
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		yield return "";
		yield return "# 修改下方的规则以控制需要导出的内容。";
		yield return "# 以 ! 开头以反选。可以使用 *、?、[] 通配符。靠后的行覆盖靠前的。";
		yield return "";
		System.Collections.Generic.IEnumerator<MyCheckBox> enumerator2 = default(System.Collections.Generic.IEnumerator<MyCheckBox>);
		try
		{
			enumerator2 = GetAllOptions(IncludeHidden: false).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				MyCheckBox current = enumerator2.Current;
				bool? @checked = current.Checked;
				if (((!@checked) ?? @checked).GetValueOrDefault())
				{
					continue;
				}
				ExportOption exportOption = GetExportOption(current);
				if (exportOption.Rules != null)
				{
					yield return $"# {exportOption.Title}";
					string[] array = exportOption.Rules.Split('|', (StringSplitOptions)0);
					for (int i = 0; i < array.Length; i = checked(i + 1))
					{
						yield return array[i];
					}
					yield return "";
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		yield return "# 排除的文件";
		yield return "!*.log";
		yield return "!*.dat_old";
		yield return "!*.BakaCoreInfo";
		yield return "!hmclversion.cfg";
		yield return "!log4j2.xml";
		yield return "";
	}

	[IteratorStateMachine(typeof(VB_0024StateMachine_18_GetExtraFileLines))]
	private System.Collections.Generic.IEnumerable<string> GetExtraFileLines()
	{
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		if (ExtraFiles != null)
		{
			try
			{
				enumerator = ExtraFiles.GetEnumerator();
				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
				yield break;
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		yield return "";
		yield return "# 如果想将额外的文件自动放到压缩包根目录中，可以将它们的路径写在下方。";
		yield return "# 必须是完整路径。每行中，若以 \\ 结尾则代表是文件夹，不以 \\ 结尾则代表是文件。";
		yield return "";
	}

	private void ResetConfigOverrides()
	{
		RulesOverrides = null;
		ConfigPackPath = null;
		ExtraFiles = null;
		((ScrollViewer)PanBack).ScrollToHome();
	}

	private void CardOptions_MouseLeftButtonDown()
	{
		if (RulesOverrides != null)
		{
			ResetConfigOverrides();
		}
	}

	private void ExportConfig()
	{
		try
		{
			string text = SystemDialogs.SelectSaveFile("选择文件位置", "export_config.txt", "整合包导出配置(*.txt)|*.txt", Conversions.ToString(ModBase.Setup.Get("CacheExportConfig")));
			if (!string.IsNullOrEmpty(text))
			{
				ModBase.Setup.Set("CacheExportConfig", text);
				List<string> val = new List<string>();
				val.Add("Name:" + ((TextBox)TextExportName).Text);
				val.Add("Version:" + ((TextBox)TextExportVersion).Text);
				val.Add("");
				val.Add("# 是否打包正式版 PCL，以便没有启动器的玩家安装整合包。");
				bool? @checked;
				bool? flag = (@checked = CheckOptionsPcl.Checked);
				val.Add("IncludeLauncher:" + (flag.HasValue ? Conversions.ToString(@checked.GetValueOrDefault()) : null));
				val.Add("");
				val.Add("# 是否打包 PCL 个性化内容，例如功能隐藏设置、主页、背景音乐和图片等。");
				flag = (@checked = CheckOptionsPclCustom.Checked);
				val.Add("IncludeLauncherCustom:" + (flag.HasValue ? Conversions.ToString(@checked.GetValueOrDefault()) : null));
				val.Add("");
				val.Add("# 是否将 Mod、资源包、光影包的文件直接放入整合包中，这样在导入时就无需联网下载它们。");
				val.Add("# 建议仅在无法稳定连接 CurseForge 或 Modrinth 时才考虑启用。");
				val.Add("# 二次分发可能违反使用协议，请尽量不要公开发布包含资源文件的整合包！");
				flag = (@checked = CheckAdvancedInclude.Checked);
				val.Add("DontCheckHostedAssets:" + (flag.HasValue ? Conversions.ToString(@checked.GetValueOrDefault()) : null));
				val.Add("");
				val.Add("# 如果你想要打包上传到 Modrinth，启用此项会生成完全符合 Modrinth 要求的整合包文件。");
				val.Add("# 由于 Modrinth 要求，只能从 CurseForge 下载的资源将无法联网下载，会被直接放入整合包中。");
				val.Add("# 此选项与 IncludeLauncher、IncludeLauncherCustom、DontCheckHostedAssets 冲突。");
				flag = (@checked = CheckAdvancedModrinth.Checked);
				val.Add("ModrinthUploadMode:" + (flag.HasValue ? Conversions.ToString(@checked.GetValueOrDefault()) : null));
				val.Add("");
				val.Add("# 导出的文件的存放位置。");
				val.Add("# 若设置了此项，在导出时会直接将文件放到此路径，不会弹窗要求选择。");
				val.Add("# 若 IncludeLauncher 为 True，应以 .zip 结尾；若为 False，应以 .mrpack 结尾。");
				val.Add("PackPath:" + ConfigPackPath);
				val.Add("");
				val.Add("==============================================================");
				val.AddRange(GetAllRules());
				val.Add("==============================================================");
				val.AddRange(GetExtraFileLines());
				ModBase.WriteFile(text, ModBase.Join((System.Collections.IEnumerable)val, "\r\n"));
				ModMain.Hint("已保存配置文件：" + text, ModMain.HintType.Finish);
				ModBase.OpenExplorer(text);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "保存配置失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void ImportConfig()
	{
		checked
		{
			try
			{
				string text = SystemDialogs.SelectFile("整合包导出配置(*.txt)|*.txt", "选择配置文件", Conversions.ToString(ModBase.Setup.Get("CacheExportConfig")));
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				ModBase.Setup.Set("CacheExportConfig", text);
				string[] array = ModBase.ReadFile(text).Split("==============================================================", (StringSplitOptions)0);
				Dictionary<string, string> val = new Dictionary<string, string>();
				string[] array2 = array[0].Split("\r\n".ToCharArray());
				for (int i = 0; i < array2.Length; i++)
				{
					string text2 = array2[i];
					text2 = text2.Trim();
					if (Operators.CompareString(text2, "", false) != 0 && !ModBase.StartsWithF(text2, "#") && !ModBase.StartsWithF(text2, "="))
					{
						int num = ModBase.IndexOfF(text2, ":");
						if (num > 0)
						{
							val[text2.Substring(0, num)] = text2.Substring(num + 1);
						}
					}
				}
				((TextBox)TextExportName).Text = ModBase.GetOrDefault(val, "Name", "");
				((TextBox)TextExportVersion).Text = ModBase.GetOrDefault(val, "Version", "");
				CheckOptionsPcl.Checked = Conversions.ToBoolean(ModBase.GetOrDefault(val, "IncludeLauncher", Conversions.ToString(true)));
				CheckOptionsPclCustom.Checked = Conversions.ToBoolean(ModBase.GetOrDefault(val, "IncludeLauncherCustom", Conversions.ToString(true)));
				CheckAdvancedModrinth.Checked = Conversions.ToBoolean(ModBase.GetOrDefault(val, "ModrinthUploadMode", Conversions.ToString(false)));
				CheckAdvancedInclude.Checked = Conversions.ToBoolean(ModBase.GetOrDefault(val, "DontCheckHostedAssets", Conversions.ToString(false)));
				ConfigPackPath = ModBase.GetOrDefault<string, string>(val, "PackPath");
				RulesOverrides = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)array[1].Replace("\r", "\n").Replace("\n\n", "\n").Split("\n", (StringSplitOptions)0));
				if (array.Length > 2)
				{
					ExtraFiles = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)array[2].Replace("\r", "\n").Replace("\n\n", "\n").Split("\n", (StringSplitOptions)0));
				}
				else
				{
					ExtraFiles = null;
				}
				ModMain.Hint("已读取配置文件：" + text, ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取配置失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void StartExport()
	{
		_Closure_0024__24_002D0 arg = default(_Closure_0024__24_002D0);
		_Closure_0024__24_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_PackName = (string.IsNullOrEmpty(((TextBox)TextExportName).Text) ? TextExportName.HintText : ((TextBox)TextExportName).Text);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_PackVersion = (string.IsNullOrEmpty(((TextBox)TextExportVersion).Text) ? "1.0.0" : ((TextBox)TextExportVersion).Text);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = "导出整合包：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_PackName;
		System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
		try
		{
			enumerator = ModLoader.LoaderTaskbar.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				if (Operators.CompareString(enumerator.Current.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, false) == 0)
				{
					ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
					return;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath = null;
		if (!string.IsNullOrWhiteSpace(ConfigPackPath) && !ModBase.EndsWithF(ConfigPackPath, "\\") && !ModBase.EndsWithF(ConfigPackPath, "/"))
		{
			try
			{
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(ConfigPackPath));
				CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath = ConfigPackPath;
				ModBase.Log($"[Export] 使用配置文件中指定的导出路径：{ConfigPackPath}");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"无法使用配置文件中指定的导出路径（{ConfigPackPath}）");
				if (ModMain.MyMsgBox(string.Format("指定的路径：{0}{1}{2}{3}", new object[4]
				{
					ConfigPackPath,
					"\r\n",
					"\r\n",
					ex2.ToString()
				}), "无法使用配置文件中指定的导出路径", "确定", "取消") == 2)
				{
					ProjectData.ClearProjectError();
					return;
				}
				ProjectData.ClearProjectError();
			}
		}
		bool? @checked;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath == null)
		{
			List<string> val = new List<string>();
			@checked = CheckAdvancedModrinth.Checked;
			if (((!@checked) ?? @checked).GetValueOrDefault())
			{
				val.Add("压缩文件(*.zip)|*.zip");
			}
			@checked = CheckOptionsPcl.Checked;
			if (((!@checked) ?? @checked).GetValueOrDefault())
			{
				val.Add("Modrinth 整合包文件(*.mrpack)|*.mrpack");
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath = SystemDialogs.SelectSaveFile("选择导出位置", CS_0024_003C_003E8__locals0._0024VB_0024Local_PackName + (string.IsNullOrEmpty(((TextBox)TextExportVersion).Text) ? "" : (" " + ((TextBox)TextExportVersion).Text)), ModBase.Join((System.Collections.IEnumerable)val, "|"));
			ModBase.Log($"[Export] 手动指定的导出路径：{CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath}");
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath))
		{
			return;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder = ModMain.RequestTaskTempFolder();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_OverridesFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\overrides\\";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance = PageInstanceLeft.Instance;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_PathIndie = CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.PathIndie;
		_Closure_0024__24_002D0 closure_0024__24_002D = CS_0024_003C_003E8__locals0;
		@checked = CheckAdvancedInclude.Checked;
		closure_0024__24_002D._0024VB_0024Local_CheckHostedAssets = ((!@checked) ?? @checked).Value;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthUploadMode = CheckAdvancedModrinth.Checked.Value;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCL = CheckOptionsPcl.Checked.Value;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCLCustom = (CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCL ? CheckOptionsPclCustom.Checked : new bool?(false)).Value;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_AllRules = Enumerable.ToList<string>(StandardizeLines(GetAllRules(), AddSuffixStarToFolderPath: true));
		CS_0024_003C_003E8__locals0._0024VB_0024Local_AllExtraFiles = Enumerable.ToList<string>(StandardizeLines(GetExtraFileLines(), AddSuffixStarToFolderPath: false));
		ModBase.Log($"[Export] 准备导出整合包，共有 {CS_0024_003C_003E8__locals0._0024VB_0024Local_AllRules.Count} 条规则，{CS_0024_003C_003E8__locals0._0024VB_0024Local_AllExtraFiles.Count} 条追加内容行");
		List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
		checked
		{
			val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, List<ModLocalComp.LocalCompFile>>("复制导出内容", [SpecialName] (ModLoader.LoaderTask<int, List<ModLocalComp.LocalCompFile>> Loader) =>
			{
				//IL_004a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0054: Expected O, but got Unknown
				//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
				//IL_00be: Unknown result type (might be due to invalid IL or missing references)
				_Closure_0024__24_002D1 arg3 = default(_Closure_0024__24_002D1);
				_Closure_0024__24_002D1 CS_0024_003C_003E8__locals2 = new _Closure_0024__24_002D1(null);
				CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader = Loader;
				CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Output = new List<ModLocalComp.LocalCompFile>();
				CS_0024_003C_003E8__locals2._0024VB_0024Local_Progress = 0;
				CS_0024_003C_003E8__locals2._0024VB_0024Local_SearchFolder = [SpecialName] (DirectoryInfo Folder) =>
				{
					//IL_0114: Unknown result type (might be due to invalid IL or missing references)
					//IL_0119: Unknown result type (might be due to invalid IL or missing references)
					System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator6 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
					try
					{
						enumerator6 = Folder.EnumerateDirectories("*", (SearchOption)0).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator6).MoveNext())
						{
							DirectoryInfo current4 = enumerator6.Current;
							if ((Operators.CompareString(((FileSystemInfo)Folder).FullName, CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie, false) != 0 || !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "assets", "versions", "libraries" }, current4.Name)) && !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "structureCacheV1", ".fabric", ".git", "avatar-cache", "cosmetic-cache" }, current4.Name))
							{
								CS_0024_003C_003E8__locals2._0024VB_0024Local_SearchFolder.Invoke(current4);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator6)?.Dispose();
					}
					System.Collections.Generic.IEnumerator<FileInfo> enumerator7 = default(System.Collections.Generic.IEnumerator<FileInfo>);
					try
					{
						enumerator7 = Folder.EnumerateFiles("*", (SearchOption)0).GetEnumerator();
						_Closure_0024__24_002D2 closure_0024__24_002D3 = default(_Closure_0024__24_002D2);
						System.Collections.Generic.IEnumerator<string> enumerator8 = default(System.Collections.Generic.IEnumerator<string>);
						while (((System.Collections.IEnumerator)enumerator7).MoveNext())
						{
							FileInfo current5 = enumerator7.Current;
							closure_0024__24_002D3 = new _Closure_0024__24_002D2(closure_0024__24_002D3);
							closure_0024__24_002D3._0024VB_0024Local_RelativePath = ModBase.AfterFirst(((FileSystemInfo)current5).FullName, CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_PathIndie);
							bool flag = false;
							try
							{
								enumerator8 = CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_AllRules.GetEnumerator();
								while (enumerator8.MoveNext())
								{
									string current6 = enumerator8.Current;
									bool flag2 = current6.StartsWith("!");
									if (LikeOperator.LikeString(closure_0024__24_002D3._0024VB_0024Local_RelativePath, current6.TrimStart('!'), (CompareMethod)0))
									{
										flag = !flag2;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator8).Dispose();
							}
							if (flag)
							{
								string text2 = CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_OverridesFolder + closure_0024__24_002D3._0024VB_0024Local_RelativePath;
								ModBase.CopyFile(((FileSystemInfo)current5).FullName, text2);
								if (CS_0024_003C_003E8__locals2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CheckHostedAssets && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { ".zip", ".rar", ".jar", ".disabled", ".old" }, ((FileSystemInfo)current5).Extension.ToLower()) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "mods", "packs", "openloader", "resource" }, (Func<string, bool>)closure_0024__24_002D3._Lambda_0024__2))
								{
									ModLocalComp.LocalCompFile localCompFile2 = new ModLocalComp.LocalCompFile(text2);
									_ = localCompFile2.ModrinthHash;
									Conversions.ToString(localCompFile2.CurseForgeHash);
									CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Output.Add(localCompFile2);
								}
								CS_0024_003C_003E8__locals2._0024VB_0024Local_Progress++;
								if (CS_0024_003C_003E8__locals2._0024VB_0024Local_Progress == 25)
								{
									CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Progress += (0.94 - CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Progress) * 0.012;
									CS_0024_003C_003E8__locals2._0024VB_0024Local_Progress = 0;
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator7)?.Dispose();
					}
				};
				CS_0024_003C_003E8__locals2._0024VB_0024Local_SearchFolder.Invoke(new DirectoryInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_PathIndie));
				ModBase.Log($"[Export] 复制 overrides 文件完成，有 {CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Output.Count} 个文件需要联网检查");
				CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Progress = 0.95;
				string text = (CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCL ? CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder : (CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\"));
				System.Collections.Generic.IEnumerator<string> enumerator5 = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator5 = CS_0024_003C_003E8__locals0._0024VB_0024Local_AllExtraFiles.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						string current3 = enumerator5.Current;
						if (ModBase.EndsWithF(current3, "\\") || ModBase.EndsWithF(current3, "/"))
						{
							if (Directory.Exists(current3))
							{
								ModBase.CopyDirectory(current3, text + ModBase.GetFolderNameFromPath(current3) + "\\");
							}
							else
							{
								ModMain.Hint($"未找到配置文件中指定的文件夹：{current3}", ModMain.HintType.Critical);
							}
						}
						else if (File.Exists(current3))
						{
							ModBase.CopyFile(current3, text + ModBase.GetFileNameFromPath(current3));
						}
						else
						{
							ModMain.Hint($"未找到配置文件中指定的单个文件：{current3}", ModMain.HintType.Critical);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator5).Dispose();
				}
				CS_0024_003C_003E8__locals2._0024VB_0024Local_Loader.Progress = 0.97;
				ModBase.CopyDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Path + "PCL\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_OverridesFolder + "PCL\\");
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCL)
				{
					ModBase.CopyFile(ModBase.ExePathWithName, CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "Plain Craft Launcher.exe");
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCLCustom)
				{
					if (Directory.Exists(ModBase.ExePath + "PCL\\Pictures\\"))
					{
						ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Pictures\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Pictures\\");
					}
					if (Directory.Exists(ModBase.ExePath + "PCL\\Musics\\"))
					{
						ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Musics\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Musics\\");
					}
					if (Directory.Exists(ModBase.ExePath + "PCL\\Help\\"))
					{
						ModBase.CopyDirectory(ModBase.ExePath + "PCL\\Help\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Help\\");
					}
					if (File.Exists(ModBase.ExePath + "PCL\\Custom.xaml"))
					{
						ModBase.CopyFile(ModBase.ExePath + "PCL\\Custom.xaml", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Custom.xaml");
					}
					if (File.Exists(ModBase.ExePath + "PCL\\Setup.ini"))
					{
						ModBase.CopyFile(ModBase.ExePath + "PCL\\Setup.ini", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Setup.ini");
					}
					if (File.Exists(ModBase.ExePath + "PCL\\hints.txt"))
					{
						ModBase.CopyFile(ModBase.ExePath + "PCL\\hints.txt", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\hints.txt");
					}
					if (File.Exists(ModBase.ExePath + "PCL\\Logo.png"))
					{
						ModBase.CopyFile(ModBase.ExePath + "PCL\\Logo.png", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "PCL\\Logo.png");
					}
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 5.0
			});
			val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModLocalComp.LocalCompFile>, Dictionary<ModLocalComp.LocalCompFile, List<string>>>("联网获取文件信息", [SpecialName] (ModLoader.LoaderTask<List<ModLocalComp.LocalCompFile>, Dictionary<ModLocalComp.LocalCompFile, List<string>>> Loader) =>
			{
				//IL_007a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0095: Expected O, but got Unknown
				//IL_009d: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b8: Expected O, but got Unknown
				_Closure_0024__24_002D3 arg2 = default(_Closure_0024__24_002D3);
				_Closure_0024__24_002D3 CS_0024_003C_003E8__locals1 = new _Closure_0024__24_002D3(null);
				CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader = Loader;
				CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Output = new Dictionary<ModLocalComp.LocalCompFile, List<string>>();
				if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_CheckHostedAssets)
				{
					ModBase.Log("[Export] 要求跳过联网获取步骤");
				}
				else if (!Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Input))
				{
					ModBase.Log("[Export] 没有需要联网检查的文件，跳过联网获取步骤");
				}
				else
				{
					CS_0024_003C_003E8__locals1._0024VB_0024Local_EndedThreadCount = 0;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions = new List<System.Exception>();
					ModBase.RunInNewThread((Action)([SpecialName] () =>
					{
						//IL_0075: Unknown result type (might be due to invalid IL or missing references)
						//IL_007a: Unknown result type (might be due to invalid IL or missing references)
						try
						{
							System.Collections.Generic.IEnumerable<string> list2 = Enumerable.Select<ModLocalComp.LocalCompFile, string>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.ModrinthHash));
							JObject jObject4 = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", (object)ModBase.Join((System.Collections.IEnumerable)list2, "\",\"")), "application/json"));
							System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator4 = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
							try
							{
								enumerator4 = CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Input.GetEnumerator();
								while (enumerator4.MoveNext())
								{
									ModLocalComp.LocalCompFile current2 = enumerator4.Current;
									if (jObject4.ContainsKey(current2.ModrinthHash) && !((string?)jObject4[current2.ModrinthHash]?["files"]?[0]["hashes"]?["sha1"] != current2.ModrinthHash))
									{
										ModBase.AddToList(CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Output, current2, (string?)jObject4[current2.ModrinthHash]["files"][0]["url"]);
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator4).Dispose();
							}
							ModBase.Log($"[Export] 从 Modrinth 获取到 {jObject4.Count} 个本地资源项的对应信息");
						}
						catch (System.Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							System.Exception ex6 = ex5;
							ModBase.Log(ex6, "从 Modrinth 获取本地 Mod 信息失败");
							CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions.Add(ex6);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals1._0024VB_0024Local_EndedThreadCount++;
							CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Progress += 0.45;
						}
					}), "Modrinth - " + CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (ThreadPriority)2);
					ModBase.RunInNewThread((Action)([SpecialName] () =>
					{
						try
						{
							if (!CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ModrinthUploadMode)
							{
								System.Collections.Generic.IEnumerable<uint> list = Enumerable.Select<ModLocalComp.LocalCompFile, uint>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, uint>)([SpecialName] (ModLocalComp.LocalCompFile m) => m.CurseForgeHash));
								JContainer jContainer = (JContainer)((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432/", "POST", string.Format("{{\"fingerprints\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)list, ",")), "application/json")))["data"]["exactMatches"];
								System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
								try
								{
									enumerator3 = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
									_Closure_0024__24_002D4 closure_0024__24_002D2 = default(_Closure_0024__24_002D4);
									while (((System.Collections.IEnumerator)enumerator3).MoveNext())
									{
										JObject jObject3 = (JObject)enumerator3.Current;
										closure_0024__24_002D2 = new _Closure_0024__24_002D4(closure_0024__24_002D2);
										if (jObject3.ContainsKey("file"))
										{
											closure_0024__24_002D2._0024VB_0024Local_File = (JObject)jObject3["file"];
											if (!string.IsNullOrEmpty((string?)closure_0024__24_002D2._0024VB_0024Local_File["downloadUrl"]))
											{
												ModLocalComp.LocalCompFile localCompFile = Enumerable.FirstOrDefault<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Input, (Func<ModLocalComp.LocalCompFile, bool>)closure_0024__24_002D2._Lambda_0024__8);
												if (localCompFile != null)
												{
													ModBase.AddToList(CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Output, localCompFile, ModComp.CompFile.HandleCurseForgeDownloadUrls(closure_0024__24_002D2._0024VB_0024Local_File["downloadUrl"].ToString()));
												}
											}
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator3)?.Dispose();
								}
								ModBase.Log($"[Export] 从 CurseForge 获取到 {jContainer.Count} 个本地资源项的对应信息");
							}
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "从 CurseForge 获取本地 Mod 信息失败");
							CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions.Add(ex4);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals1._0024VB_0024Local_EndedThreadCount++;
							CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.Progress += 0.45;
						}
					}), "CurseForge - " + CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (ThreadPriority)2);
					while (true)
					{
						if (CS_0024_003C_003E8__locals1._0024VB_0024Local_EndedThreadCount == 2)
						{
							if (CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions.Count == 1)
							{
								if (ModMain.MyMsgBox("联网获取部分文件信息失败，是否继续导出？\r\n\r\n若继续，无法获取信息的文件将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "部分文件信息获取失败", "继续", "取消") != 2)
								{
									break;
								}
								throw Enumerable.First<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions);
							}
							if (CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions.Count <= 1 || ModMain.MyMsgBox("联网获取文件信息失败，是否继续导出？\r\n\r\n若继续，所有文件都将被直接打包。\r\n由于二次分发可能违反使用协议，请尽量不要公开发布导出的整合包！", "文件信息获取失败", "继续", "取消") != 2)
							{
								break;
							}
							throw Enumerable.First<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)CS_0024_003C_003E8__locals1._0024VB_0024Local_FailedExceptions);
						}
						if (CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader.IsAborted)
						{
							break;
						}
						Thread.Sleep(10);
					}
				}
			}, null, (ThreadPriority)2)
			{
				Show = CS_0024_003C_003E8__locals0._0024VB_0024Local_CheckHostedAssets,
				ProgressWeight = (CS_0024_003C_003E8__locals0._0024VB_0024Local_CheckHostedAssets ? 2.0 : 0.01)
			});
			val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<Dictionary<ModLocalComp.LocalCompFile, List<string>>, int>("生成压缩包", [SpecialName] (ModLoader.LoaderTask<Dictionary<ModLocalComp.LocalCompFile, List<string>>, int> Loader) =>
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
				JArray jArray = new JArray();
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLocalComp.LocalCompFile, List<string>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLocalComp.LocalCompFile, List<string>>>);
				try
				{
					enumerator2 = Loader.Input.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						KeyValuePair<ModLocalComp.LocalCompFile, List<string>> current = enumerator2.Current;
						ModLocalComp.LocalCompFile key = current.Key;
						jArray.Add(new JObject
						{
							{
								"path",
								ModBase.AfterFirst(key.Path, CS_0024_003C_003E8__locals0._0024VB_0024Local_OverridesFolder).Replace("\\", "/")
							},
							{
								"hashes",
								new JObject
								{
									{ "sha1", key.ModrinthHash },
									{
										"sha512",
										ModBase.GetFileSHA512(key.Path)
									}
								}
							},
							{
								"downloads",
								new JArray(Enumerable.OrderByDescending<string, bool>((System.Collections.Generic.IEnumerable<string>)current.Value, (_Closure_0024__._0024I24_002D10 == null) ? (_Closure_0024__._0024I24_002D10 = [SpecialName] (string u) => u.Contains("modrinth.com")) : _Closure_0024__._0024I24_002D10))
							},
							{
								"fileSize",
								new FileInfo(key.Path).Length
							}
						});
						File.Delete(key.Path);
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
				Loader.Progress = 0.2;
				JObject jObject = new JObject { 
				{
					"minecraft",
					CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.McName
				} };
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.HasForge)
				{
					jObject.Add("forge", CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.ForgeVersion);
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.HasFabric)
				{
					jObject.Add("fabric-loader", CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.FabricVersion);
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.HasNeoForge)
				{
					jObject.Add("neoforge", CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Version.NeoForgeVersion);
				}
				JObject jObject2 = new JObject
				{
					{ "game", "minecraft" },
					{ "formatVersion", 1 },
					{ "versionId", CS_0024_003C_003E8__locals0._0024VB_0024Local_PackVersion },
					{ "name", CS_0024_003C_003E8__locals0._0024VB_0024Local_PackName },
					{
						"summary",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance.Info
					},
					{ "files", jArray },
					{ "dependencies", jObject }
				};
				File.WriteAllText(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\modrinth.index.json", jObject2.ToString(Formatting.Indented));
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath));
				if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath))
				{
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath);
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_IncludePCL)
				{
					ZipFile.CreateFromDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack.mrpack");
					Loader.Progress = 0.5;
					Directory.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\", true);
					Loader.Progress = 0.6;
					ZipFile.CreateFromDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath);
					Loader.Progress = 0.9;
				}
				else
				{
					ZipFile.CreateFromDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder + "modpack\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath);
					Loader.Progress = 0.8;
				}
				Directory.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_CacheFolder, true);
				ModBase.OpenExplorer(CS_0024_003C_003E8__locals0._0024VB_0024Local_PackPath);
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 6.0
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2);
			loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}
	}

	private void TextExportName_GotFocus()
	{
		if (Operators.CompareString(((TextBox)TextExportName).Text, "", false) == 0)
		{
			((TextBox)TextExportName).Text = TextExportName.HintText;
			((TextBox)TextExportName).SelectionStart = ((TextBox)TextExportName).Text.Length;
		}
	}

	private void CheckAdvancedModrinth_Change(object sender, bool user)
	{
		if (CheckAdvancedModrinth.Checked.GetValueOrDefault())
		{
			CheckOptionsPcl.Checked = false;
		}
		MyCheckBox checkOptionsPcl = CheckOptionsPcl;
		bool? @checked = CheckAdvancedModrinth.Checked;
		((UIElement)checkOptionsPcl).IsEnabled = ((!@checked) ?? @checked).Value;
	}

	private void CheckAdvancedInclude_Change(object sender, bool user)
	{
		if (CheckAdvancedInclude.Checked.GetValueOrDefault())
		{
			CheckAdvancedModrinth.Checked = false;
		}
		MyCheckBox checkAdvancedModrinth = CheckAdvancedModrinth;
		bool? @checked = CheckAdvancedInclude.Checked;
		((UIElement)checkAdvancedModrinth).IsEnabled = ((!@checked) ?? @checked).Value;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	public void InitializeComponent()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstanceexport.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
	{
		return System.Delegate.CreateDelegate(delegateType, (object)this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAllBack = (Grid)target;
			break;
		case 2:
			PanBack = (MyScrollViewer)target;
			break;
		case 3:
			HintOptiFine = (MyHint)target;
			break;
		case 4:
			TextExportName = (MyTextBox)target;
			break;
		case 5:
			TextExportVersion = (MyTextBox)target;
			break;
		case 6:
			CardOptions = (MyCard)target;
			break;
		case 7:
			BtnOverrideCancel = (MyIconTextButton)target;
			break;
		case 8:
			PanOptions = (StackPanel)target;
			break;
		case 9:
			CheckOptionsBasic = (MyCheckBox)target;
			break;
		case 10:
			CheckOptionsOptions = (MyCheckBox)target;
			break;
		case 11:
			CheckOptionsMod = (MyCheckBox)target;
			break;
		case 12:
			CheckOptionsResourcePacks = (MyCheckBox)target;
			break;
		case 13:
			PanOptionsResourcePacks = (StackPanel)target;
			break;
		case 14:
			CheckOptionsShaderPacks = (MyCheckBox)target;
			break;
		case 15:
			PanOptionsShaderPacks = (StackPanel)target;
			break;
		case 16:
			CheckOptionsSaves = (MyCheckBox)target;
			break;
		case 17:
			PanOptionsSaves = (StackPanel)target;
			break;
		case 18:
			CheckOptionsPcl = (MyCheckBox)target;
			break;
		case 19:
			CheckOptionsPclCustom = (MyCheckBox)target;
			break;
		case 20:
			CheckAdvancedInclude = (MyCheckBox)target;
			break;
		case 21:
			CheckAdvancedModrinth = (MyCheckBox)target;
			break;
		case 22:
			BtnAdvancedImport = (MyButton)target;
			break;
		case 23:
			BtnAdvancedExport = (MyButton)target;
			break;
		case 24:
			BtnAdvancedHelp = (MyButton)target;
			break;
		case 25:
			BtnExport = (MyExtraTextButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
