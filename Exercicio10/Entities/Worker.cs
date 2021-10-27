using System.Collections.Generic;
using Exercicio10.Entities.Enums;
namespace Exercicio10.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; } //Associação entre classes e Enum
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //Associação entre classes diferentes 1 pra 1
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();//Associação de classes diferentes 1 pra muitos onde foi criada uma lista e instanciado a uma lista vazia

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) //Nao incluir no construtor um para muitos, no caso a lista
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;    
        }

        public void AddContract(HourContract contract) //Recebe uma objeto do tipo HourContract
        {
            Contracts.Add(contract); //Adiciona esse objeto a Lista Contracts
        }

        public void RemoveContract(HourContract contract) //Recebe uma objeto do tipo HorContract
        {
            Contracts.Remove(contract);  //Remove esse objeto a Lista Contracts
        }

        public double Income(int year, int month) //Metodo que recebe um ano e um mês
        {
            double sum = BaseSalary; 
            foreach (HourContract contract in Contracts) //Para cada contrato na lista de Contratos
            {
                if (contract.Date.Year == year && contract.Date.Month == month) //Se o ano e o mês forem iguais ao parâmetro recebido
                {
                    sum += contract.TotalValue(); //Soma ao valor do contrato utilizando o metodo TotalValue
                }
            }
            return sum; //Retorna a soma
        }
    }
}
