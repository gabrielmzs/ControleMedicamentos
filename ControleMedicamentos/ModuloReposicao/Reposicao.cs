using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.ModuloPaciente;

namespace ControleMedicamentos.ModuloReposicao {
    public class Reposicao:EntidadeBase {

        public Medicamento medicamento;
        public int quantidade;
        public Funcionario funcionario;

        public Reposicao(Medicamento medicamento, int quantidade, Funcionario funcionario) {
            this.medicamento = medicamento;
            this.quantidade = quantidade;
            this.funcionario = funcionario;
        }

        public override void AtualizarInformacoes(EntidadeBase entidade) {
           
        }
    }
}
