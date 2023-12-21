using Course.Entities;
using Course.Entities.Enums;
using System.Globalization;

namespace Course
{
    class Program
    { 
        static void Main(string[] args)
        {
// rebendo dados para a Classe Worker
            Console.Write("Enter department's name: ");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter work data:");
            Console.Write("Name: ");
            string nameWorker = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
// Instanciando dept para Department
            Department dept = new Department(depName);
// Instanciando worker para Worker e recebendo dados do construtor
            Worker worker = new Worker(nameWorker, level, baseSalary, dept);

// Informando quantidade de contrato que será adcionado no processo
            Console.Write("How many contracts to this worker? ");
            int qtContract = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

// percorrendo os dados conforme o numero de contratos para incluir as informações do contrato
            for (int i = 1; i <= qtContract; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: "); // interpolação com a variavel i 
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());

// Instanciando contract para Hours, assim incluindo valores na classe
                HourContract contract = new HourContract(date, valuePerHour, hours);
// Chamando método para acionar contratos do tipo HourContract na Lista Contract feita em Worker
                worker.AddContract(contract);
            }

// Realizando a coleta das datas de filtragem
            Console.Write("Enter month and year to calculate income (MM/YY): ");
            string monthAndYear = Console.ReadLine();
// Recortando os valores da string para atribuir resultado as variáveis instanciadas
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

// Imprimindo valores Digitados
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department" + worker.Department.Name);
            Console.WriteLine($"Income for {month}/{year}: " + worker.Income(year, month).ToString("F2"), CultureInfo.InvariantCulture);
        }
    }
}
