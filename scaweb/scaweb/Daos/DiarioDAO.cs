using scaweb.Models;
using scaweb.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace scaweb.Daos {
    public static class DiarioDAO {
        private static Diario getDiario(object[] dados) {

            Diario diario = new Diario();
            diario.V1 = Convert.ToInt32(dados.GetValue(0));
            diario.V2 = Convert.ToInt32(dados.GetValue(0));
            diario.Vs = Convert.ToInt32(dados.GetValue(0));
            diario.Vt = Convert.ToInt32(dados.GetValue(0));
            diario.Faltas = Convert.ToInt32(dados.GetValue(0));

            return diario;

        }

        public static Diario BuscarPorId(long id) {

            Diario Diario = null;

            try {

                SqlCommand sql = new SqlCommand("select v1,v2,vs,vt,faltas from Diario where id=@id", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.Parameters.AddWithValue("@id", id);
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                Diario = getDiario(rec.Rows[0].ItemArray);

            }
            catch (Exception e) {
                Debug.WriteLine("Erro ao buscar por id da instituição" + e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }

            return Diario;
        }

        public static List<Diario> BuscarTodos() {
            List<Diario> Diario = new List<Diario>();
            try {
                SqlCommand sql = new SqlCommand("select v1,v2,vs,vt,faltas from Diario", DBUtil.getConnection());
                DBUtil.getConnection().Open();
                sql.ExecuteNonQuery();
                DataTable rec = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter();
                data.SelectCommand = sql;
                data.Fill(rec);
                for (int i = 0; i < rec.Rows.Count; i++) {
                    Diario.Add(getDiario(rec.Rows[i].ItemArray));
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
            finally {
                DBUtil.closeConnection();
            }
            return Diario;
        }
 
    }

}