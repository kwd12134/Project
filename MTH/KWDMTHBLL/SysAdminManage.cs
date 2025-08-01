using KWD.MHTDAL;
using KWDHTMmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWDMTHBLL
{
    /// <summary>
    /// 业务或者逻辑层   
    /// </summary>
    public class SysAdminManage
    {
        private SysAdminService sysAdminService = new SysAdminService();

        public SysAdmin SysAdminLogin(SysAdmin sysAdmin)
        {
            return sysAdminService.AdminLogin(sysAdmin);
        }
    }
}
