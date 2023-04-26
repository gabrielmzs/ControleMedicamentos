using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFuncionario {
    public class TelaFuncionario : TelaBase {

        RepositorioFuncionario repositorioFuncionario;
        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario) {

            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioBase = repositorioFuncionario;
        }
        
        protected override void MostrarTabela(ArrayList listaFuncionarios) {
            Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", "ID", "Nome", "Telefone");
            Console.WriteLine("--------------------------------------------------");
            foreach (Funcionario c in listaFuncionarios) {
                Console.WriteLine("{0,-5} |{1,-20} |{2,-20}|", c.id, c.nome, c.telefone);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.ReadLine();
        }
        protected override Funcionario ObterRegistro() {
            Console.Write("Digite o nome do funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o telefone do funcionário: ");
            string telefone = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, telefone);

            return funcionario;
        }

    }

}

