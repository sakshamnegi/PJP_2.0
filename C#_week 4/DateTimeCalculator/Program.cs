using System;
using System.Collections.Generic;
using System.IO;
using DateTimeCalculator.Data;
using DateTimeCalculator.Models;
using DateTimeCalculator.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DateTimeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //set config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                          .Build();

            
            //debug
            // System.Console.WriteLine(configuration.GetConnectionString("PostgresConnectionString"));

            //Dependencies and services setup
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<RecordsDbContext>(option=> option.UseNpgsql(configuration.GetConnectionString("PostgresConnectionString")))
                .AddSingleton<IDateCalculator, DateCalculator>()
                .AddSingleton<IInputReader, ConsoleInputReader>()
                .AddScoped<IRepository, RecordsRepository>()
                .AddScoped<DbContext,RecordsDbContext>()
                .BuildServiceProvider();

            IInputReader reader = serviceProvider.GetService<IInputReader>();
            IDateCalculator calculator = serviceProvider.GetService<IDateCalculator>();
            IRepository repository = serviceProvider.GetService<IRepository>();
            DbContext dbContext = serviceProvider.GetService<DbContext>();

            dbContext.Database.EnsureCreated();


            // Dictionary<int, Delegate> methods = new Dictionary<int, Delegate>();
            // methods[0] = new Func<List<InputEntity>>(ReadAll);
            // methods[1] = new Func<InputEntity>(ReadOne);
            // methods[2] = new Action(DisplayCurrent);
            // methods[3] = new Action(DisplayAll);

            //input
            List<InputEntity> list = reader.ReadMultipleInputs();

            // //calculate
            List<OutputEntity> outputList = calculator.Calculate(list);

            //save to DB
            foreach(var op in outputList)
            {
                repository.AddRecord(op);
            }

            //output
            System.Console.WriteLine("\n============Successfully Added to Database=============\n");
            int exitChoice = 1;
            do
            {
                System.Console.WriteLine("\n1. Display Current Session Records \n2. Display All Records \n(Any Other). Exit : ");
            
                if(Int32.TryParse(Console.ReadLine(), out exitChoice))
                {
                    switch(exitChoice)
                    {
                        case 1:
                            DisplayCurrentResults(outputList);
                            break;
                        case 2:
                            DisplayAllDatabaseRecords(repository);
                            break;
                        default:
                            break;
                    
                    }
                }
                else
                {
                    break;        
                }
            }while(exitChoice==1 || exitChoice==2);
            
            

        }

        private static void DisplayAllDatabaseRecords(IRepository repository)
        {
            System.Console.WriteLine("============Database Records=============");
            
            IEnumerable<OutputEntity> records = repository.GetRecords();
            Display(records);
        }

        private static void DisplayCurrentResults(List<OutputEntity> outputList)
        {
            System.Console.WriteLine("===========Results============");
		    Display(outputList);
        }
        private static void Display(IEnumerable<OutputEntity> records)
        {
            System.Console.WriteLine($"|{"ID",5}|{"Timestamp",20}|{"Date",15}|{"Operation",15}|{"TimeParams(days, weeks, months, years)",40}|{"Result",10}|");

            foreach (var record in records)
            {
                System.Console.WriteLine($"|{record.Id,5}|{record.Timestamp,20}|{record.Date.ToString("dd/MM/yyy"),15}|{record.Operation,15}|{record.TimeParams,40}|{record.Result,10}|");

            }
        }

        
    }
}
