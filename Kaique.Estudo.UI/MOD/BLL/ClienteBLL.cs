using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//adiciona os namespaces DAL e MOD para poder usar as classes
using Kaique.Estudo.UI.DAL;
using Kaique.Estudo.UI.MOD;
using System.Data;
namespace Kaique.Estudo.UI.BLL
{
   public class ClienteBLL
   {
       #region 'VALIDADOR DE DADOS PARA OS METODOS'
       public void ValidaIncluirCliente(ClienteInformacao cliente)
       {
           try
           {
               if (cliente.NomeCliente.Trim() == string.Empty)
               {
                   throw new Exception("Nome do cliente é obrigatório!".ToUpper());
               }
               if (cliente.EnderecoCliente.Trim() == string.Empty)
               {
                   throw new Exception("endereço do cliente é obrigatório!".ToUpper());
               }
               if (cliente.CnpjCliente.Trim() == string.Empty)
               {
                   throw new Exception("cnpj do cliente é obrigatório!".ToUpper());
               }
               if (cliente.TelefoneCliente.Trim() == string.Empty)
               {
                   throw new Exception("telefone do cliente é obrigatório!".ToUpper());
               }
               if (cliente.EmailCliente.Trim() == string.Empty)
               {
                   throw new Exception("e-mail do cliente é obrigatório!".ToUpper());
               }

               ClienteDAL objclienteDAL = new ClienteDAL();
               objclienteDAL.IncluirCliente(cliente);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       public void ValidaAlteraCliente(ClienteInformacao cliente)
       {
           try
           {
               ClienteDAL objclienteDAL = new ClienteDAL();
               objclienteDAL.AlterarCliente(cliente);
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       public void ValidaExcluiCliente(int codigo)
       {
           try
           {
               if (codigo < 1)
               {
                   throw new Exception("Selecione um cliente para exclui-lo!".ToUpper());
               }
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }

       public DataTable ListagemCliente()
       {
           ClienteDAL obj = new ClienteDAL();
           return obj.ListagemCliente();
       }
       #endregion
   }
}
