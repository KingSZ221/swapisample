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
    public class RespErrVo
    {
        #region Fileds

        /// <summary>
        /// 错误信息列表
        /// </summary>
        public List<RespErrItemVo> items = null;

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RespErrVo() 
        {
            this.items = new List<RespErrItemVo>();
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RespErrVo(string strDesc)
        {
            this.items = new List<RespErrItemVo>();
            this.items.Add(new RespErrItemVo(strDesc));
        }
    }
}
