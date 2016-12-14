using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperdiffusionInBilliards
{
    class CsvFileWriter
    {
        private string fileName;
        private List<ICsvLine> fileContent;

        public CsvFileWriter(string fileName, List<ICsvLine> fileContent)
        {
            this.fileName = fileName;
            this.fileContent = fileContent;
        }

        public void WriteToFile()
        {
            using (System.IO.StreamWriter file = 
                new System.IO.StreamWriter(fileName))

            foreach (ICsvLine line in fileContent)
            {
                file.WriteLine(line.GetCSV());
            }
        }


    }
}
