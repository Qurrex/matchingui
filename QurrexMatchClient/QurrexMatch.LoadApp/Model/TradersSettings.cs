using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using QurrexMatch.Lib.Model.Enumerations;
using QurrexMatch.Lib.Util;

namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// class describes connection, payload, pricing and trading settings
    /// used in the Qurrex matching testing program
    /// </summary>
    public partial class TradersSettings
    {
        /// <summary>
        /// payload settings: intervals between requests, threads count etc
        /// </summary>
        public PayloadSettings PayloadSets { get; set; } = new PayloadSettings();

        /// <summary>
        /// a set of rules describing how the "market" prices changes (if it does)
        /// </summary>
        public PricingSettings PricingSets { get; set; } = new PricingSettings();

        /// <summary>
        /// several trading patterns are scripted here
        /// </summary>
        public TradeSettings TradeSets { get; set; } = new TradeSettings();

        /// <summary>
        /// a set of rules for calculating trading volume and choosing among the trading instruments
        /// </summary>
        public MoneyManagementSettings MoneyManagementSets { get; set; } = new MoneyManagementSettings();

        /// <summary>
        /// the matching server URL
        /// </summary>
        public string Uri { get; set; } = "54.36.178.211:5001";

        /// <summary>
        /// the URL to gather statistics from the matching server
        /// </summary>
        public string StatUri { get; set; } = "http://54.36.178.211:8080/status/";

        /// <summary>
        /// gather or skip the stats provided by matching REST API
        /// </summary>
        public bool LogServerStatistics { get; set; } = true;

        /// <summary>
        /// interval to quantify gathered statistics (timeframe): requests and responses per interval, roundtrips etc
        /// </summary>
        public int StatisticsTimeframeSeconds { get; set; } = 1;

        /// <summary>
        /// test duration limit
        /// the test stops in N seconds if it hasn't been stopped manually
        /// </summary>
        public int TestDurationSeconds { get; set; } = 60 * 3;

        /// <summary>
        /// a "cooldown" time - an interval between setting the connections and starting requests
        /// </summary>
        public int CooldownMilliseconds { get; set; } = 500;

        /// <summary>
        /// logging verbosity level
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public LoggingLevel LoggingLevel { get; set; } = LoggingLevel.Critical;        

        /// <summary>
        /// make default settings object - e.g., when the settings file is corrupted or missed
        /// </summary>
        public static TradersSettings MakeDefaultSettings()
        {
            var sets = new TradersSettings();
            sets.MoneyManagementSets.Tickers = new List<Ticker>
            {
                new Ticker
                {
                    Name = "BTC/USD",
                    Id = 1,
                    DefaultPrice = 15000,
                    PriceStep = 0.01,
                    MinVolume = 0.00000001
                },
                new Ticker
                {
                    Name = "ETH/USD",
                    Id = 2,
                    DefaultPrice = 1000,
                    PriceStep = 0.01,
                    MinVolume = 0.00000001
                }
            };
            return sets;
        }

        /// <summary>
        /// read the settings from JSON file by its default path
        /// </summary>
        public static TradersSettings ReadSettings()
        {
            TradersSettings settings;
            var path = ExecutablePath.Combine("settings.txt");
            if (File.Exists(path))
            {
                string json;
                using (var sr = new StreamReader(path, Encoding.UTF8))
                    json = sr.ReadToEnd();
                settings = JsonConvert.DeserializeObject<TradersSettings>(json);
                return settings;
            }

            settings = MakeDefaultSettings();
            settings.SaveSettings();

            return settings;
        }

        /// <summary>
        /// save settings in JSON file by default path
        /// </summary>
        public void SaveSettings()
        {
            var path = ExecutablePath.Combine("settings.txt");
            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.Write(JsonConvert.SerializeObject(this, Formatting.Indented));
            }
        }

        /// <summary>
        /// copy just the common part of the settings into the target object
        /// </summary>
        public void CopyCommonSettingsToTarget(TradersSettings target)
        {
            target.Uri = Uri;
            target.StatUri = StatUri;
            target.LogServerStatistics = LogServerStatistics;
            target.LoggingLevel = LoggingLevel;
            target.StatisticsTimeframeSeconds = StatisticsTimeframeSeconds;
            target.TestDurationSeconds = TestDurationSeconds;
        }
    }
}
