using KYJDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLBLL
{
    public class SQLiteQuery
    {
        /// <summary>
        /// 查询用户是否存在,存在返回对应数据
        /// </summary>
        /// <param name="Admin"></param>
        /// <returns></returns>
        public static DataSet QueryUser()
        {
            string sql = "select Id,Admin,Pwd,Power from SysAdmin where Admin=@Admin";
            DataSet dataSet = null;
            SQLiteParameter[] sqlParameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@Admin",AdminManager.Admin)
            };
            try
            {
                dataSet = SQLiteHelper.GetDataSet(sql, sqlParameter);
            }
            catch (Exception)
            {
                return null;
            }

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return dataSet;
            }
            else
            {
                return null;
            }
        }

        public static DataSet QueryUser(string Name)
        {
            string sql = "select Id,Admin,Pwd,Power from SysAdmin where Admin=@Admin";
            DataSet dataSet = null;
            SQLiteParameter[] sqlParameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@Admin",Name)
            };
            try
            {
                dataSet = SQLiteHelper.GetDataSet(sql, sqlParameter);
            }
            catch (Exception)
            {
                return null;
            }

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                return dataSet;
            }
            else
            {
                return null;
            }
        }

        public static bool UpDateUserPwd(string Pwd,string Id)
        {
            string sql = "update  SysAdmin set Pwd=@Pwd where Id=@Id";
            int dataSet;
            SQLiteParameter[] sqlParameter = new SQLiteParameter[]
            {
                new SQLiteParameter("@Pwd",Pwd),
                new SQLiteParameter("@Id",Id),
            };
            try
            {
                 dataSet = SQLiteHelper.ExecuteNonQuery(sql, sqlParameter);
            }
            catch (Exception)
            {
                return false;
            }
            if (dataSet==1)
            {
                return true;
            }
            return false;
        }
    }
}
