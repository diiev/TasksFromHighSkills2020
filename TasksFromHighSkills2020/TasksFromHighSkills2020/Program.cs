using System;

namespace TasksFromHighSkills2020
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
                Задача № 1
                Задание оценивается в 4 балла
                У вас есть последовательность бросков монеты. 
                Каждый бросок записан в массиве. 
                Вам необходимо вычислить самую длинную последовательность из орлов 
                и самую длинную последовательность из решек. 
                Пример входных данных:
                ["орёл", "решка", " решка ", "решка", "орёл", " орёл ", " орёл ", " решка"];
                Пример выходных:
                Самая длинная последовательность решек: 3
                Самая длинная последовательность орлов: 3            
             */
            string[] arr = new string[] {"решка", "решка", "решка", 
                  "решка", "орёл", "решка", "решка",  "орёл", "орёл", "орёл"};
              int count = 1;
              int maxOrel = 0;
              int maxReshka = 0;

              for (int i = 0; i < arr.Length; i++)
              {
                  count = 1;
                 for (int j = i+1; j < arr.Length; j++)
                  {
                      if (arr[i] == "орёл" && arr[j] == "орёл")
                      {
                          count++;
                          if (count > maxOrel)
                              maxOrel = count;
                      }
                      else
                          break;
                  }
                  for (int k = i + 1; k < arr.Length; k++)
                  {
                      if (arr[i] == "решка" && arr[k] == "решка")
                      {
                          count++;
                          if (count > maxReshka)
                              maxReshka = count;
                      }
                      else
                          break;
                  }
              }
              Console.WriteLine($"Самая длинная последовательность орлов: {maxOrel}");
              Console.WriteLine($"Самая длинная последовательность решек: {maxReshka}"); 
            

        }
    }
}
