using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL.Controls.Behaviors;

public sealed class ClipboardInterceptor
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<DataGridCellInfo, object> _0024I15_002D0;

		public static Func<DataGridCellInfo, string> _0024I15_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal object _Lambda_0024__15_002D0(DataGridCellInfo c)
		{
			return c.Item;
		}

		[SpecialName]
		internal string _Lambda_0024__15_002D1(DataGridCellInfo cell)
		{
			FrameworkElement cellContent = cell.Column.GetCellContent(RuntimeHelpers.GetObjectValue(cell.Item));
			TextBlock val = (TextBlock)(object)((cellContent is TextBlock) ? cellContent : null);
			if (val == null)
			{
				return "";
			}
			return val.Text;
		}
	}

	public static readonly DependencyProperty EnableSafeClipboardProperty = DependencyProperty.RegisterAttached("EnableSafeClipboard", typeof(bool), typeof(ClipboardInterceptor), new PropertyMetadata((object)false, new PropertyChangedCallback(OnEnableSafeClipboardChanged)));

	private ClipboardInterceptor()
	{
	}

	public static void SetEnableSafeClipboard(DependencyObject element, bool value)
	{
		element.SetValue(EnableSafeClipboardProperty, (object)value);
	}

	public static bool GetEnableSafeClipboard(DependencyObject element)
	{
		return Conversions.ToBoolean(element.GetValue(EnableSafeClipboardProperty));
	}

	private static void OnEnableSafeClipboardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		if (d is TextBox && Conversions.ToBoolean(e.NewValue))
		{
			AddCommandBindingsToTextBox((TextBox)d);
		}
		else if (d is RichTextBox && Conversions.ToBoolean(e.NewValue))
		{
			AddCommandBindingsToRichTextBox((RichTextBox)d);
		}
		else if (d is DataGrid && Conversions.ToBoolean(e.NewValue))
		{
			AddCommandBindingsToDataGrid((DataGrid)d);
		}
	}

	private static void AddCommandBindingsToTextBox(TextBox tb)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((UIElement)tb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Copy, new ExecutedRoutedEventHandler(OnCopyTextBox)));
		((UIElement)tb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Cut, new ExecutedRoutedEventHandler(OnCutTextBox)));
		((UIElement)tb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Paste, new ExecutedRoutedEventHandler(OnPasteTextBox)));
	}

	private static void AddCommandBindingsToRichTextBox(RichTextBox rtb)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((UIElement)rtb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Copy, new ExecutedRoutedEventHandler(OnCopyRichTextBox)));
		((UIElement)rtb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Cut, new ExecutedRoutedEventHandler(OnCutRichTextBox)));
		((UIElement)rtb).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Paste, new ExecutedRoutedEventHandler(OnPasteRichTextBox)));
	}

	private static void AddCommandBindingsToDataGrid(DataGrid dg)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		((UIElement)dg).CommandBindings.Add(new CommandBinding((ICommand)(object)ApplicationCommands.Copy, new ExecutedRoutedEventHandler(OnCopyDataGrid)));
	}

	private static void OnCopyTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		if (val != null && val.SelectionLength > 0)
		{
			try
			{
				Clipboard.Clear();
				Clipboard.SetDataObject((object)val.SelectedText, true);
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnCutTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		if (val != null && val.SelectionLength > 0)
		{
			try
			{
				Clipboard.Clear();
				Clipboard.SetDataObject((object)val.SelectedText, true);
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			val.SelectedText = string.Empty;
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnPasteTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		TextBox val = (TextBox)((sender is TextBox) ? sender : null);
		if (val != null)
		{
			if (Clipboard.ContainsText())
			{
				string text = Clipboard.GetText();
				int selectionStart = val.SelectionStart;
				val.SelectedText = text;
				val.CaretIndex = checked(selectionStart + text.Length);
				val.SelectionLength = 0;
			}
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnCopyRichTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		RichTextBox val = (RichTextBox)((sender is RichTextBox) ? sender : null);
		if (val == null)
		{
			return;
		}
		TextRange val2 = new TextRange(((TextRange)val.Selection).Start, ((TextRange)val.Selection).End);
		if (!string.IsNullOrEmpty(val2.Text))
		{
			try
			{
				Clipboard.Clear();
				Clipboard.SetDataObject((object)val2.Text, true);
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnCutRichTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		RichTextBox val = (RichTextBox)((sender is RichTextBox) ? sender : null);
		if (val == null)
		{
			return;
		}
		TextRange val2 = new TextRange(((TextRange)val.Selection).Start, ((TextRange)val.Selection).End);
		if (!string.IsNullOrEmpty(val2.Text))
		{
			try
			{
				Clipboard.Clear();
				Clipboard.SetDataObject((object)val2.Text, true);
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			val2.Text = string.Empty;
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnPasteRichTextBox(object sender, ExecutedRoutedEventArgs e)
	{
		RichTextBox val = (RichTextBox)((sender is RichTextBox) ? sender : null);
		if (val != null && Clipboard.ContainsText())
		{
			string text = Clipboard.GetText();
			TextSelection selection = val.Selection;
			((TextRange)selection).Text = text;
			TextPointer val2 = (val.CaretPosition = ((TextRange)selection).End);
			((TextRange)val.Selection).Select(val2, val2);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private static void OnCopyDataGrid(object sender, ExecutedRoutedEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		DataGrid val = (DataGrid)((sender is DataGrid) ? sender : null);
		if (val == null || val.SelectedCells == null || ((System.Collections.Generic.ICollection<DataGridCellInfo>)val.SelectedCells).Count == 0)
		{
			return;
		}
		StringBuilder val2 = new StringBuilder();
		System.Collections.Generic.IEnumerable<IGrouping<object, DataGridCellInfo>> enumerable = Enumerable.GroupBy<DataGridCellInfo, object>((System.Collections.Generic.IEnumerable<DataGridCellInfo>)val.SelectedCells, (Func<DataGridCellInfo, object>)([SpecialName] (DataGridCellInfo c) => c.Item));
		System.Collections.Generic.IEnumerator<IGrouping<object, DataGridCellInfo>> enumerator = default(System.Collections.Generic.IEnumerator<IGrouping<object, DataGridCellInfo>>);
		try
		{
			enumerator = enumerable.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IGrouping<object, DataGridCellInfo> current = enumerator.Current;
				string text = string.Join("\t", Enumerable.Select<DataGridCellInfo, string>((System.Collections.Generic.IEnumerable<DataGridCellInfo>)current, (_Closure_0024__._0024I15_002D1 == null) ? (_Closure_0024__._0024I15_002D1 = [SpecialName] (DataGridCellInfo cell) =>
				{
					FrameworkElement cellContent = cell.Column.GetCellContent(RuntimeHelpers.GetObjectValue(cell.Item));
					TextBlock val3 = (TextBlock)(object)((cellContent is TextBlock) ? cellContent : null);
					return (val3 == null) ? "" : val3.Text;
				}) : _Closure_0024__._0024I15_002D1));
				val2.AppendLine(text);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		string text2 = val2.ToString().TrimEnd(new char[] { '\r', '\n' });
		try
		{
			Clipboard.Clear();
			Clipboard.SetDataObject((object)text2, true);
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		((RoutedEventArgs)e).Handled = true;
	}
}
