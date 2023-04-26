using ControleMedicamentos.ModuloPaciente;
using System.Collections;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloPaciente {
    public class TelaPaciente:TelaBase {
        RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente) {
            this.repositorioBase = repositorioPaciente;
            this.repositorioPaciente = repositorioPaciente;
        }

        protected override void MostrarTabela(ArrayList listaPacientes) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Paciente c in listaPacientes) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override EntidadeBase ObterRegistro() {
            Console.Write("Digite o nome do Paciente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do Paciente: ");
            string telefone = Console.ReadLine();

            Paciente paciente = new Paciente(nome, telefone);

            return paciente;
        }
    }
}
