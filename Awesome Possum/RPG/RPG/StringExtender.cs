using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace RPG
{
    public static class StringExtender
    {
        public static string MakeAbsolute(this string relPath, string relFolder, int i)
        {
            return MakeAbsolute(relPath, string.Format("{0}\\{1}", relFolder, i));
        }

        public static string MakeRelative(this string relPath, string relFolder, string subFolder, int i)
        {
            if (string.IsNullOrEmpty(relPath) || string.IsNullOrEmpty(relFolder) || string.IsNullOrEmpty(subFolder))
                return "";

            return MakeRelative(relPath, relFolder, string.Format("{0}\\{1}", i, subFolder));
        }

        private static string MakeAbsolute(this string relPath, string relFolder)
        {
            if (string.IsNullOrEmpty(relPath) || string.IsNullOrEmpty(relFolder))
                return "";

            return Path.Combine(relFolder, relPath);
        }

        private static string MakeRelative(this string relPath, string relFolder, string subFolder)
        {
            var fullFinal = Path.Combine(relFolder, subFolder, relPath.Split('\\').LastOrDefault());
            var fullFinalFolder = Path.GetDirectoryName(fullFinal);

            if (!Directory.Exists(relFolder))
                Directory.CreateDirectory(relFolder);

            if (!Directory.Exists(fullFinalFolder))
                Directory.CreateDirectory(fullFinalFolder);

            if (!File.Exists(fullFinal))
                File.Copy(relPath, fullFinal);

            var finalRelative = string.Format("{0}\\{1}", fullFinalFolder.Split('\\').LastOrDefault(), fullFinal.Split('\\').LastOrDefault());

            return finalRelative;
        }
    }
}
