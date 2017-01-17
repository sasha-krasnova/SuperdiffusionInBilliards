using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    
    static public class NewtonsMethod
    { 
        //TODO: Остановку в случае расходимости
        const double epsilon = 0.0001;  // 
        const int maxCount = 20; // Максимальное чило итераций
        static public List<double> Solve(Function f, double x0)
        {
            List<double> roots = new List<double>();    // Создаем список корней
            double x = x0;  // Первое приближение
            double deltaX = 0;
            int counter = 0;
            bool success = false;
            do
            {
                counter++;
                deltaX = -f.F(x) / f.Derivative(x);
                x += deltaX;
                if (Math.Abs(deltaX) < epsilon)
                    success = true;
            }
            while (!success && counter < maxCount);

            if (success)
            {
                roots.Add(x);
                string line = "newtonsMethodCounter = ";
                string line1 = Convert.ToString(counter);
                string line2 = "\r\n";
                line += line1;
                line += line2;
                System.IO.File.AppendAllText(@"c:\Users\Sasha\Documents\Visual Studio 2010\Projects\SuperdiffusionInBilliards\NewtonsMethodCounter.txt", line);
                
            }
            return roots;
        }    
    }
}
