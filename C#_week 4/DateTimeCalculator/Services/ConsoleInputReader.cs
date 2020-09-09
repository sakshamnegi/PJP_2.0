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
        public List<InputEntity> ReadMultipleInputs()
        {
           List<InputEntity> list = new List<InputEntity>();
           int choice=1;
           do
           {
                InputEntity input = ReadSingleInput();
                if(input==null)
                {
                    return list;
                }
                list.Add(input);
                System.Console.WriteLine("Want to enter more ? 1.Yes  2.No");
                Int32.TryParse(Console.ReadLine(), out choice);
           } while (choice ==1);
           return list;
        }

        public InputEntity ReadSingleInput()
        {
            System.Console.WriteLine("Enter Date in format " + _DatePattern);
            string dateStr = Console.ReadLine();
            DateTime date = DateTime.ParseExact(dateStr,_DatePattern,CultureInfo.InvariantCulture);
            System.Console.WriteLine("Choose Operation : ");
            System.Console.WriteLine("1. Add \n2. Subtract\n3. Determine day of week\n4. Determine week number");
            int ch;
            string param = "0 0 0 0";
            if(Int32.TryParse(Console.ReadLine(), out ch))
            {
                DateOperation operation = ch == 1 ? DateOperation.ADD : DateOperation.SUBTRACT;
                switch (ch)
                {
                    case 1:
                        //fall through to subtract
                    case 2:
                        System.Console.WriteLine("Enter days, weeks, months, years to " + (ch == 1 ? "Add" : "Subtract")
                        + " in the Format : (days weeks months year)");
                        param = Console.ReadLine();
                        break;
                    case 3:
                        operation = DateOperation.DAY_OF_WEEK;
                        break;
                    case 4:
                        operation = DateOperation.WEEK_OF_YEAR;
                        break;

                    default:
                        System.Console.WriteLine("Invalid choice. Exiting from Input Reader");
                        return null;
                }
                return new InputEntity(date,param, operation);

            }
            else
            {
                System.Console.WriteLine("Invalid choice. Exiting from Input Reader");
                return null;
            }
        }
    }
}