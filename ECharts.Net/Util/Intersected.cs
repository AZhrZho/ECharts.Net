namespace ECharts.Net.Util;

#pragma warning disable CS0660,CS0661

public struct Intersected<T1, T2>
{
    public Intersected(T1 value)
    {
        SetValue(value);
    }

    public Intersected(T2 value)
    {
        SetValue(value);
    }
    
    public bool HasItem1 { get; private set; }
    public bool HasItem2 { get; private set; }

    public void SetValue(T1? value)
    {
        item1 = value;
        HasItem1 = true;
        HasItem2 = false;
    }

    public void SetValue(T2? value)
    {
        item2 = value;
        HasItem2 = true;
        HasItem1 = false;
    }

    public T? GetValue<T>()
    {
        if (typeof(T) == typeof(T1) && HasItem1) return (T?)(object?)item1;
        if (typeof(T) == typeof(T2) && HasItem2) return (T?)(object?)item2;
        throw new InvalidCastException("invalid type");
    }

    public object? Value
    {
        get
        {
            if (HasItem1)
            {
                return item1;
            }
            if (HasItem2)
            {
                return item2;
            }
            return null;
        }
    }

    public static bool operator ==(Intersected<T1, T2> intersected, T1 value)
    {
        if (!intersected.HasItem1) return false;
        return EqualityComparer<T1>.Default.Equals(intersected.item1!, value);
    }

    public static bool operator ==(Intersected<T1, T2> intersected, T2 value)
    {
        if (!intersected.HasItem2) return false;
        return EqualityComparer<T2>.Default.Equals(intersected.item2!, value);
    }

    public static bool operator !=(Intersected<T1, T2> intersected, T1 value) => !(intersected == value);
    public static bool operator !=(Intersected<T1, T2> intersected, T2 value) => !(intersected == value);

    public static implicit operator Intersected<T1, T2>(T1 value) => new(value);
    public static implicit operator Intersected<T1, T2>(T2 value) => new(value);

    private T1? item1;
    private T2? item2;
}

public struct Intersected<T1, T2, T3>
{
    public Intersected(T1 value)
    {
        SetValue(value);
    }

    public Intersected(T2 value)
    {
        SetValue(value);
    }

    public Intersected(T3 value)
    {
        SetValue(value);
    }

    public bool HasItem1 { get; private set; }
    public bool HasItem2 { get; private set; }
    public bool HasItem3 { get; private set; }

    public void SetValue(T1? value)
    {
        item1 = value;
        HasItem1 = true;
        HasItem2 = false;
        HasItem3 = false;
    }

    public void SetValue(T2? value)
    {
        item2 = value;
        HasItem2 = true;
        HasItem1 = false;
        HasItem3 = false;
    }

    public void SetValue(T3? value)
    {
        item3 = value;
        HasItem3 = true;
        HasItem1 = false;
        HasItem2 = false;
    }

    public T? GetValue<T>()
    {
        if (typeof(T) == typeof(T1) && HasItem1) return (T?)(object?)item1;
        if (typeof(T) == typeof(T2) && HasItem2) return (T?)(object?)item2;
        if (typeof(T) == typeof(T3) && HasItem3) return (T?)(object?)item3;
        throw new InvalidCastException("invalid type");
    }

    public object? Value
    {
        get
        {
            if (HasItem1)
            {
                return item1;
            }
            if (HasItem2)
            {
                return item2;
            }
            if (HasItem3)
            {
                return item3;
            }
            return null;
        }
    }

    public static bool operator ==(Intersected<T1, T2, T3> intersected, T1 value)
    {
        if (!intersected.HasItem1) return false;
        return EqualityComparer<T1>.Default.Equals(intersected.item1!, value);
    }

    public static bool operator ==(Intersected<T1, T2, T3> intersected, T2 value)
    {
        if (!intersected.HasItem2) return false;
        return EqualityComparer<T2>.Default.Equals(intersected.item2!, value);
    }

    public static bool operator ==(Intersected<T1, T2, T3> intersected, T3 value)
    {
        if (!intersected.HasItem3) return false;
        return EqualityComparer<T3>.Default.Equals(intersected.item3!, value);
    }

    public static bool operator !=(Intersected<T1, T2, T3> intersected, T1 value) => !(intersected == value);
    public static bool operator !=(Intersected<T1, T2, T3> intersected, T2 value) => !(intersected == value);
    public static bool operator !=(Intersected<T1, T2, T3> intersected, T3 value) => !(intersected == value);

    public static implicit operator Intersected<T1, T2, T3>(T1 value) => new(value);
    public static implicit operator Intersected<T1, T2, T3>(T2 value) => new(value);
    public static implicit operator Intersected<T1, T2, T3>(T3 value) => new(value);

    private T1? item1;
    private T2? item2;
    private T3? item3;
}

#pragma warning restore CS0660, CS0661
