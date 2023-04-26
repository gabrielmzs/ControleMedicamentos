using ControleMedicamentos.ModuloFornecedor;
using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using System.Collections;

using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloReposicao {
    internal class TelaReposicao:TelaBase {
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
            this.repositorioBase = repositorioReposicao;
        }

        public override string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Solicitar Requisição");
            Console.WriteLine("2 - Visualizar Requisições");

            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }

        protected override void MostrarTabela(ArrayList listaReposicao) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |", "ID", "Medicamento", "Quantidade", "Funcionário");
            Console.WriteLine("----------------------------------------------------------------------------------");
            foreach (Reposicao r in listaReposicao) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |", r.id, r.medicamento.nome, r.quantidade, r.funcionario.nome);
                Console.WriteLine("----------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override Reposicao ObterRegistro() {

            telaFuncionario.Visualizar();
            Console.Write("Digite o ID do Funcionário: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);

            ArrayList medicamentosFaltando = repositorioMedicamento.MedicamentosFaltando();
            telaMedicamento.MostrarMedicamentosFaltando(medicamentosFaltando);
            Console.Write("Digite o ID do Medicamento: ");
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
