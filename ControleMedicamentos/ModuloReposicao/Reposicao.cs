using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloReposicao {
    public class Reposicao {

        public Medicamento medicamento;
        public int quantidade;
        public Funcionario funcionario;
        public int id;

        public Reposicao(Medicamento medicamento, int quantidade, Funcionario funcionario) {
            this.medicamento = medicamento;
            this.quantidade = quantidade;
            this.funcionario = funcionario;
        }
    }
}
