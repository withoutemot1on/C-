using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO3
{
    class Program
    {
        static void Main(string[] args)
        {
            double lambda, tobs, mu, ro, s, trab, Po;
            Console.WriteLine("Введите число каналов СМО N: ");
            int M = int.Parse(Console.ReadLine());
            int N = 3;          //число 
            lambda = 6;         //интенсивность прибытия автомобилей aвт./день
            tobs = 4;           //время обслуживания автомобиля в часах
            trab = 12;          //продолжительность рабочего дня в часах
            mu = trab / tobs;   //среднее число автомобилей
            ro = lambda / mu;   //интенсивность потока автомобилей
            s = Math.Pow(ro, N + 1) / (F(N) * (N - ro))*(1-Math.Pow(ro/N,M));
            for (int i = 0; i <= N; i++) s += Math.Pow(ro, i) / F(i);
            Po = 1 / s;
            Console.WriteLine("1.Вероятность простоя фасовщиков Po = {0,8:f4}", Po);
            double Potk = Po * Math.Pow(ro, N+M) / (F(N)*Math.Pow(N,M));
            Console.WriteLine("2.Вероятность отказа при занятости всех фасовщиков Potk = {0,8:f4}", Potk);
            double Pobs = 1-Potk;
            Console.WriteLine("3.Вероятность обслуживания Pobs = {0,8:f4}", Pobs);
            double A = Pobs*lambda;
            Console.WriteLine("4.Абсолютная пропускная способность A = {0,8:f4}", A);
            double nz = A / mu;
            Console.WriteLine("5.Число фасовщиков занятых разгрузкой nz = {0,8:f4}", nz);
            double a = Math.Pow(ro,N+1)/(N*F(N));//Вспомогательные вычисления(a,b и с для Loch)
            double b = 1 - Math.Pow(ro / N, M) * (M + 1 - (M * ro) / N);
            double c = Math.Pow(1 - ro / N, 2);
            double Loch = Po * a * b / c;
            Console.WriteLine("6.Среднее число автомобилей в очереди tsmo = {0,8:f4}", Loch);
            double toch = Loch / lambda;
            Console.WriteLine("7.Среднее время ожидания разгрузки nz = {0,8:f4}", toch);
            double z = Loch+nz;
            Console.WriteLine("8.Среднее число машин в магазине z = {0,8:f4}", z);
            double tsmo = z / lambda;
            Console.WriteLine("9.Среднее время прибывания машин в магазине tsmo = {0,8:f4}", tsmo);
            Console.ReadKey();
        }
        public static int F(int x)
        {
            return (x == 0) ? 1 : x * F(x - 1);
        }
    }
    
}
