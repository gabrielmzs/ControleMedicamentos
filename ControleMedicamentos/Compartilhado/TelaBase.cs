using ControleMedicamentos.ModuloFuncionario;
using ControleMedicamentos.ModuloMedicamentos;
using ControleMedicamentos.ModuloPaciente;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Compartilhado {
    public abstract class TelaBase {

        public string nomeEntidade;
        protected RepositorioBase repositorioBase = null;
        public void MostrarCabecalho(string titulo, string subtitulo) {

            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine(subtitulo);
            Console.WriteLine();
        }
        public void MostrarMensagem(string mensagem, ConsoleColor cor) {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public virtual string ApresentarMenu() 
      {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}s \n");

            Console.WriteLine($"1 - Inserir {nomeEntidade}");
            Console.WriteLine($"2 - Visualizar {nomeEntidade}s");
            Console.WriteLine($"3 - Editar {nomeEntidade}s");
            Console.WriteLine($"4 - Excluir {nomeEntidade}s");

            Console.WriteLine("0 - para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Inserir() {

            MostrarCabecalho($"Cadastro de {nomeEntidade}: ", "Inserindo um novo Registro...");
            EntidadeBase registro = ObterRegistro();
            repositorioBase.Inserir(registro);
            MostrarMensagem("Registro inserido com sucesso!", ConsoleColor.Green);

        }

        protected abstract EntidadeBase ObterRegistro();

        public void Editar() {
            MostrarCabecalho($"Cadastro de {nomeEntidade}: ", "Editando um Registro...");
            Visualizar();
            Console.Write("\nDigite o ID do registro a ser editado: ");
            int id = int.Parse(Console.ReadLine());
            EntidadeBase registroAtualizado = ObterRegistro();

            repositorioBase.Editar(id, registroAtualizado);
            MostrarMensagem("Registro editado com sucesso!", ConsoleColor.Green);
        }

        public void Visualizar() {
            Console.WriteLine("Registros já cadastrados: \n");
            ArrayList registros = repositorioBase.SelecionarTodos();
            if (registros.Count == 0) {
                MostrarMensagem("Não há registros cadastrados!", ConsoleColor.DarkYellow);
                return;
            }
            MostrarTabela(registros);
        }

        public void Deletar() {
            MostrarCabecalho($"Cadastro de {nomeEntidade}: ", "Deletando um registro...");
            Visualizar();
            Console.Write("\nDigite o ID do registro a ser deletado: ");
            int id = int.Parse(Console.ReadLine());
            repositorioBase.Excluir(id);
            MostrarMensagem("Registro deletado com sucesso!", ConsoleColor.Green);
        }

        protected abstract void MostrarTabela(ArrayList registros);


    }
}
