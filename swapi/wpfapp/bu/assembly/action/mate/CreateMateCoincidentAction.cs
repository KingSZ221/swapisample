using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.assembly.vo.component;
using wpfapp.bu.assembly.vo.mate;
using wpfapp.bu.feature.vo.feature.curve;
using wpfapp.bu.log;

namespace wpfapp.bu.assembly.action.mate
{
    /// <summary>
    /// 创建重合配合
    /// </summary>
    public class CreateMateCoincidentAction : SwAssemblyActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public CreateMateCoincidentAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            CreateMateCoincidentInVo oInVo = this.actionInVo<CreateMateCoincidentInVo>();

            // 获取装配体文档
            AssemblyDoc assemlyDoc = curAssemlyDoc;

            // 创建配合数据
            MateFeatureData mateData = (MateFeatureData)assemlyDoc.CreateMateData((int)swMateType_e.swMateCOINCIDENT);
            CoincidentMateFeatureData coincMateData = (CoincidentMateFeatureData)mateData;

            // 赋值配合参数
            coincMateData.MateAlignment = (int)oInVo.MateAlignment;

            // 创建配合
            assemlyDoc.CreateMate(coincMateData);

            // 检查错误
            swAddMateError_ext metaError = (swAddMateError_ext)mateData.ErrorStatus;
            if (metaError != swAddMateError_ext.swAddMateError_NoError)
            {
                return RespVoLogExt.genOk($"创建配合参数错误，{metaError.ToString()}");
            }

            return RespVoLogExt.genOk("创建重合配合成功");

        }

    }
}