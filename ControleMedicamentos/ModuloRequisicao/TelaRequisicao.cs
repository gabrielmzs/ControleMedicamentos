using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.ModuloPaciente;
using ControleMedicamentos.ModuloReposicao;
using ControleMedicamentos.Compartilhado;
using System.Collections;


namespace ControleMedicamentos.ModuloRequisicao {
    public class TelaRequisicao:TelaBase {
        RepositorioRequisicao repositorioRequisicao;
        RepositorioMedicamento repositorioMedicamento;
        RepositorioFuncionario repositorioFuncionario;
        RepositorioPaciente repositorioPaciente;
        TelaFuncionario telaFuncionario;
        TelaMedicamento telaMedicamento;
        TelaPaciente telaPaciente;

        public TelaRequisicao(RepositorioRequisicao repositorioRequisicao, RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario, RepositorioPaciente repositorioPaciente, TelaFuncionario telaFuncionario, TelaMedicamento telaMedicamento, TelaPaciente telaPaciente) {
            this.repositorioRequisicao = repositorioRequisicao;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioPaciente = repositorioPaciente;
            this.telaFuncionario = telaFuncionario;
            this.telaMedicamento = telaMedicamento;
            this.telaPaciente = telaPaciente;
            this.repositorioBase = repositorioRequisicao;
        }

        public override string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Solicitar Requisição");
            Console.WriteLine("2 - Visualizar Requisições");

            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
     

        protected override void MostrarTabela(ArrayList listaRequisicao) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-10} |{4,-30} |{5,-20} |", "ID", "Paciente", "Medicamento", "Quantidade", "Descrição","Funcionário");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            foreach (Requisicao r in listaRequisicao) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-10} |{4,-30} |{5,-20} |", r.id, r.paciente.nome, r.medicamento.nome, r.quantidade, r.descricao, r.funcionario.nome);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override Requisicao ObterRegistro() {

            telaPaciente.Visualizar();
            Console.WriteLine("Digite o ID do Paciente: ");
            int id = int.Parse(Console.ReadLine());
            Paciente paciente = repositorioPaciente.SelecionarPorId(id);
            Console.WriteLine();
            telaFuncionario.Visualizar();
            Console.Write("Digite o ID do Funcionário: ");
            id = int.Parse(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);
            telaMedicamento.Visualizar();
            Console.WriteLine();
            Console.Write("Digite o ID do Medicamento: ");
            id = int.Parse(Console.ReadLine());
            Medicamento medicamento = repositorioMedicamento.SelecionarPorId(id);
            
            Console.Write("Digite a quantidade do Medicamento: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da requisição: ");
            string descricao = Console.ReadLine();

            medicamento.quantidade -= quantidade;

            Requisicao requisicao = new Requisicao(funcionario, paciente, medicamento, descricao, quantidade);
            Reposicao reposicao = new Reposicao(medicamento, quantidade, funcionario);


            return requisicao;
        }
    }

}
