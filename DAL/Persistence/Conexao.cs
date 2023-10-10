using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //ado.net -> SQL SERVER

namespace DAL.Persistence
{
    public class Conexao
    {
        //Atributos:
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;

        //Metodo Para Abrir Conexao
        protected void AbrirConexao()
        {
            try
            {
                //Conection String
                Con = new SqlConnection("Data Source=PositivoJr;Initial Catalog=master;Integrated Security=True"); 
                Con.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Metodo Para Fechar a Conexao

        protected void FecharConexao()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
