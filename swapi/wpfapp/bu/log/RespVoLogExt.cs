using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.vo;

namespace wpfapp.bu.log
{
    public static class RespVoLogExt
    {
        public static RespVo genException(Exception ex, string strMsg)
        {
            SwBuLogService.SException(ex, strMsg);
            return RespVo.genError(strMsg);
        }

        public static RespVo genError(string strMsg)
        {
            SwBuLogService.SError(strMsg);
            return RespVo.genError(strMsg);
        }

        public static RespVo genOk(string strMsg)
        {
            SwBuLogService.SInfo(strMsg);
            return RespVo.genOk(strMsg); ;
        }
    }
}
