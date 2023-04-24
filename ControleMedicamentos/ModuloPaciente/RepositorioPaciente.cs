using ControleMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloPaciente {
    public class RepositorioPaciente {
        ArrayList listaPaciente;

        public RepositorioPaciente(ArrayList listaPaciente) {
            this.listaPaciente = listaPaciente;
        }
        int contadorPaciente = 0;
        public void Inserir(Paciente paciente) {

            contadorPaciente++;
            paciente.id = contadorPaciente;
            listaPaciente.Add(paciente);
        }

        public ArrayList SelecionarTodos() {
            return listaPaciente;
        }

        internal void Editar(int id, Paciente pacienteAtualizada) {

            Paciente pacienteSelecionado = SelecionarPorId(id);
            pacienteSelecionado.nome = pacienteAtualizada.nome;
            pacienteSelecionado.telefone = pacienteAtualizada.telefone;
        }

        public void Excluir(int id) {

            Paciente pacienteSelecionado = SelecionarPorId(id);
            listaPaciente.Remove(pacienteSelecionado);
        }

        public Paciente SelecionarPorId(int id) {
            Paciente pacienteSelecionado = null;
            foreach (Paciente f in listaPaciente) {
                if (f.id == id) {
                    pacienteSelecionado = f;
                    break;
                }
            }

            return pacienteSelecionado;
        }
    }
}
