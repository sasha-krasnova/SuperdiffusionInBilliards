using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperdiffusionInBilliards
{
    enum SuperdiffusionRunModes { Standert, Detail };
    /// <summary>
	/// Базовый класс сцены
	/// </summary>
    abstract public class SceneBase
    {
        private Point2D displacement;                   //Координаты сцены
        private double time;                            //Текущее время
        private double fullTime;                        //Время эксперимента
        private double deltaTime;                       //Время между точками записи в файл
        private Scatterer[] scatterers;                 //Массив рассеивателей
        private Particle particle;     //Частица
       // private StateOfParticle[] statistics;         //Статистика для файла
        private StateOfParticle oldState;               //Старое, сохраненное состояние системы, от которого строятся точки до нового состояния
        private List<StateOfParticleDetailed> statistics = new List<StateOfParticleDetailed>();

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="scatterers">Массив рассеивателей</param>
        /// <param name="fullTime">Время эксперимента</param>
        /// <param name="deltaTime">Время между точками записи в файл</param>
        /// <param name="particle">Частица</param>
        public SceneBase(Scatterer[] scatterers, double fullTime, double deltaTime, double vParticle)
        {
            displacement = new Point2D(0, 0);
            //Считаем vx vy по vParticle
            double alpha = new Random().NextDouble() % (2 * Math.PI);
            //double alpha = Math.PI / 3; // Ошибка после 7го соударения
            double vX = vParticle * Math.Cos(alpha);
            double vY = vParticle * Math.Sin(alpha);
            particle = new Particle(new Point2D(0, 0), new Point2D(vX, vY), this);
            time = 0;
            this.scatterers = scatterers;
            this.fullTime = fullTime;
            this.deltaTime = deltaTime;
        }

        public List<StateOfParticleDetailed> Statistics
        {
            get
            {
                return statistics;
            }
        }


        /// <summary>
        /// Сеттер и геттер для текущего времени
        /// </summary>
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

        /// <summary>
        /// Сеттер и геттер для массива рассеивателей
        /// </summary>
        public Scatterer[] Scatterers
        {
            get
            {
                return scatterers;
            }
            set
            {
                scatterers = value;
            }
        }

        /// <summary>
        /// Сеттер и геттер для частицы. Название отличается от переменной, чтобы отличать от класса <c>Particle</c>
        /// </summary>
        public Particle ParticleScene
        {
            get
            {
                return particle;
            }
            set
            {
                particle = value;
            }
        }

        /// <summary>
        /// Сеттер и геттер для координаты сцены
        /// </summary>
        public Point2D Displacement
        {
            get
            {
                return displacement;
            }
            set
            {
                displacement = value;
            }
        }

        protected void initParticleCoordinates(Point2D coordinate)
        {
            particle.Coordinate = coordinate;
            oldState = new StateOfParticle(particle, time);

        }

        /// <summary>
        /// Функция запускает один эксперимент и записывает данные в статистику в фиксированные точки по времени
        /// </summary>
        public void Run()
        {
            while (time < fullTime) //Цикл, запускающий функцию <c>GetNextCollision</c>, пока текущее время не будет больше или равно времени эксперимента
            {
                GetNextCollision();                                             //Функция, выдающая состояние частицы после соударения.
            }
        }


        /// <summary>
        /// Функция, записывающая в статистику все точки от старой точки соударения до новой точки соударения
        /// </summary>
        protected void generateDots()
        {
            //В цикле проходимся по всем точкам по времени от ближайшей к времени старого соударения до нового соударения
            for(double pointTime = (Math.Truncate(oldState.Time / deltaTime) + 1) * (deltaTime); pointTime < time; pointTime += deltaTime)   
            {
                Point2D tempPoint = new Point2D();  //Временная точка, координаты которой расчитываются из времени и проекций скоростей частицы
                tempPoint.X = oldState.Particle.Velocity.X * (pointTime - oldState.Time) + oldState.Particle.Coordinate.X;
                tempPoint.Y = oldState.Particle.Velocity.Y * (pointTime - oldState.Time) + oldState.Particle.Coordinate.Y;
                Particle tempParticle = new Particle(tempPoint, oldState.Particle.Velocity, this);    //Частица с координатами временной точки
                statistics.Add(new StateOfParticleDetailed(tempParticle, pointTime, displacement, getScatterersByTime(pointTime))); //Добавляем элемент в статистику
            }
        }

        /// <summary>
        /// Функция, сохраняющая состояние частицы
        /// </summary>
        protected void setOldState()
        {
            oldState.Time = time;
            oldState.Particle = (Particle)particle.Clone();
        }

        abstract public void GetNextCollision();

        /// <summary>
        /// Функция, выдающая список рассеивателей-кругов, с координатами центров и конкретными радиусами в данный момент времени
        /// </summary>
        /// <param name="time">Текущее время</param>
        /// <returns>Список кругов-рассеивателей в текущий момент времени</returns>
        private List<Circle> getScatterersByTime(double time)
        {
            List<Circle> circles = new List<Circle>();  // Создаем список кругов
            foreach(Scatterer scatterer in scatterers)  // Перебираем все рассеиватели
            {
                Circle circle = new Circle();           // Создаем временную переменную для круга
                circle.Center = scatterer.Center;       // Присваиваем центру круга значение центра рассеивателя
                circle.Radius = scatterer.Radius(time); // Присваиваем радиусу круга значение радиуса рассеивателя в текущий момент времени
                circles.Add(circle);                    // Записываем временный круг в список кругов
            }
            return circles;
        }


    }
}
