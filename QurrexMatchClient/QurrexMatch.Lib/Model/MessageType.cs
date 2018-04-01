namespace QurrexMatch.Lib.Model
{
    public enum MessageType
    {
        RejectResponse = 10,
        ExecutionReport = 5,
        CancelOrderRequest = 3,
        CancelReport = 4,
        MassCancelReport = 14,
        MassCancelRequest = 12,
        NewOrderBody = 1,
        NewOrderReport = 2 ,
        Undefined = 0
    }
}
