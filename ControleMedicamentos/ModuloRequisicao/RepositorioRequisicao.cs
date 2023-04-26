using ControleMedicamentos.ModuloReposicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloRequisicao {
    public class RepositorioRequisicao:RepositorioBase {

        public RepositorioRequisicao(ArrayList lista) {
            listaRegistros = lista;
        }

        int contadorRequisicao = 0;
        public void Inserir(Requisicao requisicao) {

            contadorRequisicao++;
            requisicao.id = contadorRequisicao;
            listaRegistros.Add(requisicao);
        }
    }
}
