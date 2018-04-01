namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// the way the trader operates
    /// </summary>
    public enum TraderModusOperandi
    {
        /// <summary>
        /// a trader who trades discretionary
        /// </summary>
        Taker = 0,
        /// <summary>
        /// a trader who places a number of large orders a bit higher and
        /// a bit lower the "fair" price
        /// </summary>
        Maker,
        /// <summary>
        /// a trader who sometimes places a large order below (or above) the "fair price"
        /// </summary>
        OneShotTaker
    }
}
