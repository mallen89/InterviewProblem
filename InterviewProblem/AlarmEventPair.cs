using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewProblem
{
    public class AlarmEventPair
    {
        public TripUploadEvent InEvent;
        public TripUploadEvent OutEvent;

        public int GetDuration()
        {
            TimeSpan duration = new TimeSpan(0);

            if (InEvent != null && OutEvent != null)
            {
                duration = InEvent.timestamp.Subtract(OutEvent.timestamp);
                return Convert.ToInt32(duration.Ticks / 10000000);
            }

            return Convert.ToInt32(duration.Ticks/ 10000000);
        }

        public bool HasInEvent()
        {
            return (InEvent != null ? true : false);
        }

    }
}
