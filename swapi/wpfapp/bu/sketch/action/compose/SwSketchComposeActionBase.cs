using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.log;
using wpfapp.basic.io;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.sketch.action.compose
{
    /// <summary>
    /// 组合操作基类
    /// </summary>
    public class SwSketchComposeActionBase : SwSketchActionBase
    {
        #region Construction

        public SwSketchComposeActionBase() : base()
        {

        }

        #endregion

        #region execute

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

        #endregion
    }
}
