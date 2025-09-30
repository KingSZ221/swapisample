using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.line;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.line
{
    /// <summary>
    /// 绘制直线
    /// </summary>
    public class CreateLineAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction
        
        public CreateLineAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateLineInVo oInVo = this.actionInVo<CreateLineInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            var sketchSegment = skeMgr.CreateLine(oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000) as ISketchSegment;
            if (sketchSegment == null)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            // 添加固定约束关系
            curDoc.SketchAddConstraints("sgFIXED");

            return RespVoLogExt.genOk("绘制直线成功");
        }
    }
}
