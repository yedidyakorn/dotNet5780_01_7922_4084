using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 1;
            bool[,] arr = new bool[12, 31];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                    arr[i, j] = false;
            }

            if (choice != 0)
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

        private static void newDate(Boolean[,] arr)//checks if the date is avalible
        {
            int month, date, days;
            Console.WriteLine("Enter month:");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date:");
            date = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter how many days::");
            days = Convert.ToInt32(Console.ReadLine());
            if (arr[month - 1, date - 1])

                throw new NotImplementedException();
        }


        private static void all(bool[,] arr)
        { 

            int day = 1, month = 1;
            bool isCounting = false;
            while (month < 12)
            {
                month += day / 32;
                day = day % 31 == 0 ? 31 : day % 31;               
                if (arr[ month - 1, day - 1] == true && !isCounting )
                {
                    Console.Write("Start date : " + day + "/" + month);
                    isCounting = true;
                } else if (arr[month - 1, day - 1] == false && isCounting)
                {              
                    Console.WriteLine(" , End date : " + (day -1 == 0 ? 31: day - 1) + "/" +  ((day-1 == 0) ? month-1:  month));
                    isCounting = false;
                }

                day++; 
            }           
        }              
        

        private static void taken (bool[,] arr)//prints how many days are taken
        {
            int counter = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = 0; j < arr.GetLength(1); j++)
                    if (arr[i, j] == true)
                        counter++;     //Summarize the busy days
            float percentageOfOccupancy = (((float)counter / 372)*100);   //Percentage calculation
            Console.WriteLine("The number of busy days per year:{0}\nPercentage of annual occupancy:{1}% ", counter,  percentageOfOccupancy);
        }
    }
}
