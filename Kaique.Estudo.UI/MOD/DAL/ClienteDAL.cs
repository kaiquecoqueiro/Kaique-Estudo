using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Adiciono o namespace MOD para referenciar a minha camada MOD
//Adiciono o namespace SQLCLIENT 
//Adiciono o namespace SYSTEM.DATA para poder utilizar o CONNECTIONSTATE
using Kaique.Estudo.UI.MOD;
using System.Data.SqlClient;
using System.Data;


namespace Kaique.Estudo.UI.DAL
{
    public class ClienteDAL
    {
        #region 'METODOS E CONEXAO'

       //METODO PARA INCLUIR
        public void IncluirCliente(ClienteInformacao cliente)
        {
            //cria a minha string de conexao
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=PC-ARK\SQLEXPRESS;
                                   Initial Catalog=DBSistemaBasico;
                                   Integrated Security=False;
                                   User ID=sa;
                                   Password=root;
                                   Connect Timeout=15;
                                   Encrypt=False;
                                   TrustServerCertificate=False";

            //cria o comando insert
            var cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "insert into cliente(nome_cli,endereco_cli,cnpj_cli,telefone_cli,email_cli)values(@nomeCliente,@enderecoCliente,@cnpjCliente,@telefoneCliente,@emailCliente;select @@IDENTIY;";

            //faz o insert
            cmd.Parameters.AddWithValue("@nomeCliente",cliente.NomeCliente);
            cmd.Parameters.AddWithValue("@enderecoCliente",cliente.EnderecoCliente);
            cmd.Parameters.AddWithValue("@cnpjCliente",cliente.CnpjCliente);
            cmd.Parameters.AddWithValue("@telefoneCliente",cliente.TelefoneCliente);
            cmd.Parameters.AddWithValue("@emailCliente",cliente.EmailCliente);

            try
            {
                cn.Open();

                cliente.IdCliente = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {

                throw new Exception("SERVIDOR SQL ERRO: " + ex.Number);
            }
            finally
            {
                //se o o status da minha conexao for diferente de closed, 
                //ele a fecha apos passa no if
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }


        //METODO PARA ALTERAR
        public void AlterarCliente(ClienteInformacao cliente)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=PC-ARK\SQLEXPRESS;
                                   Initial Catalog=DBSistemaBasico;
                                   Integrated Security=False;
                                   User ID=sa;
                                   Password=********;
                                   Connect Timeout=15;
                                   Encrypt=False;
                                   TrustServerCertificate=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update cliente set nome_cli = @nomeCliente, endereco_cli=@enderecoCliente,cnpj_cli=cnpjCliente,telefone_cli=telefoneCliente,email_cli=emailCliente;";

            cmd.Parameters.AddWithValue("@nomeCliente",cliente.NomeCliente);
            cmd.Parameters.AddWithValue("@enderecoCliente",cliente.EnderecoCliente);
            cmd.Parameters.AddWithValue("@cnpjCliente",cliente.CnpjCliente);
            cmd.Parameters.AddWithValue("@telefoneCliente",cliente.TelefoneCliente);
            cmd.Parameters.AddWithValue("@emailCliente",cliente.EmailCliente);

            try
            {
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    
                }
                else
                {
                    throw new Exception("Alteração não foi sucedida!");
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //METODO PARA EXCLUIR
        public void ExcluirCliente(int codigo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=PC-ARK\SQLEXPRESS;
                                   Initial Catalog=DBSistemaBasico;
                                   Integrated Security=False;
                                   User ID=sa;
                                   Password=********;
                                   Connect Timeout=15;
                                   Encrypt=False;
                                   TrustServerCertificate=False";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "delete from cliente where id_cli=" + codigo;

            try
            {
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possivel deletar!" + codigo);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception("Erro na conexão!" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        //METODO PARA CONSULTA
        public DataTable ListagemCliente()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=PC-ARK\SQLEXPRESS;
                                   Initial Catalog=DBSistemaBasico;
                                   Integrated Security=False;
                                   User ID=sa;
                                   Password=root;
                                   Connect Timeout=15;
                                   Encrypt=False;
                                   TrustServerCertificate=False";
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select*from cliente", cn);

                da.Fill(tabela);
                return tabela;
            }
            catch (SqlException ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }
        #endregion
    }
}
