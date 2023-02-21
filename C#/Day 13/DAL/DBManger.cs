using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBManger
    {
        SqlConnection sqlCN;
        SqlCommand sqlCMD;
        SqlDataAdapter sqlDA;
        DataTable Dt;

        public DBManger()
        {
            sqlCN = new SqlConnection(ConfigurationManager.ConnectionStrings["PubsCN"].ConnectionString);
            sqlCMD = new SqlCommand();
            sqlCMD.CommandType = CommandType.StoredProcedure;
            sqlCMD.Connection = sqlCN;
            sqlDA = new SqlDataAdapter(sqlCMD);
            Dt = new DataTable();
        }
        public int ExecuteNonQuery(string SP)
        {
            try
            {
                sqlCMD.Parameters.Clear();

                sqlCMD.CommandText = SP;

                if(sqlCN.State != ConnectionState.Open)
                    sqlCN.Open();

                return sqlCMD.ExecuteNonQuery();
            }
            catch 
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public int ExecuteNonQuery(string SP, Dictionary<string, object> dictParam)
        {
            try
            {
                sqlCMD.Parameters.Clear();

                sqlCMD.CommandText = SP;
                foreach (var item in dictParam)
                {
                    sqlCMD.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }

                if (sqlCN.State != ConnectionState.Open)
                    sqlCN.Open();

                return sqlCMD.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SP)
        {
            try
            {
                sqlCMD.Parameters.Clear();

                sqlCMD.CommandText = SP;

                if(sqlCN.State != ConnectionState.Open)
                    sqlCN.Open();

                return sqlCMD.ExecuteScalar();
            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public DataTable ExecuteDataTable(string SP) 
        {
            try
            {
                Dt.Clear();
                sqlCMD.Parameters.Clear();

                sqlCMD.CommandText = SP;

                sqlDA.Fill(Dt);
                return Dt;
            }
            catch
            {
                return new DataTable();
            }
        }
        
    }
}