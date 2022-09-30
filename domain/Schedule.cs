using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    internal class Schedule
    {
        private int drId;
        private DateTime dayStart;
        private DateTime dayEnd;

        public int DrId { get { return drId; } set { drId = value; } }
        public DateTime DayStart { get { return dayStart; } set { dayStart = value; } }
        public DateTime DayEnd { get { return dayEnd; } set { dayEnd = value; } }
    }
}
