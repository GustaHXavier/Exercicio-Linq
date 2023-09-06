using System.Globalization;
using System.IO;
using Entities;


internal class Program {
    private static void Main(string[] args) {

        Console.Write("Entre com o caminho do arquivo: ");
        string path = Console.ReadLine();

        Console.Write("Entre com salario: ");
        double sal = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        try {
            List<Funcionario> func = new List<Funcionario>();

            using (StreamReader sr = File.OpenText(path)) {
                while (!sr.EndOfStream) {

                    string[] vet = sr.ReadLine().Split(',');

                    string name = vet[0];
                    string mail = vet[1];
                    double salario = double.Parse(vet[2], CultureInfo.InvariantCulture);

                    func.Add(new Funcionario(name, mail, salario));
                }

                Console.WriteLine();
                foreach (Funcionario fun in func) {
                    Console.WriteLine(fun);
                }
                Console.WriteLine();

                var email = func.Where(f => f.Salario > sal).OrderBy(f => f.Email).Select(f => f.Email);
                foreach (string em in email) {
                    Console.WriteLine(em);
                }

                Console.WriteLine();
                var soma = func.Where(f => f.Nome[0] == 'M').Sum(f => f.Salario);
                Console.Write("Soma dos salarios das pessoas que começam com M: " + soma.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
        catch (IOException e) {
            Console.WriteLine("ERRO");
            Console.WriteLine(e.Message);
        }
    }
}