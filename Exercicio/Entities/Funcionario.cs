using System.Globalization;

namespace Entities {
    internal class Funcionario {
        public string Nome { get; set; }
        public string Email { get; set; }
        public double Salario { get; set; }

        public Funcionario(string nome, string email, double salario) {
            Nome = nome;
            Email = email;
            Salario = salario;
        }

        public override string ToString() {
            return Nome
                + ", "
                + Email 
                + ", "
                + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
