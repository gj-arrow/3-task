namespace Steampowered.PageServices
{
    public static class GenerateLocatorService
    {
        public static string GenerateStringLocator(string template, string value)
        {
            return string.Format(template, value);
        }
    }
}
