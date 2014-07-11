using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirportClassLibrary1
{
    public class airport
    {
        public
        int maxspeed = 700;
        int speed = 0;
        int fuel = 0;
        int maxfuel = 10;
        int height = 0;
        int maxheight = 900;
        bool engine = false;
        public int Getspeed()
        {
            return speed;
        }
        public int Getheight()
        {
            return height;
        }
        public int Getfuel()
        {
            return fuel;
        }
        public int Getmaxspeed()
        {
            return maxspeed;
        }
        public int Getmaxfuel()
        {
            return maxfuel;
        }
        public int Getmaxheight()
        {
            return maxheight;
        }
        public bool Getengine()
        {
            return engine;
        }
                  //
        public void Setspeed(int c)
        {
            this.speed = c;
        }
        public void Setmaxspeed(int c)
        {
            this.maxspeed = c;
        }
        public void Setfuel(int c)
        {
            this.fuel = c;
        }
        public void Setmaxfuel(int c)
        {
            this.maxfuel = c;
        }
        public void Setheight(int c)
        {
            this.height = c;
        }
        public void Setmaxheight(int c)
        {
            this.maxheight = c;
        }
        public void Setengine(bool c)
        {
            this.engine = c;
        }


        int ind; //это индекс объекта. это временная переменная, которую можно удалить, если реализуешь иначе. но она пока для того, что бы вызов метода "респаун" не ругался.***
        //но сейчас он нафиг не нужен, так как мы создаём только 1 экземпляр








        public airport()
        {
            fuel = 10;
            Console.WriteLine("Диспетчерская. Система управления самолетами.");




        }
        public void getfuel()  // заправка     
        {
            fuel = maxfuel;

        }
        public void morespeed(int a)   // увелич. скорости
        {




            fuel = fuel - a * maxfuel * 5 / 100;  //на каждое изм. скорости требуется 5 проц от макс кол-ва топлива
            if (speed + a < maxspeed)
            {
                speed = speed + a;

            }
            else
            {
                Console.WriteLine("Нельзя увеличить скорость на данное значение, превышает макс. скорость.");

            }




        }
        public void lessspeed(int a)   // уменьш. скорости
        {


            if (speed - a > 0)
            {
                speed = speed - a;

            }
            else
            {
                speed = 0;

            }
            if (speed < maxspeed / 100)   // при слишком низкой скорости самолет разбивается
            {
                height = 0;
                Console.WriteLine("Слишком низкая скорость. Самолет упал и разбился.");
            }
        }
        public void moreheight(int a)   // увелич. высоты
        {
            fuel = fuel - a * maxfuel / 100;  //на каждое изм. высоты требуется 10 проц от макс кол-ва топлива
            if (height + a < maxspeed)
            {
                height = height + a;

            }
            else
            {
                Console.WriteLine("Нельзя увеличить высоту на данное значение, превышает макс. высоту.");

            }
        }
        public void lessheight(int a)   // уменьш. высоты
        {


            if (height - a > 0)
            {
                height = height - a;

            }
            else   // при уменьш. высоты до уровня земли проверяется скорость самолета, если она слишком большая самолет разбивается
            {
                if (speed > maxspeed * 50 / 100)
                {
                    height = 0;
                    Console.WriteLine("Самолет разбился.");




                }
                else
                {
                    height = 0;
                    Console.WriteLine("Самолет приземлился.");

                }
            }
        }
        public void startengine()
        {
            engine = true;
            Console.WriteLine("Запуск двигателя.");

        }
        public void stopengine()
        {
            engine = false;
            Console.WriteLine("Отключение двигателя.");



        }
    }




}
