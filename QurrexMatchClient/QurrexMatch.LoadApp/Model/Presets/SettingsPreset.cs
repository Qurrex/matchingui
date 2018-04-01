namespace QurrexMatch.LoadApp.Model.Presets
{
    /// <summary>
    /// class describes complete Load App settings builder
    /// the settings built depend from just one param: payload, varied from 1 to 10
    /// </summary>
    public abstract class SettingsPreset
    {
        /// <summary>
        /// a short caption
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// image index for the settings' icon
        /// </summary>
        public int ImageIndex { get; set; }

        /// <summary>
        /// a user-friendly description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// build complete settings, depending on just one param - payload
        /// </summary>
        public abstract TradersSettings Build(int payload);

        /// <summary>
        /// build a user-friendly description on the payload ptr provided
        /// </summary>
        public abstract string MakeDescription(int payload);

        /// <summary>
        /// all the presets in one array
        /// </summary>
        public static SettingsPreset[] Presets;

        public static SettingsPreset GetPresetByIndex(int index)
        {
            var defSets = TradersSettings.ReadSettings();
            var presetType = Presets[index].GetType();
            return (SettingsPreset) presetType.GetConstructor(new[] {typeof(TradersSettings)}).Invoke(new object[] {defSets});
        }
    }
}
