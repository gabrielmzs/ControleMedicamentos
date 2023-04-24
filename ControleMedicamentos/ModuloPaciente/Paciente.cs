using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloPaciente {
    public class Paciente {
        public string nome;
        public string telefone;
        public int id;

        public Paciente(string nome, string telefone) {
            this.nome = nome;
            this.telefone = telefone;
        }
    }
}
