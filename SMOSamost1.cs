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
            double lambda, tobs, mu, ro, s, ndet, Po;
            Console.WriteLine("Введите число каналов СМО N: ");
            int N = int.Parse(Console.ReadLine());
            ndet = 20;          //среднее число деталей в час
            lambda = ndet / 60; //среднее число деталей в минуту
            tobs = 6;           //время обслуживания в минутах
            mu = 1 / tobs;      //среднее число заявок в минуту
            ro = lambda / mu;   //интенсивность нагрузки
            s = 0;
            for (int i = 0; i <= N; i++) s += Math.Pow(ro, i) / F(i);
            Po = 1 / s;
            Console.WriteLine("1.Вероятность простоя канолов обслуживания Po = {0,8:f4}", Po);
            double Potk = Po * Math.Pow(ro, N) / F(N);
            Console.WriteLine("2.Вероятность отказа в обслуживании Potk = {0,8:f4}", Potk);
            double Pobs = 1 - Potk;
            Console.WriteLine("3.Вероятность обслуживания Pobs = {0,8:f4}", Pobs);
            double nz = ro * Pobs;
            Console.WriteLine("4.Среднее число занятых обслуживанием каналов nz = {0,8:f4}", nz);
            double kz = nz / N;
            Console.WriteLine("5.Доля каналов занятых обсулживанием kz = {0,8:f4}", kz);
            double A = lambda * Pobs;
            Console.WriteLine("6.Абсолютная пропускная способность А = {0,8:f4}", A);
            Console.ReadKey();
        }
        public static int F(int x)
        {
            return (x == 0) ? 1 : x * F(x - 1);
        }
    }  
}
