using Exercicio10.Entities;
using Exercicio10.Entities.Enums    ;
using System;
using System.Globalization;

namespace Exercicio10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Junior/MidLevel/Senior: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //Recebe uma variável enum convertendo para string
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName); //Instanciando objeto departamento
            Worker worker = new Worker(name, level, baseSalary, dept); //Instancia o objeto Worker passando como parâmetro o objeto dept
            
            
            Console.WriteLine("How many contract to this worker?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date: (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHouer = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHouer, hours); //Passa parâmetros para o construtor HoursContract  
                worker.AddContract(contract); //método do Worker que adiciona os contratos 
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2)); //Recorta a string e armazena na variável int
            int year = int.Parse(monthAndYear.Substring(3));//Recorta a string e armazena na variável mês
            Console.WriteLine("Name: " + worker.Name); //Chama o objeto Worker e imprime o nome
            Console.WriteLine("Department: " + worker.Department.Name);//Chama o objeto worker que chama o objeto Department e imprime o nome do departamento.
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)) ; //Chama o método Income da classe Worker do objeto worker pasasando como parâmetro o ano e o mês  
        }
    }
}
