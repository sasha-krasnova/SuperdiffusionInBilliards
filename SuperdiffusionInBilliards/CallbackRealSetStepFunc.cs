using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public interface CallbackRealSetStepFunc
    {
        void f(int idxOfReal);
    }
}
