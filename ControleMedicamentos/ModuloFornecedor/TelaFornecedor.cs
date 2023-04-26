using ControleMedicamentos.ModuloFornecedor;
using System.Collections;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFornecedor {
    public class TelaFornecedor:TelaBase {
        RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor) {
            this.repositorioFornecedor = repositorioFornecedor;
            this.repositorioBase = repositorioFornecedor;
        }


        protected override void MostrarTabela(ArrayList listaFornecedors) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Fornecedor c in listaFornecedors) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override EntidadeBase ObterRegistro() {
            Console.Write("Digite o nome do Fornecedor: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do Fornecedor: ");
            string telefone = Console.ReadLine();

            Fornecedor fornecedor = new Fornecedor(nome, telefone);

            return fornecedor;
        }
    }
}
