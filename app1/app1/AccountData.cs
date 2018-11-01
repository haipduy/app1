using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace app1
{
    public class AccountData
    {
        string strConnection;

        public AccountData()
        {
            strConnection = getConnectionString();
        }

        public string getConnectionString()
        {
            string strConnectionString = "server=DUYPNKSE62427\\SQLEXPRESS5;database=ToyManagementPrj;uid=sa;pwd=1";
            return strConnectionString;
        }

        public bool CheckLogin(string username, string password)
        {
            bool result;
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = ("select Username, Password from Account where Username=@ID and Password=@Password");
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("ID", username);
            cmd.Parameters.AddWithValue("Password", password);

            try
            {
                if (cnn.State == System.Data.ConnectionState.Closed)
                {
                    cnn.Open();
                }
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                result = sqlDataReader.Read();
                sqlDataReader.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return (result);
        }
    }
}
