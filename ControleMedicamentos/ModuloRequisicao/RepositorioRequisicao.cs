using ControleMedicamentos.ModuloReposicao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloRequisicao {
    public class RepositorioRequisicao {

        ArrayList listaRequisicao;

        public RepositorioRequisicao(ArrayList listaRequisicao) {
            this.listaRequisicao = listaRequisicao;
        }

        public ArrayList SelecionarTodos() {
            return listaRequisicao;
        }

        int contadorRequisicao = 0;
        public void Inserir(Requisicao requisicao) {

            contadorRequisicao++;
            requisicao.id = contadorRequisicao;
            listaRequisicao.Add(requisicao);
        }
    }
}
