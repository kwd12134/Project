using KWDHTMmodels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thinger.MultiTHMonitorDAL;

namespace KWD.MHTDAL
{
    /// <summary>
    ///  数据访问层
    /// </summary>
    public class SysAdminService
    {

        public SysAdmin AdminLogin(SysAdmin sysAdmin)
        {

            string sql = "select LoginId,ParamSet,Recipe,HistoryLog,HistoryTrend,UserManage";
            sql += " from SysAdmin Where LoginName=@LoginLog and LoginPwd=@LoginPwd";
            //验证用户是否存在
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@LoginLog",sysAdmin.LoginName.ToString().Trim()),
                new SqlParameter("@loginPwd",sysAdmin.Loginpwd.ToString().Trim())
            };

            DataSet dataSet = SQLHelper.GetDataSet(sql, param);

            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count==1)
            {
                sysAdmin.Loginid = (int)dataSet.Tables[0].Rows[0]["LoginId"];
                sysAdmin.ParamSet = (bool)dataSet.Tables[0].Rows[0]["ParamSet"];
                sysAdmin.Recipe = (bool)dataSet.Tables[0].Rows[0]["Recipe"];
                sysAdmin.HistoryLog = (bool)dataSet.Tables[0].Rows[0]["HistoryLog"];
                sysAdmin.HistoryTrend = (bool)dataSet.Tables[0].Rows[0]["HistoryTrend"];
                sysAdmin.UserManage = (bool)dataSet.Tables[0].Rows[0]["UserManage"];

                return sysAdmin;
            }
            else
            {
                return null;
            }
        }

    }
}
