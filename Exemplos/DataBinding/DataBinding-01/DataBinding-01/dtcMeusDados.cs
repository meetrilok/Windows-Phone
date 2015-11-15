using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_01
{
    public class dtcMeusDados
    {
        public dtcMeusDados() 
        { 
        }

        public dtcMeusDados ( string strNome, 
                              string strProfissao, 
                              string strCidade, 
                              string strEstado )
        {
            Nome = strNome;
            Profissao = strProfissao;
            Cidade = strCidade;
            Estado = strEstado;
        }

        public string Nome
        {
            get; set;
        }

        public string Profissao
        {
            get; set;
        }

        public string Cidade
        {
            get; set;
        }

        public string Estado
        {
            get; set;
        }

        public override string ToString()
        {
            return " Nome      : " + Nome + "\n" +
                   " Profissao : " + Profissao + "\n" +
                   " Cidade    : " + Cidade + "\n" +
                   " Estado    : " + Estado;
        }
    }
}
