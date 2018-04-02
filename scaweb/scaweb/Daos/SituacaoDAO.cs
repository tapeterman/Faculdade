using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class SituacaoDAO {
        private static Situacao getSituacao(object[] dados) {
            Situacao situacao = new Situacao();
            situacao.Id = Convert.ToInt32(dados.GetValue(0));
            situacao.Descricao = Convert.ToString(dados.GetValue(1));
            situacao.AnoSemestre = Convert.ToInt16(dados.GetValue(2));

            return situacao;
        }

        public static Situacao BuscarPorId(long id) {
            Situacao Situacao = null;
            try {
                SqlCommand sql = new SqlCommand("select * from Situacao where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                Situacao = getSituacao(rec.Rows[0].ItemArray);
            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return Situacao;
        }
        public static bool ExcluirPorId(long Id) {

            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from situacao where id=@id", conn);
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
        public static List<Situacao> BuscarTodos() {
            List<Situacao> Situacao = new List<Situacao>();
            try {
                SqlCommand sql = new SqlCommand("select * from Situacao", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    Situacao.Add(getSituacao(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return Situacao;
        }
        public static Boolean Persistir(Situacao situacao) {
            SqlConnection conn = DBUtil.getConnection();
            try {

                SqlCommand sql;
                if (situacao.Id > 0) {

                    sql = new SqlCommand("update situacao set descricao = @descricao" +
                        "where id = @id", conn);


                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into situacao(descricao)" +
                        " values(@descricao)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", situacao.Id);
                sql.Parameters.AddWithValue("@descricao", situacao.Descricao);
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