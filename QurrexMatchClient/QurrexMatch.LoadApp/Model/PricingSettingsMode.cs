namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// how do robots determine the "fair" price?
    /// </summary>
    public enum PricingSettingsMode
    {
        // the fair price is always the same value
        Fixed = 0, 
        // the fair price change by a sinusiod
        Sinusoidal
        // the fair price is got from a side source
        //Market
    }
}
