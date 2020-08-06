using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm3
{
    public partial class Cadastro : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\WebForm3\WebForm3\App_Data\Database2.mdf;Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                  ButtonExcluir.Enabled = false;
                  FillGridView();
            }
        }

        protected void ButtonLimpar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            hfIdPessoa.Value ="";
            TxtNome.Text = TxtIdade.Text = TxtCidade.Text = TxtEmail.Text = "";
            LabelSucessoMensagem.Text = LabelErroMensagem.Text = "";
            ButtonSalvar.Text = "Salvar";
            ButtonExcluir.Enabled = false;
        }

        protected void ButtonSalvar_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PessoaSalvarEditar", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@IdPessoa", (hfIdPessoa.Value == "" ?0:System.Convert.ToInt32(hfIdPessoa.Value)));
            sqlCmd.Parameters.AddWithValue("@Nome", TxtNome.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Idade", TxtIdade.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Cidade", TxtCidade.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Email", TxtEmail.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            
            sqlCon.Close();
            string IdPessoa = hfIdPessoa.Value;

            Clear();
            if (IdPessoa == "")

                LabelSucessoMensagem.Text = "Salvo com sucesso!";
            else
                LabelSucessoMensagem.Text = "Alterado com sucesso";
            FillGridView();
        }

        void FillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("PessoaListar", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            gvCadastro.DataSource = dtbl;
            gvCadastro.DataBind();    
        }

        protected void lnk_OnClick(object sender, EventArgs e)
        {

            int IdPessoa = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("PessoaListarById", sqlCon);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@IdPessoa", IdPessoa);
            DataTable dtbl = new DataTable();
            sqlData.Fill(dtbl);
            sqlCon.Close();
            hfIdPessoa.Value = IdPessoa.ToString();
            TxtNome.Text = dtbl.Rows[0]["Nome"].ToString();
            TxtIdade.Text = dtbl.Rows[0]["Idade"].ToString();
            TxtCidade.Text = dtbl.Rows[0]["Cidade"].ToString();
            TxtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            ButtonSalvar.Text = "Alterar";
            ButtonExcluir.Enabled = true;

        }

        protected void ButtonExcluir_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("PessoaExcluirById", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@IdPessoa", Convert.ToInt32(hfIdPessoa.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            LabelSucessoMensagem.Text = "Excluído com sucesso";
            

        }
    }
}