using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.draw.define;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.draw.define
{
    /// <summary>
    /// 完全草图定义
    /// </summary>
    public class FullyDefineSketchAction : SwSketchDrawActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FullyDefineSketchAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FullyDefineSketchInVo oInVo = this.actionInVo<FullyDefineSketchInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            //longstatus = Part.SketchManager.FullyDefineSketch(True, True, 1023, True, 1, hDatumObj, 1, vDatumObj, -1, -1)
            // 绘制图形
            int ret = skeMgr.FullyDefineSketch(true, true, 1023, true, 1, null, 1, null, 1, 1);

            return RespVoLogExt.genOk("完全草图定义成功");
        }
    }
}
