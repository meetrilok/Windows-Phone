using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_03
{
    public class dtcMeusDados
    {
        public dtcMeusDados()
        {
        }

        public dtcMeusDados(string strNome,
                              string strProfissao)
        {
            Nome = strNome;
            Profissao = strProfissao;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Profissao
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Nome + " " + Profissao;
        }
    }
}
