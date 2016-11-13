using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    public class CollisionTime
    {
        private double time;
        private bool existence;

        public CollisionTime(double time, bool existence)
        {
            this.time = time;
            this.existence = existence;
        }

        public double Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public bool Existence
        {
            get
            {
                return existence;
            }
            set
            {
                existence = value;
            }
        }
    }
}
