using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using swapilib.basic.io;
using swapilib.bu.assembly.vo.component;
using swapilib.bu.feature.vo.feature.curve;
using swapilib.bu.log;

namespace swapilib.bu.assembly.action.component
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