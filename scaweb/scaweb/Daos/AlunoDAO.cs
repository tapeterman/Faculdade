using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace scaweb.Daos {
    public static class AlunoDAO {
        private static Aluno getAluno(object[] dados) {
            Aluno aluno = new Aluno();

            aluno.Id = Convert.ToInt32(dados.GetValue(0));
            aluno.Nome = Convert.ToString(dados.GetValue(1));
            aluno.Cpf = Convert.ToString(dados.GetValue(2));
            aluno.DataNascimento = Convert.ToDateTime(dados.GetValue(3));
            aluno.Email = Convert.ToString(dados.GetValue(4));
            aluno.Endereco = Convert.ToString(dados.GetValue(5));
            aluno.Telefone = Convert.ToString(dados.GetValue(6));
            aluno.Identidade = Convert.ToString(dados.GetValue(7));
            aluno.Matricula = Convert.ToString(dados.GetValue(8));
            aluno.AnoInicio = Convert.ToInt16(dados.GetValue(9));
            aluno.SemestreInicio = Convert.ToInt16(dados.GetValue(10));

            return aluno;
        }

        public static Aluno BuscarPorId(long id) {
            Aluno Aluno = null;
            try {
                SqlCommand sql = new SqlCommand("select Id,Nome,Cpf,data_nasicmento," +
                    "Email,endereco,Telefone,Identidade,Matricula,ano_inicio,semestre_inicio " +
                    "from Aluno where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                Aluno = getAluno(rec.Rows[0].ItemArray);
            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return Aluno;
        }

        public static List<Aluno> BuscarTodos() {
            List<Aluno> Aluno = new List<Aluno>();
            try {
                SqlCommand sql = new SqlCommand("select Id,Nome,Cpf,data_nasicmento," +
                    "Email,endereco,Telefone,Identidade,Matricula,ano_inicio,semestre_inicio from Aluno", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    Aluno.Add(getAluno(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return Aluno;
        }
        public static bool ExcluirPorId(long Id) {

            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from aluno where id=@id", conn);
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
        public static Boolean Persistir(Aluno aluno) {
            SqlConnection conn = DBUtil.getConnection();
      

            try {

                SqlCommand sql;
                if (aluno.Id>0 ) {
                    
                   sql = new SqlCommand("update aluno set nome = @nome, matricula = @matricula, " +
                        "cpf = @cpf,data_nasicmento = @data_nasicmento, email = @email, semestre_inicio = @semestre_inicio, " +
                        "ano_inicio = @ano_inicio, telefone = @telefone, identidade = @identidade, endereco = @endereco" +
                        "where id = @id", conn);
          
                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into aluno(nome,matricula,cpf,data_nasicmento,email,semestre_inicio,ano_inicio,telefone,identidade,endereco)" +
                        " values(@nome,@matricula,@cpf,@data_nasicmento,@email,@semestre_inicio,@ano_inicio,@telefone,@identidade,@endereco)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", aluno.Id);
                sql.Parameters.AddWithValue("@nome", aluno.Nome);
                sql.Parameters.AddWithValue("@matricula", aluno.Matricula);
                sql.Parameters.AddWithValue("@cpf", aluno.Cpf);
                sql.Parameters.AddWithValue("@data_nasicmento", aluno.DataNascimento);
                sql.Parameters.AddWithValue("@email", aluno.Email);
                sql.Parameters.AddWithValue("@semestre_inicio", aluno.SemestreInicio);
                sql.Parameters.AddWithValue("@ano_inicio", aluno.AnoInicio);
                sql.Parameters.AddWithValue("@telefone", aluno.Telefone);
                sql.Parameters.AddWithValue("@identidade", aluno.Identidade);
                sql.Parameters.AddWithValue("@endereco", aluno.Endereco);
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