namespace Valverij.Extensions.Data
{
    public static class ObjectExtensions
    {
        public static string TableNameFor<T>(this T obj) => typeof(T).TableNameForType();
    }
}
