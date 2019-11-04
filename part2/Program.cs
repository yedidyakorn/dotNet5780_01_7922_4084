using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static bool[,] nights = new bool[12, 31];
        static void Main(string[] args)
        {
            int choice = 1;
            bool[,] arr = new bool[12, 31];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = false;
            }
            while (choice != 0)
            {
                Console.WriteLine("Enter Choice: 1-enter new vication.\t 2-show whole list. \t 3-show taken dates.\t 0-exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        newDate(arr);
                        break;
                    case 2:
                        all(arr);
                        break;
                    case 3:
                        taken(arr);
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }

        }

        private static void newDate(bool[,] arr)//checks if the date is avalible
        {
            int month, day, duration,endM,endD;
            Console.WriteLine("Enter month:");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date:");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter how many days:");
            duration = Convert.ToInt32(Console.ReadLine());
            endM = month + ((day + duration) / 31);
            endD = duration + day - (31 * (endM - month));
            if(month>12||month<1||endM>12||day<1||day>31||endD>31||endD<1||duration<2)//checks input
            {
                Console.WriteLine("ERROR - invalid input.");
                return;
            }
            if (month==endM)
            {
                for (int i = day; i < endD-1; i++)//checks if avilable
                {
                    if (nights[month-1, i-1] == true)
                    {
                        Console.WriteLine("not avalible these dates");
                        return;
                    }
                }
                for (int i = day; i < endD - 1; i++)//marks as taken
                {
                    nights[month - 1, i - 1] = true;
                    arr[month - 1, i - 1] = true;
                }
                arr[month - 1, endD-1] = true;
                return;
            }
            else
            {
                for (int i = day; i < 32; i++)//checks if avilable- first month
                {
                    if (nights[month - 1, i - 1] == true)
                    {
                        Console.WriteLine("not avalible these dates");
                        return;
                    }
                }
                for(int i=month+1;i< endM-1;i++)
                {
                    for (int j = 1; j < 32; j++)//checks if avilable- midlle monthes
                    {
                        if (nights[i - 1, j - 1] == true)
                        {
                            Console.WriteLine("not avalible these dates");
                            return;
                        }
                    }
                }
                for (int i = 1; i < endD; i++)//checks if avilable- last month
                {
                    if (nights[endM-1, i - 1] == true)
                    {
                        Console.WriteLine("not avalible these dates");
                        return;
                    }
                }
                for (int i = day; i < 32; i++)//marks as taken- first month
                {
                    nights[month - 1, i - 1] = true;
                    arr[month - 1, i - 1] = true;
                }
                for (int i = month + 1; i < endM - 1; i++)
                {
                    for (int j = 1; j < 32; j++)//marks as taken- midlle monthes
                    {
                        nights[i - 1, j - 1] = true;
                        arr[i - 1, j - 1] = true;
                    }
                }
                for (int i = 1; i < endD; i++)//marks as taken- last month
                {
                    nights[endM - 1, i - 1] = true;
                    arr[endM - 1, i - 1] = true;
                }
                arr[month - 1, endD - 1] = true;
                return;
            }
                throw new NotImplementedException();
        }

        private static void all(bool[,] arr)//prints out all the calnder
        {
            throw new NotImplementedException();
        }

        private static void taken (bool[,] arr)//prints how many days are taken
        {
            throw new NotImplementedException();
        }
    }
}
