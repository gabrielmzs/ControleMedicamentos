using ControleMedicamentos.ModuloMedicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ModuloReposicao {
    public class RepositorioReposicao {
        ArrayList listaReposicao;

        public RepositorioReposicao(ArrayList listaReposicao) {
            this.listaReposicao = listaReposicao;
        }

        public ArrayList SelecionarTodos() {
            return listaReposicao;
        }

        int contadorReposicao = 0;
        public void Inserir(Reposicao reposicao) {

            contadorReposicao++;
            reposicao.id = contadorReposicao;
            listaReposicao.Add(reposicao);
        }

    }

}
