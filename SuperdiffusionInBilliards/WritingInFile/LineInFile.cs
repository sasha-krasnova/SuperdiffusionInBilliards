using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class LineInFile : ICsvLine
    {
        private List<double> values = new List<double>();
        public LineInFile(List<double> values)
        {
            this.values = values;
        }
        public LineInFile()
        {
           
        }

            
        public String GetCSV()
        {
            string dataCsv = null;
            foreach (double value in values)
                dataCsv += Convert.ToString(value) + ";";
            return dataCsv;
        }
    }
}
