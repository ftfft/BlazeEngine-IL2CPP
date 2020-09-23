using System;

namespace NET_SDK.ModLoader
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModInfoAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the mod.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the version of the plugin.
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// Gets the author of the mod.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets the download link of the mod.
        /// </summary>
        public string DownloadLink { get; }

        public ModInfoAttribute(string name, string version, string author, string downloadLink = null, string modid = null)
        {
            Name = name;
            Version = version;
            Author = author;
            DownloadLink = downloadLink;
        }
    }
}
