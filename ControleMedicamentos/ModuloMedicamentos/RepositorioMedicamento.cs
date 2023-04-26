using ControleMedicamentos.ModuloFornecedor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloMedicamentos {
    public class RepositorioMedicamento:RepositorioBase {

        public RepositorioMedicamento(ArrayList lista) {
            listaRegistros = lista;
        }
        public override Medicamento SelecionarPorId(int id) {

            return (Medicamento)base.SelecionarPorId(id);
            
        }

        public ArrayList MedicamentosFaltando() {
            ArrayList listaFaltas = new ArrayList();
            foreach (Medicamento m in listaRegistros) {
                if (m.quantidade < 10) {
                    listaFaltas.Add(m);
                }
            }
            return listaFaltas;
        }
    }
}
