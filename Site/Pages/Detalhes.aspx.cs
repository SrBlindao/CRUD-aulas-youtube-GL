using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistence;

namespace Site.Pages
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDados.Visible = false;
        }

        //acao pesquisar cliente
        protected void btnPesquisarCliente(object sender, EventArgs e)
        {
            try
            {
                int Codigo = Convert.ToInt32(txtCodigo.Text);

                PessoaDal d = new PessoaDal();
                Pessoa p = d.ObterPorCodigo(Codigo);

                if(p != null)
                {
                    pnlDados.Visible = true;
                    txtNome.Text = p.Nome;
                    txtEndereco.Text = p.Endereco;
                    txtEmail.Text = p.Email;
                }

                else
                {
                    lblMensagem.Text = "Cliente nao encontrado";

                    txtCodigo.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        //Acao excluir cliente
        protected void btnExcluirCliente(object sender, EventArgs e)
        {
            try
            {
                int Codigo = Convert.ToInt32(txtCodigo.Text);

                Pessoa p = new Pessoa();
                PessoaDal d = new PessoaDal();

                d.Excluir(Codigo);
                lblMensagem.Text = "Cliente" + p.Nome + "Excluido";

                txtCodigo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }

        //acao atualizar cliente
        protected void btnAtualizarCliente(object sender, EventArgs e)
        {
            try
            {
                Pessoa p = new Pessoa();

                p.Codigo = Convert.ToInt32(txtCodigo.Text);
                p.Nome = Convert.ToString(txtNome.Text);
                p.Endereco = Convert.ToString(txtEndereco.Text);
                p.Email = Convert.ToString(txtEmail.Text);

                PessoaDal d = new PessoaDal();
                d.Atualizar(p);

                lblMensagem.Text = "Cliente"+ p.Nome+ "atualizado";

                txtCodigo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtEmail.Text = string.Empty;

            }
            catch (Exception ex)
            {

                lblMensagem.Text = ex.Message;
            }
        }
    }
}