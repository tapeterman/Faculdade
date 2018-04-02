using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class ProfessorDAO {
        private static Professor getProfessor(object[] dados) {
            Professor professor = new Professor();
            professor.Id = Convert.ToInt32(dados.GetValue(0));
            professor.Nome = Convert.ToString(dados.GetValue(1));
            professor.Cpf = Convert.ToString(dados.GetValue(2));
            professor.DataNascimento = Convert.ToDateTime(dados.GetValue(3));
            professor.Email = Convert.ToString(dados.GetValue(4));
            professor.Endereco = Convert.ToString(dados.GetValue(5));
            professor.Telefone = Convert.ToString(dados.GetValue(6));
            professor.Identidade = Convert.ToString(dados.GetValue(7));
            professor.Matricula = Convert.ToString(dados.GetValue(8));
            professor.TitulacaoMaxima = Convert.ToInt16(dados.GetValue(9));

            return professor;
        }
        
        public static Professor BuscarPorId(long id) {
            Professor professor = null;
            try {
                SqlCommand sql = new SqlCommand("select  Id,Nome,Cpf,data_nascimento,Email," +
                    "Endereco,Telefone,Identidade,Matricula,titulacao_maxima " +
                    "from professor where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                professor = getProfessor(rec.Rows[0].ItemArray);
            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return professor;
        }

        public static List<Professor> BuscarTodos() {
            List<Professor> professor = new List<Professor>();
            try {
                SqlCommand sql = new SqlCommand("select  Id,Nome,Cpf,data_nascimento," +
                    "Email,Endereco,Telefone,Identidade,Matricula,titulacao_maxima " +
                    "from professor", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    professor.Add(getProfessor(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return professor;
        }
        public static bool ExcluirPorId(long Id) {

            SqlConnection conn = DBUtil.getConnection();
            int total = 0;
            try {

                SqlCommand sql;
                sql = new SqlCommand("delete from professor where id=@id", conn);
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
        public static Boolean Persistir(Professor professor) {
            SqlConnection conn = DBUtil.getConnection();
            try {

                SqlCommand sql;
                if (professor.Id > 0) {

                    sql = new SqlCommand("update professor set nome = @nome, matricula = @matricula, " +
                        "cpf = @cpf, data_nascimento = @data_nascimento, email = @email, titulacao_maxima = @titulacao_maxima, " +
                        "endereco = @endereco, telefone = @telefone, identidade = @identidade " +
                        "where id = @id", conn);


                }
                else {

                    //instituicao.Id = DBUtil.getNextId("instituicao");
                    sql = new SqlCommand("insert into professor(nome,matricula,cpf,data_nascimento,email,titulacao_maxima,endereco,telefone,identidade)" +
                        " values(@nome,@matricula,@cpf,@data_nascimento,@email,@titulacao_maxima,@endereco,@telefone,@identidade)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", professor.Id);
                sql.Parameters.AddWithValue("@nome", professor.Nome);
                sql.Parameters.AddWithValue("@matricula", professor.Matricula);
                sql.Parameters.AddWithValue("@cpf", professor.Cpf);
                sql.Parameters.AddWithValue("@data_nascimento", professor.DataNascimento);
                sql.Parameters.AddWithValue("@email", professor.Email);
                sql.Parameters.AddWithValue("@titulacao_maxima", professor.TitulacaoMaxima);
                sql.Parameters.AddWithValue("@endereco", professor.Endereco);
                sql.Parameters.AddWithValue("@telefone", professor.Telefone);
                sql.Parameters.AddWithValue("@identidade", professor.Identidade);
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