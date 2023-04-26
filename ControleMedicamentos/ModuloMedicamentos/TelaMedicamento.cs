
using System.Collections;

using ControleMedicamentos.Compartilhado;
using ControleMedicamentos.ModuloFornecedor;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class TelaMedicamento:TelaBase {

        RepositorioMedicamento repositorioMedicamento;
        RepositorioFornecedor repositorioFornecedor;
        TelaFornecedor telafornecedor;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, TelaFornecedor telafornecedor) {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.telafornecedor = telafornecedor;
            this.repositorioBase = repositorioMedicamento;
        }

        protected override void MostrarTabela(ArrayList listaMedicamentos) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", "ID", "Nome", "Descrição","Quantidade","Fornecedor");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            foreach (Medicamento c in listaMedicamentos) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", c.id, c.nome, c.descricao, c.quantidade, c.fornecedor.nome);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override EntidadeBase ObterRegistro() {
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

        public void MostrarMedicamentosFaltando(ArrayList listaMedicamentos) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", "ID", "Nome", "Descrição", "Quantidade", "Fornecedor");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            foreach (Medicamento c in listaMedicamentos) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|{3,-30} |{4,-20}|", c.id, c.nome, c.descricao, c.quantidade, c.fornecedor.nome);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            }
            Console.ReadLine();
        }
    }
}
