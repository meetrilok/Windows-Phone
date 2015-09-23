using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplate_06
{
    public class dtcMeusDados
    {
        public dtcMeusDados()
        {
        }

        public dtcMeusDados( string strImagem,
                             string strNome,
                             string strFuncao)
        {
            Imagem  = strImagem;
            Nome    = strNome;
            Funcao  = strFuncao;
        }

        public string Imagem
        {
            get;
            set;
        }

        public string Nome
        {
            get;
            set;
        }

        public string Funcao
        {
            get;
            set;
        }
    /*    public override string ToString()
        {
            return Imagem + " " + Nome + " " + Funcao;
        }*/
    }
}