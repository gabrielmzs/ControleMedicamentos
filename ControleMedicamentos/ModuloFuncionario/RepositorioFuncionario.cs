using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFuncionario {
    public class RepositorioFuncionario:RepositorioBase {

        public RepositorioFuncionario(ArrayList lista) {
            listaRegistros = lista;
        }       
        public override Funcionario SelecionarPorId(int id) {

            return (Funcionario)base.SelecionarPorId(id);
        }
    }
}
