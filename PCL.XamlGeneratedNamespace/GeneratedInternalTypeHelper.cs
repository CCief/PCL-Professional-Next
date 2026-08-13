using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace PCL.XamlGeneratedNamespace;

[DebuggerNonUserCode]
[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
[EditorBrowsable(/*Could not decode attribute arguments.*/)]
public sealed class GeneratedInternalTypeHelper : InternalTypeHelper
{
	protected override object CreateInstance(System.Type type, CultureInfo culture)
	{
		return Activator.CreateInstance(type, (BindingFlags)564, (Binder)null, (object[])null, culture);
	}

	protected override object GetPropertyValue(PropertyInfo propertyInfo, object target, CultureInfo culture)
	{
		return propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(target), (BindingFlags)0, (Binder)null, (object[])null, culture);
	}

	protected override void SetPropertyValue(PropertyInfo propertyInfo, object target, object value, CultureInfo culture)
	{
		propertyInfo.SetValue(RuntimeHelpers.GetObjectValue(target), RuntimeHelpers.GetObjectValue(value), (BindingFlags)0, (Binder)null, (object[])null, culture);
	}

	protected override System.Delegate CreateDelegate(System.Type delegateType, object target, string handler)
	{
		return (System.Delegate)target.GetType().InvokeMember("_CreateDelegate", (BindingFlags)292, (Binder)null, RuntimeHelpers.GetObjectValue(target), new object[] { delegateType, handler }, (CultureInfo)null);
	}

	protected override void AddEventHandler(EventInfo eventInfo, object target, System.Delegate handler)
	{
		eventInfo.AddEventHandler(RuntimeHelpers.GetObjectValue(target), handler);
	}
}
