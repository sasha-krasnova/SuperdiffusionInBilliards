using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    public class Parameter : ICsvLine
    {
        private string name;
        private Object value;

        public Parameter(string name, Object value)
        {
            this.name = name;
            this.value = value;
        }

        public String GetCSV()
        {
            return name + ";" + Convert.ToString(value);
        }
    }
}
