using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo.view;

namespace wpfapp.bu.sketch.action.view
{
    /// <summary>
    /// 显示视图
    /// </summary>
    public class ShowNamedViewAction : SwModelDocActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public ShowNamedViewAction() : base()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            ShowNamedViewInVo oInVo = this.actionInVo<ShowNamedViewInVo>();

            // 编辑图形
            curDoc.ShowNamedView2(oInVo.VName, oInVo.ViewId);
            curDoc.ViewZoomtofit2();

            return RespVoLogExt.genOk("清空选中对象列表完成");
        }
    }
}
