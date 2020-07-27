using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace OnLineExamDAL
{
    public class GetSafeData
    {
        #region DataRow

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ�ַ�������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.String.Empty</returns>
		public static string ValidateDataRow_S(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return row[colname].ToString();
			else
				return System.String.Empty;
		}

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ��������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.Int32.MinValue</returns>
        public static int ValidateDataRow_N(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToInt32(row[colname]);
            else
                return System.Int32.MinValue;
        }

        /// <summary>
        /// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ��������
        /// </summary>
        /// <param name="row">�����ж���</param>
        /// <param name="colname">����</param>
        /// <returns>���ֵ���ڣ����أ����򣬷���System.Int32.MinValue</returns>
        public static bool ValidateDataRow_B(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToBoolean(row[colname]);
            else
                return false;
        }

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪ����������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.Double.MinValue</returns>
		public static double ValidateDataRow_F(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDouble(row[colname]);
			else
				return System.Double.MinValue;	
		}

		/// <summary>
		/// ��һ��DataRow�У���ȫ�õ���colname�е�ֵ��ֵΪʱ������
		/// </summary>
		/// <param name="row">�����ж���</param>
		/// <param name="colname">����</param>
		/// <returns>���ֵ���ڣ����أ����򣬷���System.DateTime.MinValue;</returns>
		public static DateTime ValidateDataRow_T(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDateTime(row[colname]);
			else 
				return System.DateTime.MinValue;	
		}

		#endregion DataRow
	}
    
}
