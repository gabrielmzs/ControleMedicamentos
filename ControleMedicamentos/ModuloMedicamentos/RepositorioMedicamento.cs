using ControleMedicamentos.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class RepositorioMedicamento {
        ArrayList listaMedicamento;

        public RepositorioMedicamento(ArrayList listaMedicamento) {
            this.listaMedicamento = listaMedicamento;
        }
        int contadorMedicamento = 0;
        public void Inserir(Medicamento medicamento) {

            contadorMedicamento++;
            medicamento.id = contadorMedicamento;
            listaMedicamento.Add(medicamento);
        }

        public ArrayList SelecionarTodos() {
            return listaMedicamento;
        }

        internal void Editar(int id, Medicamento medicamentoAtualizado) {

            Medicamento medicamentoSelecionado = SelecionarPorId(id);
            medicamentoSelecionado.nome = medicamentoAtualizado.nome;
            medicamentoSelecionado.descricao = medicamentoAtualizado.descricao;
            medicamentoSelecionado.fornecedor = medicamentoAtualizado.fornecedor;
            medicamentoSelecionado.quantidade = medicamentoAtualizado.quantidade;
        }

        public void Excluir(int id) {

            Medicamento fornecedorSelecionado = SelecionarPorId(id);
            listaMedicamento.Remove(fornecedorSelecionado);
        }

        public Medicamento SelecionarPorId(int id) {
            Medicamento fornecedorSelecionado = null;
            foreach (Medicamento f in listaMedicamento) {
                if (f.id == id) {
                    fornecedorSelecionado = f;
                    break;
                }
            }

            return fornecedorSelecionado;
        }

        public ArrayList MedicamentosFaltando() {
            ArrayList listaFaltas = new ArrayList();
            foreach (Medicamento m in listaMedicamento) {
                if (m.quantidade < 10) {
                    listaFaltas.Add(m);
                }
            }
            return listaFaltas;
        }
    }
}
