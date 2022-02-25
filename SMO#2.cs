using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMO2
{
    class Program
    {
        static void Main(string[] args)
        {
            double lambda, tobs, mu, ro, s, ndet, Po;
            Console.WriteLine("Введите число каналов СМО N: ");
            int N = int.Parse(Console.ReadLine());
            ndet = 30;          //среднее число деталей в час
            lambda = ndet / 60; //среднее число деталей в минуту
            tobs = 3;           //время обслуживания в минутах
            mu = 1 / tobs;      //среднее число заявок в минуту
            ro = lambda / mu;   //интенсивность нагрузки
            s = Math.Pow(ro,N+1)/(F(N)*(N-ro));
            for (int i = 0; i <= N; i++) s += Math.Pow(ro, i) / F(i);
            Po = 1 / s;
            Console.WriteLine("1.Вероятность простоя контролеров-кассиров Po = {0,8:f4}", Po);
            double Pz = Po * Math.Pow(ro, N) / F(N);
            Console.WriteLine("2.Вероятность застать всех кассиров занятыми Pz = {0,8:f4}", Pz);
            double Poch = Math.Pow(ro,N+1)*Po/(F(N)*(N-ro));
            Console.WriteLine("3.Вероятность обслуживания Poch = {0,8:f4}", Poch);
            double Loch = Math.Pow(ro,N+1)*Po/(F(N-1)*Math.Pow(N-ro,2));
            Console.WriteLine("4.Среднее число клиентов в очереди Loch = {0,8:f4}",Loch);
            double toch = Loch / lambda;
            Console.WriteLine("5.Число кассиров занятых обслуживанием toch = {0,8:f4}", toch);
            double tsmo = toch+tobs;
            Console.WriteLine("6.Среднее время пребывания клиента в кассе tsmo = {0,8:f4}", tsmo);
            double nz = ro;
            Console.WriteLine("7.Среднее число занятых кссиров nz = {0,8:f4}", nz);
            double nsv = N - nz;
            Console.WriteLine("8.Среднее число свободных кссиров nsv = {0,8:f4}", nsv);
            double kz = nz / N;
            Console.WriteLine("9.Коэффициентзанятости кассиров kz = {0,8:f4}", kz);
            double sr = Loch + nz;
            Console.WriteLine("10.Среднее число клиентов в сберкассе sr = {0,8:f4}", sr);
            Console.ReadKey();
        }
        public static int F(int x)
        {
            return (x == 0) ? 1 : x * F(x - 1);
        }
    }
    
}
