using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Biblioteca de Acesso ao SQLServer
using DAL.Model;


namespace DAL.Persistence
{
    public class PessoaDal : Conexao
    {
        //Metodo Para Gravar Dados -- INSERT:
        public void Gravar(Pessoa p)
        {
            try
            {
                //Abrir Conexao
                AbrirConexao();
                Cmd = new SqlCommand("insert into Pessoa (Nome, Endereco, Email) values (@v1, @v2, @v3)",Con);

                Cmd.Parameters.AddWithValue("@v1", p.Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Endereco);
                Cmd.Parameters.AddWithValue("@v3", p.Email);

                Cmd.ExecuteNonQuery(); //Executar Metodo
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Gravar o Cliente: " + ex.Message);
            }

            finally
            {
                FecharConexao();
            }
        }

        //Metodo Para Atualizar Dados -- UPDATE:

        public void Atualizar(Pessoa p)
        {
            try
            {
                AbrirConexao();

                Cmd = new SqlCommand("update Pessoa set Nome=@v1, Endereco=@v2, Email=@v3 where Codigo=@v4", Con );
                Cmd.Parameters.AddWithValue("@v1", p. Nome);
                Cmd.Parameters.AddWithValue("@v2", p.Endereco);
                Cmd.Parameters.AddWithValue("@v3", p.Email);
                Cmd.Parameters.AddWithValue("@V4", p.Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Atualizar o Cliente: " + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        //Metodo Para Excluir Dados -- DELETE

        public void Excluir (int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("delete from Pessoa where Codigo=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Codigo);

                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception ("Erro ao Exluir o Cliente" +ex.Message);
            }

            finally
            {
                FecharConexao();
            }
        }

        //Metodo Para Obter Uma Pessoa Pelo Codigo (Chave Primaria)

        public Pessoa ObterPorCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa where Codigo=@v1", Con);
                Cmd.Parameters.AddWithValue("@v1", Codigo);
                Dr = Cmd.ExecuteReader(); //Execucao da Leitura no DB

                Pessoa p = null; //Criando um Espaco de memoria: Ponteiro.

                if(Dr.Read())
                {
                    p = new Pessoa();

                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.Endereco = Convert.ToString(Dr["Endereco"]);
                    p.Email = Convert.ToString(Dr["Email"]);
                }

                return p;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Pesquisar o Cliente: " + ex.Message) ;
            }
            finally
            {
                FecharConexao();
            }
        }

        //Metodo Para Listar Todos os Clientes Cadastrados

        public List<Pessoa> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("select * from Pessoa", Con);
                Dr = Cmd.ExecuteReader();

                List<Pessoa> lista = new List<Pessoa>(); //Lista Vazia

                while(Dr.Read())
                {
                    Pessoa p = new Pessoa();

                    p.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    p.Nome = Convert.ToString(Dr["Nome"]);
                    p.Endereco = Convert.ToString(Dr["Endereco"]);
                    p.Email = Convert.ToString(Dr["Email"]);

                    lista.Add(p);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao Listar os Clientes" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

    }
}
