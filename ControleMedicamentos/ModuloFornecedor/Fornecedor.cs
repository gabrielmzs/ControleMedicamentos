using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFornecedor {
    public class Fornecedor:EntidadeBase {

        public string nome;
        public string telefone;
        
        public Fornecedor(string nome, string telefone) {
            this.nome = nome;
            this.telefone = telefone;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado) {

            Fornecedor fornecedorAtualizado = (Fornecedor)registroAtualizado;

            nome = fornecedorAtualizado.nome;
            telefone = fornecedorAtualizado.telefone;
        }

    }
}
