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
    /// 装配体插入单个零部件
    /// </summary>
    public class AddComponentAction : SwAssemblyActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public AddComponentAction()
        {

        }

        #endregion

        protected override RespVo onExecute()
        {
            // 获取绘制参数
            AddComponentInVo oInVo = this.actionInVo<AddComponentInVo>();

            // 获取装配体文档
            AssemblyDoc assemlyDoc = curAssemlyDoc;
            string strAssemlyDocTitle = curDoc.GetTitle();

            int errors = 0;
            int warnings = 0;
            // 打开零部件文件，如果打开成功，则变成当前激活文档
            var doc = swApp.Sw.OpenDoc6(oInVo.CompName, (int)swDocumentTypes_e.swDocPART, (int)swOpenDocOptions_e.swOpenDocOptions_Silent, "", ref errors, ref warnings);
            if (doc == null)
            {
                return RespVoLogExt.genError($"打开零部件文档失败, {oInVo.CompName} ，错误代码： {errors}");
            }

            // 重新激活零部件文档
            swApp.Sw.ActivateDoc3(strAssemlyDocTitle, true, 0, ref errors);

            // 添加1个零部件
            Component2 oComponent = assemlyDoc.AddComponent5(
                oInVo.CompName, 
                (int)oInVo.ConfigOption, 
                oInVo.NewConfigName, 
                oInVo.UseConfigForPartReferences,
                oInVo.ExistingConfigName,
                oInVo.X / 1000, oInVo.Y / 1000, oInVo.Z / 1000);
            if (oComponent == null)
            {
                return RespVoLogExt.genError($"添加零部件文档失败, {oInVo.CompName}");
            }

            // 设置零部件名称
            if (!string.IsNullOrEmpty(oInVo.ComponentName))
            {
                oComponent.Name2 = oInVo.ComponentName;
            }

            return RespVoLogExt.genOk("添加零部件完成");
        }

    }
}