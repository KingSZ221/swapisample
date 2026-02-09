using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.basic.io
{
    /// <summary>
    /// 请求返回值错误信息
    /// </summary>
    public class RespErrItemVo
    {
        #region Fileds

        /// <summary>
        /// 错误码
        /// </summary>
        public string code = "";

        /// <summary>
        /// 错误描述
        /// </summary>
        public string desc = "";

        /// <summary>
        /// 错误原因
        /// </summary>
        public string reason = "";

        /// <summary>
        /// 建议
        /// </summary>
        public string advice = "";

        #endregion

        #region Construction

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RespErrItemVo() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bOk"></param>
        /// <param name="strMsg"></param>
        public RespErrItemVo(string strDesc)
        {
            this.desc = strDesc;
        }

        #endregion
    }
}
