using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnLineExamDAL
{
    public class DBHelp
    {
     
        public static SqlConnection GetConnection()
        {
            string connStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }
        //���캯��
        public DBHelp()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        private static SqlConnection connection;
        protected static string ConnectionString;
        public static SqlConnection Connection
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }


        public static int ExecuteCommand(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }

        public static int GetScalar(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }

        public static SqlDataReader GetReader(string safeSql)
        {
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static SqlDataReader GetReader(string sql, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(safeSql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }



        private static void Open()
        {
            //�ж����ݿ������Ƿ����
            if (connection == null)
            {
                //�����ڣ��½�����
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            else
            {
                //���ڣ��ж��Ƿ��ڹر�״̬
                if (connection.State.Equals(ConnectionState.Closed))
                    connection.Open();    //���Ӵ��ڹر�״̬�����´�
            }
        }

        //���з������ر����ݿ�����
        public static void Close()
        {
            if (Connection.State.Equals(ConnectionState.Open))
            {
                Connection.Close();     //���Ӵ��ڴ�״̬���ر�����
            }
        }
        //���з��������ô洢����(��������)
        //���룺
        //			ProcName�洢������
        //�����
        //			��ִ�н����DataSet����    
        public DataSet GetDataSets(string ProcName)
        {
            Open();
            SqlDataAdapter adapter = new SqlDataAdapter(ProcName, Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            Close();
            return dataset;
        }

        //���з���������Sql��䣬����һ��������ݼ�
        public DataSet GetDataSetSql(string XSqlString)
        {
            Open();
            SqlDataAdapter Adapter = new SqlDataAdapter(XSqlString, Connection);
            DataSet Ds = new DataSet();
            Adapter.Fill(Ds);
            Close();
            return Ds;
        }



        //���з���������Sql��䣬�����¼
        public int Insert(string XSqlString)
        {
            int Count = -1;
            Open();
            SqlCommand cmd = new SqlCommand(XSqlString, Connection);
            Count = cmd.ExecuteNonQuery();
            Close();
            return Count;
        }
    }
}