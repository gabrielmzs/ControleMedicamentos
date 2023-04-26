using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.Compartilhado {
    public abstract class EntidadeBase {
        public int id = 0;

        public abstract void AtualizarInformacoes(EntidadeBase registroAtualizado);
    }
}
