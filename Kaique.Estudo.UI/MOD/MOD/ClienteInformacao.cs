using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaique.Estudo.UI.MOD
{
    public class ClienteInformacao
    {
#region 'ATRIBUTOS E ENCAPSULAMENTOS'
        private int _idCliente;
        private string _nomeCliente;
        private string _enderecoCliente;
        private string _cnpjCliente;
        private string _telefoneCliente;
        private string _emailCliente;

        public int IdCliente
        {
            get { return _idCliente;}
            set { _idCliente = value;}
        }

        public string NomeCliente
        {
            get { return _nomeCliente; }
            set { _nomeCliente = value; }
        }

        public string EnderecoCliente
        {
            get { return _enderecoCliente; }
            set { _enderecoCliente = value; }
        }

        public string CnpjCliente
        {
            get { return _cnpjCliente; }
            set { _cnpjCliente = value; }
        }

        public string TelefoneCliente
        {
            get { return _telefoneCliente; }
            set { _telefoneCliente = value; }
        }

        public string EmailCliente
        {
            get { return _emailCliente; }
            set { _emailCliente = value; }
        }
#endregion
    }
}
