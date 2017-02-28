using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class TitlesInFile : ICsvLine
    {
        private List<string> titles;

        public TitlesInFile(List<string> titles)
        {
            this.titles = titles;
        }

        public String GetCSV()
        {
            string titlesString = "";
            foreach (string title in titles)
            {
                titlesString += (title + ";"); 
            }
            
            return titlesString + ";";
        }
        
    }
}
