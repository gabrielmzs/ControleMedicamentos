using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFuncionario {
    public class TelaFuncionario : Tela {

        RepositorioFuncionario repositorioFuncionario;
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario) {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Funcionários");
            Console.WriteLine("2 - Visualizar Funcionários");
            Console.WriteLine("3 - Editar Funcionários");
            Console.WriteLine("4 - Deletar Funcionários");
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Funcionários: ", "Inserindo um novo funcionário...");
            Funcionario funcionario = ObterFuncionario();
            repositorioFuncionario.Inserir(funcionario);
            MostrarMensagem("Funcionário inserido com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Funcionarios Cadastrados: \n");
            ArrayList listaFuncionarios = repositorioFuncionario.SelecionarTodos();
            if (listaFuncionarios.Count == 0) {
                MostrarMensagem("Não há funcionários cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaFuncionarios);
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Funcionários: ", "Editando um funcionário...");
            Visualizar();
            Console.Write("\nDigite o ID da funcionário a ser editado: ");
            int id = int.Parse(Console.ReadLine());

            Funcionario funcionarioAtualizada = ObterFuncionario();

            repositorioFuncionario.Editar(id, funcionarioAtualizada);
            MostrarMensagem("Funcionário editado com sucesso!", ConsoleColor.Green);

        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Funcionários: ", "Deletando um funcionário...");
            Visualizar();
            Console.Write("\nDigite o ID da funcionário a ser deletado: ");
            int id = int.Parse(Console.ReadLine());
            repositorioFuncionario.Excluir(id);
            MostrarMensagem("Funcionário deletado com sucesso!", ConsoleColor.Green);
        }
        
        private void MostrarTabela(ArrayList listaFuncionarios) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Funcionario c in listaFuncionarios) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Funcionario ObterFuncionario() {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, telefone);

            return funcionario;
        }

    }

}

