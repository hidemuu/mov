namespace Mov.Core.Schedulers.Models
{
    public enum ScheduleStatus
    {
        Nothing = 0,
        Standby = 1,
        Ready = 2,
        Running = 3,
        StopWait = 4,
        Finished = 5,
        Jumped = 6,
    }
}
