using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//adicionados os namespaces
using Kaique.Estudo.UI.BLL;
using Kaique.Estudo.UI.MOD;
using Kaique.Estudo.UI.DAL;

namespace Kaique.Estudo.UI.UI
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        public void AtualizaGrid()
        {
            ClienteBLL objBLL = new ClienteBLL();
            dgvCliente.DataSource = objBLL.ListagemCliente();

            txtId.Text = dgvCliente[0, dgvCliente.CurrentRow.Index].Value.ToString();
            txtNome.Text = dgvCliente[1, dgvCliente.CurrentRow.Index].Value.ToString();
            txtEnd.Text = dgvCliente[2, dgvCliente.CurrentRow.Index].Value.ToString();
            txtCnpj.Text = dgvCliente[3, dgvCliente.CurrentRow.Index].Value.ToString();
            txtTelefone.Text = dgvCliente[4, dgvCliente.CurrentRow.Index].Value.ToString();
            txtEmail.Text = dgvCliente[5, dgvCliente.CurrentRow.Index].Value.ToString();



        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            AtualizaGrid();
            txtNome.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtEnd.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            txtTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            ClienteInformacao cliente = new ClienteInformacao();
            
            try
            {
                cliente.NomeCliente = txtNome.Text;
                cliente.EnderecoCliente = txtEnd.Text;
                cliente.CnpjCliente = txtCnpj.Text;
                cliente.TelefoneCliente = txtTelefone.Text;
                cliente.EmailCliente = txtEmail.Text;

                ClienteBLL objBll = new ClienteBLL();
                objBll.ValidaIncluirCliente(cliente);
                MessageBox.Show("cliente incluido com sucesso!".ToUpper());

                txtId.Text = Convert.ToString(cliente.IdCliente);

                AtualizaGrid();
            }
            catch (Exception ex)
            {
                
                throw new Exception("ERRO!" + ex.Message);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            ClienteInformacao cliente = new ClienteInformacao();

            if (txtId.Text == string.Empty)
	            {
		             MessageBox.Show("Escolha um cliente para alteração!".ToUpper());
	            }
            else

            try
            {
                cliente.IdCliente = int.Parse(txtId.Text);
                cliente.NomeCliente = txtNome.Text;
                cliente.EnderecoCliente = txtEnd.Text;
                cliente.CnpjCliente = txtCnpj.Text;
                cliente.TelefoneCliente = txtTelefone.Text;
                cliente.EmailCliente = txtEmail.Text;

                ClienteBLL objBll = new ClienteBLL();
                objBll.ValidaAlteraCliente(cliente);

                MessageBox.Show("O cliente foi alterado com sucesso!");

                AtualizaGrid();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Escolha um cliente para excluir!".ToUpper());
            }
            else
            try 
	          {
                  int codigo = Convert.ToInt32(txtId.Text);
                  ClienteBLL objBll = new ClienteBLL();
                  objBll.ValidaExcluiCliente(codigo);
                  MessageBox.Show("O cliente foi excluido com sucesso!".ToUpper());
                  AtualizaGrid();
	          }
	        catch (Exception ex)
	        {

                MessageBox.Show(ex.Message);
	        }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvCliente[0, dgvCliente.CurrentRow.Index].Value.ToString();
            txtNome.Text = dgvCliente[1, dgvCliente.CurrentRow.Index].Value.ToString();
            txtEnd.Text = dgvCliente[2, dgvCliente.CurrentRow.Index].Value.ToString();
            txtCnpj.Text = dgvCliente[3, dgvCliente.CurrentRow.Index].Value.ToString();
            txtTelefone.Text = dgvCliente[4, dgvCliente.CurrentRow.Index].Value.ToString();
            txtEmail.Text = dgvCliente[5, dgvCliente.CurrentRow.Index].Value.ToString();
            

        }
    }
}
