using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ControleMedicamentos.ModuloFornecedor;

namespace ControleMedicamentos.ModuloFornecedor {
    public class RepositorioFornecedor {
        ArrayList listaFornecedor;

        public RepositorioFornecedor(ArrayList listaFornecedor) {
            this.listaFornecedor = listaFornecedor;
        }
        int contadorFornecedor = 0;
        public void Inserir(Fornecedor fornecedor) {

            contadorFornecedor++;
            fornecedor.id = contadorFornecedor;
            listaFornecedor.Add(fornecedor);
        }

        public ArrayList SelecionarTodos() {
            return listaFornecedor;
        }

        internal void Editar(int id, Fornecedor fornecedorAtualizada) {

            Fornecedor fornecedorSelecionado = SelecionarPorId(id);
            fornecedorSelecionado.nome = fornecedorAtualizada.nome;
            fornecedorSelecionado.telefone = fornecedorAtualizada.telefone;
        }

        public void Excluir(int id) {

            Fornecedor fornecedorSelecionado = SelecionarPorId(id);
            listaFornecedor.Remove(fornecedorSelecionado);
        }

        public Fornecedor SelecionarPorId(int id) {
            Fornecedor fornecedorSelecionado = null;
            foreach (Fornecedor f in listaFornecedor) {
                if (f.id == id) {
                    fornecedorSelecionado = f;
                    break;
                }
            }

            return fornecedorSelecionado;
        }
    }
}
