using System;

namespace MorseCode.CsJs.UI
{
    public static class VirtualPathUtility
    {
        public static string ApplicationRootPath { get; set; }

        public static string ToAbsolute(string applicationRelativePath)
        {
            if (!applicationRelativePath.StartsWith("~/"))
            {
                throw new InvalidOperationException("Path must begin with ~/ to be application relative.");
            }

            return EnsureTrailingSlash(ApplicationRootPath) + applicationRelativePath.Substring(2);
        }

        private static string EnsureTrailingSlash(string path)
        {
            if (!path.EndsWith("/"))
            {
                path += "/";
            }

            return path;
        }
    }
}