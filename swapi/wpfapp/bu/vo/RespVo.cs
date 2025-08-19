using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.vo
{
    /// <summary>
    /// 请求返回值
    /// </summary>
    public class RespVo
    {
        #region Fileds

        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool ok = false;

        /// <summary>
        /// 操作返回信息
        /// </summary>
        public string msg = "";

        #endregion

        #region Construction

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RespVo() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bOk"></param>
        /// <param name="strMsg"></param>
        public RespVo(bool bOk, string strMsg)
        {
            this.ok = bOk;
            this.msg = strMsg;
        }

        #endregion

        #region gen

        /// <summary>
        /// 构造成功RespVo
        /// </summary>
        /// <returns>RespVo</returns>
        public static RespVo genOk()
        {
            return new RespVo(true, "");
        }

        /// <summary>
        /// 构造成功RespVo
        /// </summary>
        /// <returns>RespVo</returns>
        public static RespVo genOk(string strMsg)
        {
            return new RespVo(true, strMsg);
        }

        /// <summary>
        /// 构造失败RespVo
        /// </summary>
        /// <param name="strMsg">失败信息</param>
        /// <returns>RespVo</returns>
        public static RespVo genError(string strMsg)
        {
            return new RespVo(false, strMsg);
        }

        #endregion
    }
}
