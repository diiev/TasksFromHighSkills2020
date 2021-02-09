using System;
using System.Collections.Generic;

namespace TasksFromHighSkills2020
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Задача № 6
            Задание оценивается в 15 баллов
            Вы работаете в компании, предоставляющей услуги сотовой связи. 
            В вашей компании существуют уникальные тарифы, 
            которые действуют только для определенных номеров. 
            Чтобы получить такой тариф сумма цифр половины номера, 
            должна быть равна сумме цифр второй половине. Например, номер 10340602 
            может получить тариф, так как 1+0+3+4 = 8, и сумма второй половины тоже равна 8, 0+6+0+2 = 8. 
            На вход дается чётное число L, обозначающее длину номера (количество цифр в билете). 
            Вы должны вернуть количество номеров с уникальным тарифом.
            Пояснение: если L = 4, то 
            у нас могут быть номера: 0000, 0001, 0002, 0003, 0004 … 0009, 0010, 0011 … 9999. 
            Из всех этих номеров вычислите номера с уникальным тарифом. 
            Пример входных данных:
            4
            Пример выходных:
            670
             */
            // Решение № 1
            int L = 4;
            int count = 0;
            for (int i = 0; i < Math.Pow(10, L); i++)
            {
                string num = i.ToString().PadLeft(L, '0');
                int sum1 = 0;
                int sum2 = 0;
                for (int j = 0; j < L; j++)
                {
                    if (j < L / 2)
                        sum1 += int.Parse(num[j].ToString());
                    else
                        sum2 += int.Parse(num[j].ToString());
                }
                if (sum1 == sum2)
                    count++;
            }
            Console.WriteLine(count);

            // Решение 2 (Динамическое)
            int N = 4;
            long[] totals = new long[(N / 2) * 9 + 1];
            long[] digits = new long[(N / 2) * 9 + 1];
            long maxs, maxt, lucky_tickets = 0;
            for (int i = 0; i <= 9; i++)
                totals[i] = 1;
            for (int i = 2; i <= N / 2; i++)
            {
                maxs = i * 9;
                maxt = maxs - 9;
                for (int j = 0; j <= maxt; j++)
                {
                    digits[j] = totals[j];
                }
                for (int a = 0; a < maxs; a++)
                    totals[a] = 0;
                for (int k = 0; k <= 9; k++)
                {
                    for (int d = 0; d <= maxt; d++)
                    {
                        totals[d + k] += digits[d];
                    }
                }
            }

            for (int i = 0; i <= (N / 2) * 9; i++)
            {
                lucky_tickets += totals[i] * totals[i];
            }
            Console.WriteLine(lucky_tickets);
        }
    }
}
