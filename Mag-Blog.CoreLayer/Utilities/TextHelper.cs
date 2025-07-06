namespace CodeYad_Blog.CoreLayer.Utilities;

public static class TextHelper
{
    public static string ToSlug(this string slug)
    {
        return slug.Trim().ToLower()
            .Replace("~", "")
            .Replace("!", "")
            .Replace("@", "")
            .Replace("#", "")
            .Replace("$", "")
            .Replace("%", "")
            .Replace("^", "")
            .Replace("<", "")
            .Replace(">", "")
            .Replace("&", "")
            .Replace("*", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("_", "-")
            .Replace(" ", "-")
            .Replace("/", "")
            .Replace(@"\", "")
            .Replace("+", "");
    }
}