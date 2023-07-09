namespace Launcher.App;

public class Comparer<T> : IEqualityComparer<T>
{
    private static Comparer<T>? _comparer;
    
    public static IEqualityComparer<T> Instance
    {
        get
        {
            return _comparer ??= new Comparer<T>();
        }
    }
    
    public bool Equals(T? x, T? y)
    {
        return x.Equals(y);
    }

    public int GetHashCode(T obj)
    {
        return obj.GetHashCode();
    }
}