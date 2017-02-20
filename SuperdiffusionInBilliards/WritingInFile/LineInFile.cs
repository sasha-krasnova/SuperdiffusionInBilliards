using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class LineInFile : ICsvLine
    {
        private double variable;
        private double function;
        private double functionTheory;

        public LineInFile(double variable, double function, double functionTheory)
        {
            this.variable = variable;
            this.function = function;
            this.functionTheory = functionTheory;
        }

        public String GetCSV()
        {
            return Convert.ToString(variable) + ";" + Convert.ToString(function) + ";" + Convert.ToString(functionTheory) + ";";
        }
    }
}
