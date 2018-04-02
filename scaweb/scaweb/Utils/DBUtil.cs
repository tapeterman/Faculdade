using System;
using System.Data;
using System.Data.SqlClient;

namespace scaweb.Utils {
    class DBUtil {
        private static SqlConnection con;

        public static SqlConnection getConnection() {
            if (con == null) {
                string strcon = @"Data Source=LAPTOP-NOB1T62L\SQLEXPRESS;Initial Catalog=matricula;Integrated Security=True"; ;
                con = new SqlConnection(strcon);
                con.ConnectionString = strcon;
            }

            return con;
        }

        public static void closeConnection() {
            if (con != null) {
                con.Close();
                con = null;
            }
        }

        /**
         * Calcula o proximo ID para a Tabela
         * parametro tabela - Nome da tabela para o calculo do proximo ID.
         */
        public static int getNextId(string tabela) {
            SqlCommand cmd = new SqlCommand("SP_GETNEXTID", getConnection());

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TABELA", tabela);
            cmd.Parameters.AddWithValue("@CAMPO", "id");

            SqlParameter paraout = new SqlParameter("@ID", SqlDbType.BigInt);
            paraout.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(paraout);

            getConnection().Open();
            cmd.ExecuteNonQuery();

            int valor = (int.Parse(cmd.Parameters["@ID"].Value.ToString()));
            closeConnection();

            return valor;
        }



        /// <summary>
        /// Método responsável por criar a conexão com o banco e executar as query.
        /// </summary>
        public static bool GetResultQuery(string query, DataTable dt) {
            try {
                if (dt == null)
                    return false;

                // Cria a conexão com o banco.
                SqlConnection conn = getConnection();
                conn.Open();

                // Executar a query. 
                SqlDataAdapter da = new SqlDataAdapter(query, conn);

                // Fill-preenche o datatable com o que foi guardado no dataadapter.
                da.Fill(dt);

                conn.Close();

                return true;

            }
            catch (Exception e) {
                closeConnection();
                return false;
            }

        }
    }
}
