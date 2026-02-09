using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections;
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
    /// 装配体插入多个零部件
    /// </summary>
    public class AddComponentsAction : SwAssemblyActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public AddComponentsAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            AddComponentsInVo oInVo = this.actionInVo<AddComponentsInVo>();

            // 获取装配体文档
            AssemblyDoc assemlyDoc = curAssemlyDoc;
            string strAssemlyDocTitle = curDoc.GetTitle();

            int nCompCount = oInVo.ComponentInfoVos.Count();
            var strCompNames = new string[nCompCount];
            var strCoordinateSystemNames = new string[nCompCount];
            var nMatrixSize = 16;
            var dCompMatrixs = new double[nCompCount * nMatrixSize];
            for (int i = 0; i < nCompCount; i++)
            {
                AddComponentInfoVo oAddComponentInfoVo = oInVo.ComponentInfoVos[i];
                strCompNames[i] = oAddComponentInfoVo.CompName;
                strCoordinateSystemNames[i] = oAddComponentInfoVo.CoordinateSystemName;
                double[] dMatrixs = oAddComponentInfoVo.TransformMatrix.toDoubles();
                int nMatrixStartIndex = i * nMatrixSize;
                for (int j = 0; j < nMatrixSize && j < dMatrixs.Length; j++)
                {
                    dCompMatrixs[nMatrixStartIndex + j] = dMatrixs[j];
                }
            }

            // 添加多个零部件
            var oComponents = (IEnumerable)assemlyDoc.AddComponents3(
                strCompNames,
                dCompMatrixs,
                strCoordinateSystemNames) as object[];
            string strError = "";
            for(int iIndex = 0; iIndex < oComponents.Length; iIndex++)
            {
                Component2 oComponent = (Component2)oComponents[iIndex];
                if (oComponent == null)
                {
                    strError += $"{oInVo.ComponentInfoVos[iIndex].CompName},";
                }
                else
                {
                    // 设置零部件名称
                    if (!string.IsNullOrEmpty(oInVo.ComponentInfoVos[iIndex].ComponentName))
                    {
                        oComponent.Name2 = oInVo.ComponentInfoVos[iIndex].ComponentName;
                    }
                }
            }

            if (!string.IsNullOrEmpty(strError))
            {
                return RespVoLogExt.genError($"添加零部件文档失败, {strError}");
            }

            return RespVoLogExt.genOk("添加多个零部件完成");
        }

    }
}