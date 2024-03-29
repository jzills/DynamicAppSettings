namespace Source.Extensions;

public static class TypeExtensions
{
    public static bool IsArrayOrEnumerable(this Type source) =>
        source.IsArray || typeof(IEnumerable<>).IsAssignableFrom(source);
}