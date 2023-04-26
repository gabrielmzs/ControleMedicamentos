using ControleMedicamentos.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class Medicamento:EntidadeBase {

        public string nome;
        public string descricao;
        public int quantidade;
        public Fornecedor fornecedor;

        public Medicamento(string nome, string descricao, int quantidade, Fornecedor fornecedor) {
            this.nome = nome;
            this.descricao = descricao;
            this.quantidade = quantidade;
            this.fornecedor = fornecedor;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado) {

            Medicamento medicamentoAtualizado = (Medicamento)registroAtualizado;

            nome = medicamentoAtualizado.nome;
            descricao = medicamentoAtualizado.descricao;
            fornecedor = medicamentoAtualizado.fornecedor;
            quantidade = medicamentoAtualizado.quantidade;
        }

        


    }

}
