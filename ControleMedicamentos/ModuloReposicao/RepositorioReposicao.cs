using ControleMedicamentos.ModuloMedicamentos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMedicamentos.Compartilhado;

namespace ControleMedicamentos.ModuloReposicao {
    public class RepositorioReposicao:RepositorioBase {
       
        public RepositorioReposicao(ArrayList lista) {
            listaRegistros = lista;
        }

        int contadorReposicao = 0;
        public void Inserir(Reposicao reposicao) {

            contadorReposicao++;
            reposicao.id = contadorReposicao;
            listaRegistros.Add(reposicao);
        }

    }

}
