using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.feature
{
    /// <summary>
    /// 特征操作基类
    /// </summary>
    public class SwSketchFeatureActionBase : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SwSketchFeatureActionBase(object oInVo) : base(oInVo)
        {

        }

        #endregion


        public override RespVo execute()
        {
            // 检查当前激活文档是否零件
            ModelDoc2 swModelDoc = null;
            RespVo oRespVo = priCheckPartDoc(ref swModelDoc);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 执行绘制操作
            try
            {
                oRespVo = onExecute();
            }
            catch (Exception ex)
            {
                oRespVo = RespVoLogExt.genException(ex, "操作发送异常");
            }

            return oRespVo;
        }
    }
}
