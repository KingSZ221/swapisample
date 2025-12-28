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
    /// 浮动零部件
    /// </summary>
    public class UnfixComponentAction : SwAssemblyActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public UnfixComponentAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            UnfixComponentInVo oInVo = this.actionInVo<UnfixComponentInVo>();

            // 获取装配体文档
            AssemblyDoc assemlyDoc = curAssemlyDoc;

            // 浮动零部件
            assemlyDoc.UnfixComponent();

            return RespVoLogExt.genOk("浮动零部件完成");
        }

    }
}