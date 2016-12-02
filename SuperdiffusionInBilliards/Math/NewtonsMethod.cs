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
        const int maxCount = 50; // Максимальное чило итераций
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

            if(success)
                roots.Add(x);
            return roots;
        }    
    }
}
