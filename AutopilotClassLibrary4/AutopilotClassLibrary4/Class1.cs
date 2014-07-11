using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metClassLibrary2;
using AirportClassLibrary1;
using InterfaceClassLibrary3;

namespace AutopilotClassLibrary4
{
    public class airportrefit : airport
    {
        int lenght = 0;
        int time = 0;
        public airportrefit()
        {

        }
        public int Getlenght()
        {
            return lenght;
        }
        public void Setlenght(int c)
        {
            this.lenght = c;
            
        }
        public int Gettime()
        {
            return time;
        }
        public void Settime(int c)
        {
            this.time = c;
        }

    }


    public class newmet : met
    {
        public static airportrefit newplane = new airportrefit();
        static public void print_menu1()  //  нельзя переопределить метод print_menu, поскольку он статич.
        {
            Console.WriteLine("Введите команду \n 1 - запуск двиг., \n 2 - остановка двиг., \n 3 - заправка, \n 4 - увелич. скорость, \n 5 - уменьшить скорость, \n 6 - увелич. высоту, \n 7 - уменьш. высоту. \n 8 - вызвать автопилот");
        }

        static public void center1()
        {
            Console.ReadKey();
            Console.Clear();
            print_menu1();
            int command = InterfaceClass.vvod();
            Console.Clear();    
            int hei = plane.Getheight();   // получение доступа к полям класса airport
            int speed = plane.Getspeed();
            int fuel = plane.Getfuel();
            if (hei > 0 && fuel == 0)     // проверка топлива на высоте больше нуля
            {
                Console.WriteLine("Нету топлива на высоте > 0. Самолет упал и разбился.");
                return;
            }
            switch (command)
            {

                case 1:
                    plane.startengine();
                    met.center();
                    break;
                case 2:

                    if (hei > 0)  // тут ты обращался просто к полю метода.. но я даже не понимаю как оно бы сработало у тебя в мэине) либо делай все поля пабликами и тогда не мучайся, либо дела Set и Get для каждого поля класса.
                    {
                        Console.WriteLine("Откл. двигателя на высоте > 0. Самолет упал и разбился.");
                    }
                    else
                    {
                        plane.stopengine();
                        met.center();
                    }
                    break;
                case 3:
                    if (hei == 0 && speed == 0)
                    {
                        plane.getfuel();
                        met.center();
                    }
                    else
                    {
                        Console.WriteLine("Невозможно осущ. заправку при скорости > 0 и при высоте > 0.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите увелич. скорости. (Макс скорость - 700 единиц.)");
                    int i = Convert.ToInt32(Console.ReadLine());
                    plane.morespeed(i);
                    met.center();
                    break;
                case 5:
                    Console.WriteLine("Введите уменьш. скорости. (Макс скорость - 700 единиц.)");
                    int j = Convert.ToInt32(Console.ReadLine());
                    plane.lessspeed(j);
                    met.center();
                    break;
                case 6:
                    Console.WriteLine("Введите увелич. высоты. (Макс высота - 900 единиц.)");
                    int t = Convert.ToInt32(Console.ReadLine());
                    plane.moreheight(t);
                    met.center();
                    break;
                case 7:
                    Console.WriteLine("Введите уменьш. высоты. (Макс высота - 900 единиц.)");
                    int m = Convert.ToInt32(Console.ReadLine());
                    plane.lessheight(m);
                    met.center();
                    break;
                case 8:    // вариант вызова автопилота ввод расстояния и времени  полета
                    Console.WriteLine("Вызов автопилота введите. Длину и время полета.");
                    int lenght = Convert.ToInt32(Console.ReadLine());
                    int time = Convert.ToInt32(Console.ReadLine());
                    
                    newplane.Setlenght(lenght);
                    newplane.Settime(time);
                    autopilot();
                    break;
                default:
                    Console.WriteLine("Введите команду из списка.");
                    met.center();
                    break;
            }
        }
        public static void autopilot() // передача управления автопилоту. передача полей обьекта plane обьекту newplane
        {                              // теперь все действия происходят с новым обьектом newplane
            newplane.Setfuel(met.Getfuel());         // а надо ли так заморачиватся с передачей полей туда сюда ... ?
            newplane.Setengine(met.Getengine());
            newplane.Setmaxfuel(met.Getmaxfuel());
            newplane.Setmaxspeed(met.Getmaxspeed());
            newplane.Setspeed(met.Getspeed());
            newplane.Setheight(met.Getheight());
            int fuel = newplane.Getfuel();
            bool engine = newplane.Getengine();
            int speed = newplane.Getspeed();
            int maxspeed = newplane.Getmaxspeed();
            int height = newplane.Getheight();
            int maxfuel = newplane.Getmaxfuel();
            // стандартный алгоритм автопилота - вкл. двигатель(если он выкл), если нет топлива - заправится,
            // поднятся на среднюю высоту со скоростью достаточной, чтобы долететь вовремя
            // если вкл. автопилот его нельзя выкл. до прибытия, это фича))
            if (fuel == 0)
            {
                newplane.Setfuel(maxfuel);
            }
            if (engine == false)
            {
                newplane.Setengine(true);
            }
            // сделано две проверки - если скорость требуемая для полета в точку оказалась больше макс
            // и если топливо после всего полета оказалось = нулю или отрицательным...
            
            speed = (int)(newplane.Getlenght() / newplane.Gettime());
            if (speed > maxspeed)
            {
                newplane.Setspeed(maxspeed);
            }

            height = 500;
            fuel = (fuel - (int)(newplane.Getlenght() / 2000)); // на каждую единицу топлива приходится 2000 единиц расстояния
            if (fuel <= 0)  // если хватит топлива самолет долетит до нужной точки
            {
                Console.WriteLine("Самолет не хватило топлива пролететь заданное расстояния. Упал и разбился.");
                fuel = 0;
            }
            else
            {
                Console.WriteLine("Самолет успешно долетел до нужной вам точки.");
            }
            met.Setfuel(fuel);     // обратная передача измененных полей
            met.Setengine(engine);
            met.Setspeed(speed);
            met.Setheight(height);
        }

    }
    

}
