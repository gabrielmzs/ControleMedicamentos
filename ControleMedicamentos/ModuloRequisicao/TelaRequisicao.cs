using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.ModuloPaciente;
using ControleMedicamentos.ModuloReposicao;
using ControleMedicamentos.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloRequisicao {
    public class TelaRequisicao:Tela {
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
        }

        public string ApresentarMenu() {
            Console.Clear();
            Console.WriteLine("1 - Solicitar Requisição");
            Console.WriteLine("2 - Visualizar Requisições");

            Console.WriteLine("0 - Voltar");

            string opcao = Console.ReadLine();
            return opcao;
        }
        public void Inserir() {

            MostrarCabecalho("Cadastro de Requisições: ", "Abrindo uma requisição de medicamento...");
            Requisicao requisicao = ObterRequisicao();
            repositorioRequisicao.Inserir(requisicao);
            MostrarMensagem("Reposição feita com sucesso!", ConsoleColor.Green);

        }
        public void Visualizar() {
            Console.WriteLine("Reposições Abertas: \n");
            ArrayList lista = repositorioRequisicao.SelecionarTodos();
            if (lista.Count == 0) {
                MostrarMensagem("Não há Reposições cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(lista);
        }

        private void MostrarTabela(ArrayList lista) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-10} |{4,-30} |{5,-20} |", "ID", "Paciente", "Medicamento", "Quantidade", "Descrição","Funcionário");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            foreach (Requisicao r in lista) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20} |{3,-10} |{4,-30} |{5,-20} |", r.id, r.paciente.nome, r.medicamento.nome, r.quantidade, r.descricao, r.funcionario.nome);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        private Requisicao ObterRequisicao() {

            telaPaciente.Visualizar();
            Console.WriteLine("Digite o ID do Paciente: ");
            int id = int.Parse(Console.ReadLine());
            Paciente paciente = repositorioPaciente.SelecionarPorId(id);
            Console.WriteLine();
            telaFuncionario.Visualizar();
            Console.WriteLine("Digite o ID do Funcionário: ");
            id = int.Parse(Console.ReadLine());
            Funcionario funcionario = repositorioFuncionario.SelecionarPorId(id);
            telaMedicamento.Visualizar();
            Console.WriteLine();
            Console.WriteLine("Digite o ID do Medicamento: ");
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
