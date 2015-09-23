using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTemplate_05
{
    public class dtcMeusDados
    {
        public dtcMeusDados()
        {
        }

        public dtcMeusDados(string strImagem,
                              string strFruta)
        {
            Imagem = strImagem;
            Fruta = strFruta;
        }

        public string Imagem
        {
            get;
            set;
        }

        public string Fruta
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Imagem + " " + Fruta;
        }
    }
}