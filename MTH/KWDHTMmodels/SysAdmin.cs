using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWDHTMmodels
{
    public class SysAdmin
    {

        public int Loginid { get; set; }

        public string  LoginName { get; set; }

        public string Loginpwd { get; set; }

        public bool ParamSet { get; set; }

        public bool Recipe { get; set; }

        public bool HistoryLog { get; set; }

        public bool  HistoryTrend { get; set; }

        public bool UserManage { get; set; }
    }
}
