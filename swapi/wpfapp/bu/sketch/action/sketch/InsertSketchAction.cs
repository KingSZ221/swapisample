using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.basic.io;

namespace wpfapp.bu.sketch.action.sketch
{
    /// <summary>
    /// 插入草图
    /// </summary>
    public class InsertSketchAction : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public InsertSketchAction() : base()
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

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 获取绘制参数
            InsertSketchInVo oInVo = this.actionInVo<InsertSketchInVo>();
            skeMgr.InsertSketch(oInVo.UpdateEditRebuild);

            return RespVoLogExt.genOk("插入草图完成");
        }
    }
}
