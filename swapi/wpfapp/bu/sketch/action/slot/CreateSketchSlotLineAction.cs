﻿using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.slot;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.slot
{
    /// <summary>
    /// 绘制直槽口
    /// </summary>
    public class CreateSketchSlotLineAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateSketchSlotLineAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateSketchSlotLineInVo oInVo = this.actionInVo<CreateSketchSlotLineInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 绘制图形
            skeMgr.CreateSketchSlot((int)swSketchSlotCreationType_e.swSketchSlotCreationType_line, oInVo.SlotLengthType, oInVo.Width / 1000,
                oInVo.X1 / 1000, oInVo.Y1 / 1000, oInVo.Z1 / 1000,
                oInVo.X2 / 1000, oInVo.Y2 / 1000, oInVo.Z2 / 1000,
                oInVo.X3 / 1000, oInVo.Y3 / 1000, oInVo.Z3 / 1000,
                oInVo.CenterArcDirection, oInVo.AddDimension);

            return RespVoLogExt.genOk("绘制直槽口成功");
        }
    }
}
