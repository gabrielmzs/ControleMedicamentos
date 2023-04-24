using ControleMedicamentos.ModuloFornecedor;
using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloReposicao {
    internal class TelaReposicao:Tela {
        RepositorioReposicao repositorioReposicao;
        RepositorioMedicamento repositorioMedicamento;
        RepositorioFuncionario repositorioFuncionario;
        TelaFuncionario telaFuncionario;
        TelaMedicamento telaMedicamento;

        public TelaReposicao(RepositorioReposicao repositorioReposicao, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento) {
            this.repositorioReposicao = repositorioReposicao;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Solicitar Reposição");
            Console.WriteLine("2 - Visualizar Solicitações");
            
            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Solicitações: ", "Abrindo uma solicitação de Reposição...");
            Reposicao reposicao = ObterReposicao();
            repositorioReposicao.Inserir(reposicao);
            MostrarMensagem("Reposição feita com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Reposições Abertas: \n");
            ArrayList lista = repositorioReposicao.SelecionarTodos();
            if (lista.Count == 0) {
                MostrarMensagem("Não há Reposições cadastradss!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(lista);
        }
        
        private void MostrarTabela(ArrayList lista) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |", "ID", "Medicamento", "Quantidade", "Funcionário");
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach (Reposicao r in lista) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |", r.id, r.medicamento.nome, r.quantidade, r.funcionario.nome);
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Reposicao ObterReposicao() {

            telaFuncionario.Visualizar();
            Console.WriteLine("Digite o ID do Funcionário: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);

            ArrayList medicamentosFaltando = repositorioMedicamento.MedicamentosFaltando();
            telaMedicamento.MostrarTabela(medicamentosFaltando);
            Console.WriteLine("Digite o ID do Medicamento: ");
            int id2 = int.Parse(Console.ReadLine());
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(id2);

            Console.Write("Digite a quantidade do Medicamento: ");
            int quantidade = int.Parse(Console.ReadLine());

            medicamento.quantidade += quantidade;

            Reposicao reposicao = new Reposicao(medicamento, quantidade, funcionario);
            

            return reposicao;
        }
    }

}
