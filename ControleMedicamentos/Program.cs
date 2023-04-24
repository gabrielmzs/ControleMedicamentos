using ControleMedicamentos.ModuloFornecedor;
using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.ModuloPaciente;
using ControleMedicamentos.ModuloReposicao;
using ControleMedicamentos.ModuloRequisicao;
using System.Collections;

namespace ControleMedicamentos {
    internal class Program {
        static void Main(string[] args) {

            RepositorioFuncionario repositorioFuncionario = new RepositorioFuncionario(new ArrayList());
            RepositorioFornecedor repositorioFornecedor = new RepositorioFornecedor(new ArrayList());
            RepositorioPaciente repositorioPaciente = new RepositorioPaciente(new ArrayList());
            RepositorioMedicamento repositorioMedicamento = new RepositorioMedicamento(new ArrayList());
            RepositorioReposicao repositorioReposicao = new RepositorioReposicao(new ArrayList());
            RepositorioRequisicao repositorioRequisicao = new RepositorioRequisicao(new ArrayList());

            CadastrarAutomatico();

            TelaFuncionario telaFuncionario = new TelaFuncionario(repositorioFuncionario);
            TelaFornecedor telaFornecedor = new TelaFornecedor(repositorioFornecedor);
            TelaPaciente telaPaciente = new TelaPaciente(repositorioPaciente);
            TelaMedicamento telaMedicamento = new TelaMedicamento(repositorioMedicamento, repositorioFornecedor, telaFornecedor);
            TelaReposicao telaReposicao = new TelaReposicao(repositorioReposicao, repositorioMedicamento, repositorioFuncionario, telaFuncionario, telaMedicamento);
            TelaRequisicao telaRequisicao = new TelaRequisicao(repositorioRequisicao, repositorioMedicamento, repositorioFuncionario, repositorioPaciente, telaFuncionario, telaMedicamento, telaPaciente);

            while (true) {
                Console.Clear();
                Console.WriteLine("Controle de Medicamentos 1.0");
                Console.WriteLine("1 - Cadastro Funcionário");
                Console.WriteLine("2 - Cadastro Paciente");
                Console.WriteLine("3 - Cadastro Fornecedor");
                Console.WriteLine("4 - Cadastro Medicamento");
                Console.WriteLine("5 - Cadastro Reposição");
                Console.WriteLine("6 - Cadastro Requisição");
                Console.WriteLine("0 - Encerrar");

                string opcao = Console.ReadLine();

                if (opcao == "0") {
                    break;
                } else if (opcao == "1") {

                    string opcaoCaixa = telaFuncionario.ApresentarMenu();

                    if (opcaoCaixa == "1") {
                        telaFuncionario.Inserir();
                    } else if (opcaoCaixa == "2") {
                        telaFuncionario.Visualizar();
                    } else if (opcaoCaixa == "3") {
                        telaFuncionario.Editar();
                    } else if (opcaoCaixa == "4") {
                        telaFuncionario.Deletar();
                    }
                    continue;
                } else if (opcao == "2") {


                    string opcaoPaciente = telaPaciente.ApresentarMenu();

                    if (opcaoPaciente == "1") {
                        telaPaciente.Inserir();
                    } else if (opcaoPaciente == "2") {
                        telaPaciente.Visualizar();
                    } else if (opcaoPaciente == "3") {
                        telaPaciente.Editar();
                    } else if (opcaoPaciente == "4") {
                        telaPaciente.Deletar();
                    }
                    continue;

                } else if (opcao == "3") {

                    string opcaoFornecedor = telaFornecedor.ApresentarMenu();

                    if (opcaoFornecedor == "1") {
                        telaFornecedor.Inserir();
                    } else if (opcaoFornecedor == "2") {
                        telaFornecedor.Visualizar();
                    } else if (opcaoFornecedor == "3") {
                        telaFornecedor.Editar();
                    } else if (opcaoFornecedor == "4") {
                        telaFornecedor.Deletar();
                    }
                    continue;
                }

                else if (opcao == "4") {

                    string opcaoMedicamento = telaMedicamento.ApresentarMenu();

                    if (opcaoMedicamento == "1") {
                        telaMedicamento.Inserir();
                    } else if (opcaoMedicamento == "2") {
                        telaMedicamento.Visualizar();
                    } else if (opcaoMedicamento == "3") {
                        telaMedicamento.Editar();
                    } else if (opcaoMedicamento == "4") {
                        telaMedicamento.Deletar();
                    }
                    continue;
                } 

                else if (opcao == "5") {

                    string opcaoReposicao = telaReposicao.ApresentarMenu();

                    if (opcaoReposicao == "1") {
                        telaReposicao.Inserir();
                    } else if (opcaoReposicao == "2") {
                        telaReposicao.Visualizar();
                    }
                    continue;
                } 
                else if (opcao == "6") {

                    string opcaoRequisicao = telaRequisicao.ApresentarMenu();

                    if (opcaoRequisicao == "1") {
                        telaRequisicao.Inserir();
                    } else if (opcaoRequisicao == "2") {
                        telaRequisicao.Visualizar();
                    }
                    continue;
                }

                
                }

            void CadastrarAutomatico() {

                Paciente paciente = new Paciente("João Silva", "9922-2233");
                repositorioPaciente.Inserir(paciente);
                Paciente paciente2 = new Paciente("Glória Maria", "8854-2243");
                repositorioPaciente.Inserir(paciente2);

                Funcionario funcionario = new Funcionario("Scheila Carvalho", "9920-8812");
                repositorioFuncionario.Inserir(funcionario);
                Funcionario funcionario2 = new Funcionario("Scheila Mello", "8910-3416");
                repositorioFuncionario.Inserir(funcionario2);

                Fornecedor fornecedor = new Fornecedor("Bayer", "9810-1131");
                repositorioFornecedor.Inserir(fornecedor);
                Fornecedor fornecedor2 = new Fornecedor("Neo Química", "2203-5319");
                repositorioFornecedor.Inserir(fornecedor2);

                Medicamento medicamento = new Medicamento("Laxante", "Para ir aos pés", 50, fornecedor2);
                repositorioMedicamento.Inserir(medicamento);
                Medicamento medicamento2 = new Medicamento("Aspirina", "Para dor de cabeça", 5, fornecedor);
                repositorioMedicamento.Inserir(medicamento2);

                Requisicao requisicao = new Requisicao(funcionario, paciente, medicamento, "Tava trancado", 5);
                repositorioRequisicao.Inserir(requisicao);
                Requisicao requisicao2 = new Requisicao(funcionario2, paciente2, medicamento2, "Tava com Enxaqueca", 10);
                repositorioRequisicao.Inserir(requisicao2);

                Reposicao reposicao = new Reposicao(medicamento, 45, funcionario);
                repositorioReposicao.Inserir(reposicao);
                Reposicao reposicao2 = new Reposicao(medicamento2, 20, funcionario2);
                repositorioReposicao.Inserir(reposicao2);




            }
        }
    }
}