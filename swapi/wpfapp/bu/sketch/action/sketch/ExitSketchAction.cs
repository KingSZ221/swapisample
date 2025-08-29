using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.sketch
{
    /// <summary>
    /// 进入草图编辑模式
    /// </summary>
    public class ExitSketchAction : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public ExitSketchAction(object oInVo) : base(oInVo)
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

            // 获取扩展文档
            var swModelDocExt = swModelDoc.Extension;
            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            if (skeMgr.ActiveSketch != null)
            {
                // 退出编辑草图模式
                skeMgr.InsertSketch(true);
            }

            return RespVoLogExt.genOk("退出草图绘制模式");
        }
    }
}
