namespace QurrexMatch.LoadApp.Model
{
    /// <summary>
    /// determines sleep interval between making order requests
    /// or a number of active trading threads
    /// </summary>
    public enum PayloadSettingsMode
    {
        /// <summary>
        /// the payload is a constant
        /// </summary>
        Even = 0,
        /// <summary>
        /// the payload increases and decreases by sinusoid
        /// </summary>
        Sinusoidal,
        /// <summary>
        /// the payload is growing within the provided period to its final value
        /// </summary>
        FadeIn,
        /// <summary>
        /// the payload grows step by step
        /// </summary>
        Stairs,
        /// <summary>
        /// the payload decreases step by step
        /// </summary>
        StairsDown
    }
}
