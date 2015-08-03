using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_01
{
    class DadosPessoas
    {
        string strNome;
        string strSobreNome;
        string strImagem;

        public string Nome
        {
            get { return strNome; }
            set { strNome = value; }
        }
        public string Sobrenome
        {
            get { return strSobreNome; }
            set { strSobreNome = value; }
        }
        public string Imagem
        {
            get { return strImagem; }
            set { strImagem = value; }
        }
    }
}
