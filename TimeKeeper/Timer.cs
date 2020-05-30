using System;
using System.Text.Json;

namespace TimeKeeper
{
    public class Timer
    {
        public string id { get; set; }
        public DateTime startTime { get; set; }
        public Nullable<DateTime> stopTime { get; set; }

        public Timer(string id)
        {
            this.id = id;
        }

        public bool IsRunning()
        {
            return stopTime == null ? true : false;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
