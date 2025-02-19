using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    public DateTime ActivityDate { get; set; }
    public int DurationMinutes { get; set; }

    public Activity(DateTime activityDate, int durationMinutes)
    {
        ActivityDate = activityDate;
        DurationMinutes = durationMinutes;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{ActivityDate:dd MMM yyyy} {this.GetType().Name} ({DurationMinutes} min): " +
               $"Distance {GetDistance()}, Speed: {GetSpeed()}, Pace: {GetPace()}";
    }
}

// Derived class for Running
public class Running : Activity
{
    public double DistanceMiles { get; set; }

    public Running(DateTime activityDate, int durationMinutes, double distanceMiles)
        : base(activityDate, durationMinutes)
    {
        DistanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return DistanceMiles;
    }

    public override double GetSpeed()
    {
        return (DistanceMiles / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / DistanceMiles;
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    public double SpeedMph { get; set; }

    public Cycling(DateTime activityDate, int durationMinutes, double speedMph)
        : base(activityDate, durationMinutes)
    {
        SpeedMph = speedMph;
    }

    public override double GetDistance()
    {
        return (SpeedMph * DurationMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return SpeedMph;
    }

    public override double GetPace()
    {
        return 60 / SpeedMph;
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    public int Laps { get; set; }

    public Swimming(DateTime activityDate, int durationMinutes, int laps)
        : base(activityDate, durationMinutes)
    {
        Laps = laps;
    }

    public override double GetDistance()
    {
        return (Laps * 50) / 1000.0; // Convert meters to kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / DurationMinutes) * 60;
    }

    public override double GetPace()
    {
        return DurationMinutes / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        // Create instances of each activity
        var activity1 = new Running(new DateTime(2022, 11, 3), 30, 3.0);  // Running for 30 minutes, 3 miles
        var activity2 = new Cycling(new DateTime(2022, 11, 4), 45, 12.0);  // Cycling for 45 minutes, 12 mph
        var activity3 = new Swimming(new DateTime(2022, 11, 5), 40, 30);  // Swimming for 40 minutes, 30 laps

        // Store activities in a list
        List<Activity> activities = new List<Activity> { activity1, activity2, activity3 };

        // Print summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
