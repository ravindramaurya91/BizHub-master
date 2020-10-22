using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Generator
{
    public class Generate
    {

        public static void Main(string[] args)
        {
            GeneratorSettings settings = new GeneratorSettings(GetScriptFolder());

            // exclude tables here
            settings.ExcludeTable("VersionInfo");
            settings.ExcludeTable("sysdiagrams");

            // exclude columns here
            settings.ExcludeColumn("ZipCode", "LocationPoint");

            GeneratorUtility.Run(settings);

        }

        public static string GetScriptFolder([CallerFilePath] string path = null) {
            return Path.GetDirectoryName(path);
        }

    }

}
