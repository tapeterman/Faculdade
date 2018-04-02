using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class TurmaDAO {
        private static Turma getTurma(object[] dados) {
            Turma turma = new Turma();
            turma.Id = Convert.ToInt32(dados.GetValue(0));
            turma.Numero = Convert.ToInt32(dados.GetValue(1));
            turma.Instituicao = InstituicaoDAO.BuscarPorId(Convert.ToInt32(dados.GetValue(2)));
            turma.Curso = CursoDAO.BuscarPorId(Convert.ToInt32(dados.GetValue(3)));
            turma.Professor = ProfessorDAO.BuscarPorId(Convert.ToInt32(dados.GetValue(4)));
            turma.Ano = Convert.ToInt32(dados.GetValue(5));
            turma.Semestre = Convert.ToInt32(dados.GetValue(6));
            return turma;
        }
        public static List<Turma> BuscarTodos() {
            List<Turma> turma = new List<Turma>();
            try {
                SqlCommand sql = new SqlCommand("select * from turma", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    turma.Add(getTurma(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return turma;
        }

        public static bool Persistir(Turma t) {
            SqlConnection conn = DBUtil.getConnection();
            try {
                SqlCommand sql;
                if (t.Id > 0)
                {
                    sql = new SqlCommand("update turma set numero=@numero, ano=@ano, semestre=@semestre, id_Curso=@id_Curso, id_instituicao = @id_instituicao, id_professor=@id_professor where id=@id", conn);
                }
                else
                {
                    t.Id = DBUtil.getNextId("turma");
                    sql = new SqlCommand("insert into turma(id,numero, ano, semestre, id_Curso, id_instituicao, id_professor) values (@id,@numero, @ano, @semestre, @id_Curso, @id_instituicao, @id_professor)", conn);
                }

                conn.Open();
                sql.Parameters.AddWithValue("@id", t.Id);
                sql.Parameters.AddWithValue("@numero", t.Numero);
                sql.Parameters.AddWithValue("@ano", t.Ano);
                sql.Parameters.AddWithValue("@semestre", t.Semestre);
                sql.Parameters.AddWithValue("@id_Curso", t.Curso.Id);
                sql.Parameters.AddWithValue("@id_instituicao", t.Instituicao.Id);
                sql.Parameters.AddWithValue("@id_professor", t.Professor.Id);
                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception e) {
                Debug.WriteLine("Persistencia - Erro ao conectar ao banco de dados" + e.Message);
                return false;
            }
            finally {
                conn.Close();
            }
        }
    }

}