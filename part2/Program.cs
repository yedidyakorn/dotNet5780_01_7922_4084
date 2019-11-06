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
                Console.WriteLine("Enter Choice: 1-enter new vication.\t 2-show whole list. \t 3-show taken dates.\t 0-exit");//menu

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

        private static void newDate(bool[,] max)//checks if the date is avalible
        {
            int month, day, duration,begD,endD;
            Console.WriteLine("Enter month:");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date:");
            day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter how many days:");
            duration = Convert.ToInt32(Console.ReadLine());
            bool[] arr = new bool[372];
            maxToArry(max,arr);//converts the calnder to one long array
            begD = (month-1) * 31 + day-1;//begining day
            endD = begD + duration;//ending day
            if(month>12||month<1||day<1||day>31||endD>372||duration<2)// input check
            {
                Console.WriteLine("ERROR - invalid input.");
                return;
            }                       
            if((arr[begD]==true&&arr[begD+1]==true)||(arr[endD]==true&&arr[endD-1]==true))//checks if avalible
            {
                Console.WriteLine("not avalible these dates");
                 return;
            }
            for (int i=begD+1;i<endD-1;i++)//checks if avalible
            {
                if(arr[i]==true)
                {
                    Console.WriteLine("not avalible these dates");
                    return;
                }
            }
            for (int i = begD; i < endD; i++)//marks as taken
                arr[i] = true;
            arrayToMax(max,arr);//converts back to calnder
            return;
            throw new NotImplementedException();
        }

        private static void maxToArry(bool[,] max,bool[]arr)//convorts a array to matrix 
        {
            int k = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    arr[k] = max[i, j];
                    k++;
                }
            }
            return;
            throw new NotImplementedException();
        }

        private static void arrayToMax(bool[,] max, bool[] arr)//convorts a matrix to array
        {
            int k = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    max[i,j] = arr[k];
                    k++;
                }
            }
            return;
            throw new NotImplementedException();
        }
      
        private static void all(bool[,] arr)
        { 

            int day = 1, month = 1;

            //flag for vacation period
            bool isCounting = false;

            while (month < 13)
            {
                //calc current day - Reset to 1 if over 31
                //set counting vaction period = true
                day = day % 31 == 0 ? 31 : day % 31;
                var currentDay = arr[month - 1, day - 1];
                if (currentDay == true && !isCounting )
                {
                    Console.Write("Start date : " + day + "/" + month);
                    isCounting = true;
                }
                //if vaction ended, isCounting = false
                //or its the last day of the year
                else if ((currentDay == false || (currentDay == true && day == 31 && month == 12)) && isCounting)
                {              
                    Console.WriteLine(" , End date : " + (day -1 == 0 ? 31: day - 1) + "/" +  ((day-1 == 0) ? month-1:  month));
                    isCounting = false;
                }
                //increase day 
                day++;
                //calc if month should be increased
                month += day / 32;
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
