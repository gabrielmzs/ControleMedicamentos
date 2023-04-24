using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;
using ControleMedicamentos.ModuloFornecedor;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class TelaMedicamento:Tela {

        RepositorioMedicamento repositorioMedicamento;
        RepositorioFornecedor repositorioFornecedor;
        TelaFornecedor telafornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, TelaFornecedor telafornecedor) {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.telafornecedor = telafornecedor;
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Inserir Medicamento");
            Console.WriteLine("2 - Visualizar Medicamentos");
            Console.WriteLine("3 - Editar Medicamento");
            Console.WriteLine("4 - Deletar Medicamento");
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Medicamento: ", "Inserindo um novo Medicamento...");
            Medicamento medicamento = ObterMedicamento();
            repositorioMedicamento.Inserir(medicamento);
            MostrarMensagem("Medicamento inserido com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Medicamentoes Cadastrados: \n");
            ArrayList listaMedicamentos = repositorioMedicamento.SelecionarTodos();
            if (listaMedicamentos.Count == 0) {
                MostrarMensagem("Não há Medicamentoes cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(listaMedicamentos);
        }

        public void Editar() {
            MostrarCabecalho("Cadastro de Medicamento: ", "Editando um Medicamento...");
            Visualizar();
            Console.Write("\nDigite o ID da Medicamento a ser editado: ");
            int id = int.Parse(Console.ReadLine());
            Medicamento medicamentoAtualizada = ObterMedicamento();

            repositorioMedicamento.Editar(id, medicamentoAtualizada);
            MostrarMensagem("Medicamento editado com sucesso!", ConsoleColor.Green);

        }
        public void Deletar() {
            MostrarCabecalho("Cadastro de Medicamento: ", "Deletando um Medicamento...");
            Visualizar();
            Console.Write("\nDigite o ID do Medicamento a ser deletado: ");
            int id = int.Parse(Console.ReadLine());
            repositorioMedicamento.Excluir(id);
            MostrarMensagem("Medicamento deletado com sucesso!", ConsoleColor.Green);
        }

        public void MostrarTabela(ArrayList listaMedicamentos) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", "ID", "Nome", "Descrição","Quantidade","Fornecedor");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            foreach (Medicamento c in listaMedicamentos) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", c.id, c.nome, c.descricao, c.quantidade, c.fornecedor.nome);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Medicamento ObterMedicamento() {
            telafornecedor.Visualizar();
            Console.WriteLine("Digite o ID do fornecedor: ");
            int id = int.Parse(Console.ReadLine());
            Fornecedor fornecedor = repositorioFornecedor.SelecionarPorId(id);
            Console.Write("Digite o nome do Medicamento: ");
            string nome = Console.ReadLine();
            Console.Write("Digite a descrição do Medicamento: ");
            string descricao = Console.ReadLine();
            Console.Write("Digite a quantidade do Medicamento: ");
            int quantidade = int.Parse(Console.ReadLine());


            Medicamento medicamento = new Medicamento(nome, descricao,quantidade,fornecedor);

            return medicamento;
        }
    }
}
