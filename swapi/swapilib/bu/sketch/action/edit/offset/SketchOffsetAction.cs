using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.bu.log;
using swapilib.bu.sketch.vo.edit.offset;
using swapilib.basic.io;

namespace swapilib.bu.sketch.action.edit.offset
{
    /// <summary>
    /// 偏移实体
    /// </summary>
    public class SketchOffsetAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SketchOffsetAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            SketchOffsetInVo oInVo = this.actionInVo<SketchOffsetInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 编辑图形
            var bOk = skeMgr.SketchOffset2(oInVo.Offset / 1000, oInVo.BothDirections, oInVo.Chain, oInVo.CapEnds, oInVo.MakeConstruction, oInVo.AddDimensions);
            if (!bOk)
            {
                return RespVoLogExt.genError("绘制参数错误");
            }

            return RespVoLogExt.genOk("偏移实体成功");
        }
    }
}
