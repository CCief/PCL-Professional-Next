using System;

// VB.NET 匿名类型 New With { ... } 反编译占位（VB$AnonymousType_0`2）
[System.Runtime.CompilerServices.CompilerGenerated]
internal class VB_0024AnonymousType_0<T0, T1>
{
    private readonly T0 _DisplayName;
    private readonly T1 _Proxy;
    public VB_0024AnonymousType_0(T0 DisplayName, T1 Proxy)
    {
        _DisplayName = DisplayName;
        _Proxy = Proxy;
    }
    public T0 DisplayName { get { return _DisplayName; } }
    public T1 Proxy { get { return _Proxy; } }
    public override string ToString() { return Convert.ToString(_DisplayName); }
}
