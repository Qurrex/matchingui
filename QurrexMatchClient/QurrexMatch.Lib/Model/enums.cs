namespace QurrexMatch.Lib.Model
{
    public enum TimeInForce
    {
        GTK = 1,
        IOC = 2,
        FOK = 3
    }

    public enum AutoCancel
    {
        ON = 1,
        OFF = 2
    }

    // byte
    public enum CancelReason
    {
        UserCancel = 0,
        UserMassCancel = 1,
        Disconnect = 2,
        Expired = 3,
        System = 4
    }

    /// <summary>
    /// Int16
    /// </summary>
    public enum ErrorCode
    {
        eBadAccountOrClient = 2000,
        eInstrumentNotFound = 2002,
        eBadOrderAttributes = 2003,
        eBadAmount = 2004,
        eBadPrice = 2005,
        eOrderIDNotFound = 3001,
        eBadCancelMode = 3003
    }

    // byte
    public enum MassCancelMode
    {
        Connect = 1,
        ConnectInstrument = 2,
        AutoOnDisconnect = 4
    }

    // byte
    public enum MassCancelStatus
    {
        eNothing = 0,
        eOK = 1
    }
}
