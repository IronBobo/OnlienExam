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
		/// 从一个DataRow中，安全得到列colname中的值：值为字符串类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.String.Empty</returns>
		public static string ValidateDataRow_S(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return row[colname].ToString();
			else
				return System.String.Empty;
		}

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为整数类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
        public static int ValidateDataRow_N(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToInt32(row[colname]);
            else
                return System.Int32.MinValue;
        }

        /// <summary>
        /// 从一个DataRow中，安全得到列colname中的值：值为布尔类型
        /// </summary>
        /// <param name="row">数据行对象</param>
        /// <param name="colname">列名</param>
        /// <returns>如果值存在，返回；否则，返回System.Int32.MinValue</returns>
        public static bool ValidateDataRow_B(DataRow row, string colname)
        {
            if (row[colname] != DBNull.Value)
                return Convert.ToBoolean(row[colname]);
            else
                return false;
        }

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为浮点数类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.Double.MinValue</returns>
		public static double ValidateDataRow_F(DataRow row,string colname)
		{
			if(row[colname]!=DBNull.Value)
				return Convert.ToDouble(row[colname]);
			else
				return System.Double.MinValue;	
		}

		/// <summary>
		/// 从一个DataRow中，安全得到列colname中的值：值为时间类型
		/// </summary>
		/// <param name="row">数据行对象</param>
		/// <param name="colname">列名</param>
		/// <returns>如果值存在，返回；否则，返回System.DateTime.MinValue;</returns>
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
