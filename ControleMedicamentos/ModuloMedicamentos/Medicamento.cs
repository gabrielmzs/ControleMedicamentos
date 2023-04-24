using ControleMedicamentos.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class Medicamento {

        public string nome;
        public string descricao;
        public int quantidade;
        public int id;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descricao, int quantidade, Fornecedor fornecedor) {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.fornecedor = fornecedor;
        }
    }

}
