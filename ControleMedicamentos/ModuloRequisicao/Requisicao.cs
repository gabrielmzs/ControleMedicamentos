using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloRequisicao {
    public class Requisicao {

        public Funcionario funcionario;
        public Paciente paciente;
        public Medicamento medicamento;
        public string descricao;
        public int id;
        public int quantidade;

        public Requisicao(Funcionario funcionario, Paciente paciente, Medicamento medicamento, string descricao, int quantidade) {
            this.funcionario = funcionario;
            this.paciente = paciente;
            this.medicamento = medicamento;
            this.descricao = descricao;
            this.quantidade = quantidade;
        }
    }
}
