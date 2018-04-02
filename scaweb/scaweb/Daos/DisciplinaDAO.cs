using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class DisciplinaDAO {
        private static Disciplina getDisciplina(object[] dados) {

            Disciplina disciplina = new Disciplina();
            disciplina.Id = Convert.ToInt32(dados.GetValue(0));
            disciplina.Descricao = Convert.ToString(dados.GetValue(1));
            return disciplina;

        }

        public static Disciplina BuscarPorId(long id) {

            Disciplina disciplina = null;

            try {

                SqlCommand sql = new SqlCommand("select id, descricao from disciplina where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                disciplina = getDisciplina(rec.Rows[0].ItemArray);

            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return disciplina;
        }

        public static List<Disciplina> BuscarTodos() {
            List<Disciplina> disciplina = new List<Disciplina>();
            try {
                SqlCommand sql = new SqlCommand("select id, descricao from disciplina", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    disciplina.Add(getDisciplina(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return disciplina;
        }
        public static bool ExcluirPorId(long Id) {

            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from disciplina where id=@id", conn);
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

        public static Boolean Persistir(Disciplina disciplina) {
            SqlConnection conn = DBUtil.getConnection();
            try {

                SqlCommand sql;
                if (disciplina.Id > 0) {

                    sql = new SqlCommand("update disciplina set descricao = @descricao" +
                        "where id = @id", conn);


                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into disciplina(descricao)" +
                        " values(@descricao)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", disciplina.Id);
                sql.Parameters.AddWithValue("@descricao", disciplina.Descricao);
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