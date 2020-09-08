using System;
using System.Collections.Generic;
using DateTimeCalculator.Models;
using DateTimeCalculator.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DateTimeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {

            //Dependencies setup
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddSingleton<IDateCalculator, DateCalculator>()
                .AddSingleton<IInputReader, ConsoleInputReader>()
                .BuildServiceProvider();

            IInputReader reader = serviceProvider.GetService<IInputReader>();
            IDateCalculator calculator = serviceProvider.GetService<IDateCalculator>();


            //input
            List<InputEntity> list = reader.readInput();

            //calculate
            List<OutputEntity> outputList = calculator.Calculate(list);

            //output
            DisplayResult(outputList);

        }

        private static void DisplayResult(List<OutputEntity> outputList)
        {
            System.Console.WriteLine("========Results=========");
		    System.Console.WriteLine("Date,\t Operation, Params(days, weeks, months, years),  Result");
            foreach( var output in outputList)
            {
                if(output.Params!=null)
                {
                    System.Console.WriteLine("{0}   {1}   ({2}, {3}, {4}, {5})    {6} ",
                                         output.Date.ToString("dd/MM/yyy"),
                                         output.Operation,
                                         output.Params[0],
                                         output.Params[1],
                                         output.Params[2],
                                         output.Params[3],
                                         output.Result);
                }
                else
                {
                    System.Console.WriteLine("{0}   {1}   (No params)    {2} ",
                                         output.Date.ToString("dd/MM/yyy"),
                                         output.Operation,
                                         output.Result);
                }
                
            }
        }
    }
}
