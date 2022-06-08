using Microsoft.Extensions.DependencyInjection;
using PatternCQRS.Commands;
using PatternCQRS.Queries;
using PatternCQRS.Repositories;
using System;

namespace ConsoleAppCQRSPattern
{  
    class Program {
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeCommands, EmployeeCommands>();
            services.AddScoped<IEmployeeQueries, EmployeeQueries>();
            services.AddScoped<IEmployeeCommandsRepository, EmployeeCommandsRepository>();
            services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();
        }
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            // Command the Employee Domain to save data  
            var employeeCommand = new EmployeeCommands(new EmployeeCommandsRepository());
            employeeCommand.SaveEmployeeData(new PatternCQRS.Models.Employee
            {
                Id = 200,
                FirstName = "Jane",
                LastName = "Smith",
                Street = "150 Toronto Street",
                City = "Toronto",
                PostalCode = "j1j1j1",
                DateOfBirth = new DateTime(2002, 2, 2)
            });
            Console.WriteLine($"Employee data stored");
            // Query the Employee Domain to get data  
            var employeeQuery = new EmployeeQueries(new EmployeeQueriesRepository());
            var employee = employeeQuery.FindByID(100);
            Console.WriteLine($"Employee ID:{employee.Id}, Name:{employee.FullName}, Address:{employee.Address}, Age:{employee.Age}");
            Console.ReadKey();
        }
    }  
} 