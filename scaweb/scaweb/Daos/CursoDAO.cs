using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class CursoDAO {
        private static Curso getCurso(object[] dados) {

            Curso curso = new Curso();
            curso.Id = Convert.ToInt32(dados.GetValue(0));
            curso.Descricao = Convert.ToString(dados.GetValue(1));
            return curso;

        }

        public static Curso BuscarPorId(long id) {

            Curso Curso = null;

            try {

                SqlCommand sql = new SqlCommand("select id, descricao from Curso where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                Curso = getCurso(rec.Rows[0].ItemArray);

            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return Curso;
        }

        public static List<Curso> BuscarTodos() {
            List<Curso> Curso = new List<Curso>();
            try {
                SqlCommand sql = new SqlCommand("select id, descricao from Curso", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    Curso.Add(getCurso(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return Curso;
        }
        public static bool ExcluirPorId(long Id) {

            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from curso where id=@id", conn);
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
        public static Boolean Persistir(Curso curso) {
            SqlConnection conn = DBUtil.getConnection();
            try {

                SqlCommand sql;
                if (curso.Id > 0) {

                    sql = new SqlCommand("update curso set descricao = @descricao" +
                        "where id = @id", conn);


                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into curso(descricao)" +
                        " values(@descricao)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", curso.Id);
                sql.Parameters.AddWithValue("@descricao", curso.Descricao);
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