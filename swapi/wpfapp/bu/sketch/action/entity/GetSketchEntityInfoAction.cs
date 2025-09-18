using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.entity;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action.entity
{
    /// <summary>
    /// 绘制圆角
    /// </summary>
    public class GetSketchEntityInfoAction : SwSketchEditActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public GetSketchEntityInfoAction(object oInVo) : base(oInVo)
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            GetSketchEntityInfoInVo oInVo = this.actionInVo<GetSketchEntityInfoInVo>();

            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 获取当前草图
            ISketch swSketch = skeMgr.ActiveSketch as ISketch;

            // 获取图形信息
            SketchEntityInfo oEntityInfo = SketchEntityConverter.GetSketchEntiyInfo(swSketch);

            return RespVoLogExt.genOk("获取草图实体信息成功", oEntityInfo);
        }
    }
}
