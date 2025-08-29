using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.sketch.vo.sketch;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.sketch
{
    /// <summary>
    /// 进入草图编辑模式
    /// </summary>
    public class EditSketchAction : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public EditSketchAction(object oInVo) : base(oInVo)
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

            // 获取绘制参数
            EditSketchInVo oInVo = this.actionInVo<EditSketchInVo>();
            if (string.IsNullOrEmpty(oInVo.SketchName))
            {
                if (skeMgr.ActiveSketch != null)
                {
                    // 退出编辑草图模式
                    skeMgr.InsertSketch(true);
                }

                // 如果草图名称为空，则选中参考基准面绘制草图;
                // 如果参考基准面为空，则以前视基准面绘制草图
                string sketchName = oInVo.SketchName;
                if(string.IsNullOrEmpty(sketchName))
                {
                    sketchName = "前视基准面";
                }

                // 选中基准面
                if (!swModelDocExt.SelectByID2(sketchName, "PLANE", 0, 0, 0, false, 0, null, 0))
                {
                    return RespVoLogExt.genOk("基准面不存在");
                }

                // 在这个基准面上插入一个草图，进入编辑草图模式
                skeMgr.InsertSketch(true);
            }
            else
            {
                if (skeMgr.ActiveSketch != null)
                {
                    // 退出编辑草图模式
                    skeMgr.InsertSketch(true);
                }

                // 如果草图名称不为空，则打开该草图进行绘制
                if (!swModelDocExt.SelectByID2(oInVo.SketchName, "SKETCH", 0, 0, 0, false, 0, null, 0))
                {
                    return RespVoLogExt.genOk($"草图不存在: {oInVo.SketchName}");
                }

                // 在这个基准面上插入一个草图，进入编辑草图模式
                skeMgr.InsertSketch(true);
            }

            return RespVoLogExt.genOk("进入草图绘制模式");
        }
    }
}
