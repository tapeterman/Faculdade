using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class InstituicaoDAO {

        public static Instituicao getInstituicao(object[] dados) {
            Instituicao instituicao = new Instituicao();
            instituicao.Id = Convert.ToInt32(dados.GetValue(0));
            instituicao.Nome = dados.GetValue(1).ToString();
            instituicao.Cnpj = dados.GetValue(2).ToString();

            return instituicao;

        }

        public static List<Instituicao> BuscarTodos() { 
           
            List<Instituicao> instituicoes = new List<Instituicao>();
            try {

                SqlCommand sql = new SqlCommand("Select * from instituicao", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sql;
                da.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {

                    instituicoes.Add(getInstituicao(rec.Rows[i].ItemArray));

                }
            }
            catch (Exception e) {

                Debug.WriteLine(e.Message);

            }
            finally {
                DBUtil.closeConnection();
            }

            return instituicoes;

        }

        public static Instituicao BuscarPorId(long Id) {
  
            Instituicao instituicao = new Instituicao();
            try {

                SqlCommand sql = new SqlCommand("Select * from instituicao where id = @Id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@Id", Id);
                sql.ExecuteNonQuery();

                DataSet rec = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sql;
                da.Fill(rec);
                    instituicao = getInstituicao(rec.Tables[0].Rows[0].ItemArray);
            }
            catch (Exception e) {

                Debug.WriteLine("Persistencia - Erro ao conectar ao Banco de dados" + e.Message);
            }
            finally {

                DBUtil.closeConnection();

            }


            return instituicao;
        }

        public static bool ExcluirPorId(long Id) {
 
            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from instituicao where id=@id", conn);
                conn.Open();
                sql.Parameters.AddWithValue("@id", Id);
                sql.ExecuteNonQuery();
                total = sql.ExecuteNonQuery();

            }
            catch (Exception e) {

                Debug.WriteLine("Persistencia - Erro ao conectar ao Banco de dados" + e.Message);

            }
            finally {

                conn.Close();

            }
            return total > 0;
        }

        public static Boolean Persistir(Instituicao instituicao) {
            SqlConnection conn = DBUtil.getConnection();
            try {

                SqlCommand sql;
                if (instituicao.Id>0) {

                    sql = new SqlCommand("update instituicao set nome = @nome, cnpj = @cnpj where id = @id", conn);

                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into instituicao(nome,cnpj) values (@nome,@cnpj)", conn);

                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", instituicao.Id);
                sql.Parameters.AddWithValue("@nome", instituicao.Nome);
                sql.Parameters.AddWithValue("@cnpj", instituicao.Cnpj);
                sql.ExecuteNonQuery();

                return true;

            }
            catch (Exception e) {

                Debug.WriteLine("Persistencia - Erro ao conectar ao Banco de dados" + e.Message);
                return false;

            }
            finally {

                conn.Close();

            }

        }
    }
}