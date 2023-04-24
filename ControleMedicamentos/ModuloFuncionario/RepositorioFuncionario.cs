using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloFuncionario {
    public class RepositorioFuncionario {

        private ArrayList listaFuncionarios;

        public RepositorioFuncionario(ArrayList listaFuncionario) {
            this.listaFuncionarios = listaFuncionario;
        }
        int contadorFuncionarios = 0;
        public void Inserir(Funcionario funcionario) {

            contadorFuncionarios++;
            funcionario.id = contadorFuncionarios;
            listaFuncionarios.Add(funcionario);
        }

        public ArrayList SelecionarTodos() {
            return listaFuncionarios;
        }

        internal void Editar(int id, Funcionario funcionarioAtualizada) {

            Funcionario funcionarioSelecionado = SelecionarPorId(id);
            funcionarioSelecionado.nome = funcionarioAtualizada.nome;
            funcionarioSelecionado.telefone = funcionarioAtualizada.telefone;
        }

        internal void Excluir(int id) {

            Funcionario funcionarioSelecionado = SelecionarPorId(id);
            listaFuncionarios.Remove(funcionarioSelecionado);
        }

        public Funcionario SelecionarPorId(int id) {
            Funcionario funcionarioSelecionado = null;
            foreach (Funcionario f in listaFuncionarios) {
                if (f.id == id) {
                    funcionarioSelecionado = f;
                    break;
                }
            }

            return funcionarioSelecionado;
        }
    }
}
