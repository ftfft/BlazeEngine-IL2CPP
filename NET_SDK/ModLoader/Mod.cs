namespace NET_SDK.ModLoader
{
    public abstract class Mod
    {
        /// <summary>
        /// Gets the name of the mod.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the version of the plugin.
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Gets the author of the mod.
        /// </summary>
        public string Author { get; internal set; }

        /// <summary>
        /// Gets the download link of the mod.
        /// </summary>
        public string DownloadLink { get; internal set; }
    }
}
