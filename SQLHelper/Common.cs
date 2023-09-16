using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MyPage.SQLHelper
{
    public static class Common
    {
        //Get Data
        public static DataTable GetData(string sp, SqlParameter[] sqlParameters)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sp, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    if (sqlParameters != null)
                    {
                        for (int ParamCount = 0; ParamCount < sqlParameters.Length; ParamCount++)
                        {
                            if (sqlParameters[ParamCount] != null)
                            {
                                command.Parameters.Add(sqlParameters[ParamCount]);
                            }
                        }
                    }

                    dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dt);

                    conn.Close();
                }

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Set Data
        public static string SetData(string sp, SqlParameter[] sqlParameters, int p1)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(sp, conn);
                    command.CommandType = CommandType.StoredProcedure;

                    if (sqlParameters != null)
                    {
                        for (int ParamCount = 0; ParamCount < sqlParameters.Length; ParamCount++)
                        {
                            if (sqlParameters[ParamCount] != null)
                            {
                                command.Parameters.Add(sqlParameters[ParamCount]);
                            }
                        }
                    }

                    command.ExecuteNonQuery();

                    string msg = sqlParameters[p1].Value.ToString();


                    conn.Close();
                    return msg;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get Data Using String Command(Only for special purpose)
        public static DataTable GetStringCommandData(string query)
        {
            try
            {
                DataTable data = new DataTable();
                SqlDataAdapter dataAdapter;

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);

                    dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(data);
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Set Data Using String Command(Only for special purpose)
        public static void SetStringCommandData(string query)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString()))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Encrypt String Data
        public static string EncryptString(string data)
        {
            try
            {
                byte[] encData = new byte[data.Length];
                encData = Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Decrypt String Data
        [Obsolete]
        public static string DecryptString(string encodedData)
        {
            try
            {
                UTF8Encoding encoder = new UTF8Encoding();
                Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(encodedData);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}