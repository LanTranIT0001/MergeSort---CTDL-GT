using System;
using System.Diagnostics;
public class Timing
{
    TimeSpan startingTime;
    TimeSpan duration;
    public Timing()
    {
        startingTime = new TimeSpan(0);
        duration = new TimeSpan(0);
    }
    public void StopTime()
    {
        duration =
        Process.GetCurrentProcess().Threads[0].
        UserProcessorTime.
        Subtract(startingTime);
    }
    public void startTime()
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        startingTime =
        Process.GetCurrentProcess().Threads[0].
        UserProcessorTime;
    }
    public TimeSpan Result()
    {
        return duration;
    }
}