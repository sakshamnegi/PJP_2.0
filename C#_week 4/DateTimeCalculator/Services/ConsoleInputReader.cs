using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DateTimeCalculator.Models;

namespace DateTimeCalculator.Services
{
    public class ConsoleInputReader : IInputReader
    {
        private static string _DatePattern = "dd/MM/yyyy"; 
        public List<InputEntity> readInput()
        {
           List<InputEntity> list = new List<InputEntity>();
           int choice=1;
           do
           {
               System.Console.WriteLine("Enter Date in format " + _DatePattern);
               string dateStr = Console.ReadLine();
               Debug("Input date string " + dateStr);
               DateTime date = DateTime.ParseExact(dateStr,_DatePattern,CultureInfo.InvariantCulture);
               System.Console.WriteLine("Choose Operation : ");
               System.Console.WriteLine("1. Add \n2.Subtract\n3. Determine day of week\n4. Determine week number");
               int ch;
               int[] param = null;
               if(Int32.TryParse(Console.ReadLine(), out ch))
               {
                    Debug("OpCode " + ch);
                    DateOperation operation = ch == 1 ? DateOperation.ADD : DateOperation.SUBTRACT;
                    switch (ch)
                    {
                        case 1:
                            //fall through to subtract
                        case 2:
                            System.Console.WriteLine("Enter days, weeks, months, years to " + (ch == 1 ? "Add" : "Subtract")
                            + " in the Format : (days weeks months year)");
                            string op = Console.ReadLine();
                            string[] paramStr = op.Split(" ");
                            param = new int[] {0,0,0,0};
                            for(int i=0 ; i<paramStr.Length; i++)
                            {
                                param[i] = Convert.ToInt32(paramStr[i]);
                            }
                            break;
                        case 3:
                            operation = DateOperation.DAY_OF_WEEK;
                            break;
                        case 4:
                            operation = DateOperation.WEEK_OF_YEAR;
                            break;

                        default:
                            System.Console.WriteLine("Wrong choice. Exiting from Input Reader");
                            return list;
                    }
                    list.Add(new InputEntity(date,param, operation));
                    System.Console.WriteLine("Want to enter more ? 1.Yes  2.No");
                    Int32.TryParse(Console.ReadLine(), out choice);
                    

               }
               else
               {
                   System.Console.WriteLine("Invalid choice");
               }
               

           } while (choice ==1);
           return list;
        }

        public void Debug(string message)
        {
            System.Console.WriteLine(new StringBuilder().Append('=',10).Append("Debug").Append('=',10));
            System.Console.WriteLine(message);
        }
    }
}