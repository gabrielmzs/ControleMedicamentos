using ControleMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloPaciente {
    public class TelaPaciente:Tela {
        RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente) {
            this.repositorioPaciente = repositorioPaciente;
        }
        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Paciente");
            Console.WriteLine("2 - Visualizar Pacientes");
            Console.WriteLine("3 - Editar Pacientes");
            Console.WriteLine("4 - Deletar Pacientes");
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Paciente: ", "Inserindo um novo Paciente...");
            Paciente paciente = ObterPaciente();
            repositorioPaciente.Inserir(paciente);
            MostrarMensagem("Paciente inserido com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Pacientes Cadastrados: \n");
            ArrayList listaPacientes = repositorioPaciente.SelecionarTodos();
            if (listaPacientes.Count == 0) {
                MostrarMensagem("Não há Pacientes cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaPacientes);
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Paciente: ", "Editando um Paciente...");
            Visualizar();
            Console.Write("\nDigite o ID da Paciente a ser editado: ");
            int id = int.Parse(Console.ReadLine());
            Paciente pacienteAtualizada = ObterPaciente();

            repositorioPaciente.Editar(id, pacienteAtualizada);
            MostrarMensagem("Paciente editado com sucesso!", ConsoleColor.Green);

        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Paciente: ", "Deletando um Paciente...");
            Visualizar();
            Console.Write("\nDigite o ID do Paciente a ser deletado: ");
            int id = int.Parse(Console.ReadLine());
            repositorioPaciente.Excluir(id);
            MostrarMensagem("Paciente deletado com sucesso!", ConsoleColor.Green);
        }

        private void MostrarTabela(ArrayList listaPacientes) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Paciente c in listaPacientes) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Paciente ObterPaciente() {
            Console.Write("Digite o nome do Paciente: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do Paciente: ");
            string telefone = Console.ReadLine();

            Paciente paciente = new Paciente(nome, telefone);

            return paciente;
        }
    }
}
