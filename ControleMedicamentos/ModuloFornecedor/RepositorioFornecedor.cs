using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ControleMedicamentos.ModuloFornecedor;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloFornecedor {
    public class RepositorioFornecedor:RepositorioBase {
       
        public RepositorioFornecedor(ArrayList lista) {
            listaRegistros = lista;
        }
        public override Fornecedor SelecionarPorId(int id) {

            return (Fornecedor)base.SelecionarPorId(id);
        }
    }
}
