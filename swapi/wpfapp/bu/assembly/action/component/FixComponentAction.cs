using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.assembly.vo.component;
using wpfapp.bu.feature.vo.feature.curve;
using wpfapp.bu.log;

namespace wpfapp.bu.assembly.action.component
{
    /// <summary>
    /// 固定零部件
    /// </summary>
    public class FixComponentAction : SwAssemblyActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public FixComponentAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            FixComponentInVo oInVo = this.actionInVo<FixComponentInVo>();

            // 获取装配体文档
            AssemblyDoc assemlyDoc = curAssemlyDoc;

            // 固定零部件
            assemlyDoc.FixComponent();

            return RespVoLogExt.genOk("固定零部件完成");
        }

    }
}