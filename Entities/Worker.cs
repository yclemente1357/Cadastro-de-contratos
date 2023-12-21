using System;
using System.Collections.Generic;
using Course.Entities.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Course.Entities
{
    class Worker
    {
        public string Name { get; set; }

// Propriedade do tipo enum (WorkerLevel), utilizada para coletar e referenciar os tipos de Levels
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
// Criando uma lista do tipo HpursContract, assim será armazenados os dados por sequencia no cadastro dos contratos
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // não inclua a associação para muitos no construtor

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

// Método para adcionar um contrato, assim irá coletar os dados preenchidos de HourContract cada vez que for inserido um valor, dessa forma os valores serão armazenados e não sobrepostos
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

// Método para calcular cada contrato de acordo com os dados inseridos em HourContract, sempre com base no mês e ano filtrado
        public double Income(int year, int month) // ganho
        {
            double sum = BaseSalary;

            foreach (HourContract contract in Contracts) { 
                if(contract.Date.Year == year && contract.Date.Month ==  month)
                {                
                    sum += contract.TotalValue();
                }  
            }
            return sum;
        }
    }
}
