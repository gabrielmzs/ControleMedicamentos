using ControleMedicamentos.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFornecedor {
    public class TelaFornecedor:Tela {
        RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor) {
            this.repositorioFornecedor = repositorioFornecedor;
        }
        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Fornecedor");
            Console.WriteLine("2 - Visualizar Fornecedores");
            Console.WriteLine("3 - Editar Funcionários");
            Console.WriteLine("4 - Deletar Funcionários");
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Fornecedor: ", "Inserindo um novo Fornecedor...");
            Fornecedor fornecedor = ObterFornecedor();
            repositorioFornecedor.Inserir(fornecedor);
            MostrarMensagem("Fornecedor inserido com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Fornecedores Cadastrados: \n");
            ArrayList listaFornecedors = repositorioFornecedor.SelecionarTodos();
            if (listaFornecedors.Count == 0) {
                MostrarMensagem("Não há Fornecedores cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaFornecedors);
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Fornecedor: ", "Editando um Fornecedor...");
            Visualizar();
            Console.Write("\nDigite o ID da Fornecedor a ser editado: ");
            int id = int.Parse(Console.ReadLine());
            Fornecedor fornecedorAtualizada = ObterFornecedor();

            repositorioFornecedor.Editar(id, fornecedorAtualizada);
            MostrarMensagem("Fornecedor editado com sucesso!", ConsoleColor.Green);

        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Fornecedor: ", "Deletando um Fornecedor...");
            Visualizar();
            Console.Write("\nDigite o ID do Fornecedor a ser deletado: ");
            int id = int.Parse(Console.ReadLine());
            repositorioFornecedor.Excluir(id);
            MostrarMensagem("Fornecedor deletado com sucesso!", ConsoleColor.Green);
        }

        private void MostrarTabela(ArrayList listaFornecedors) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Fornecedor c in listaFornecedors) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Fornecedor ObterFornecedor() {
            Console.Write("Digite o nome do Fornecedor: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do Fornecedor: ");
            string telefone = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, telefone);

            return fornecedor;
        }
    }
}
