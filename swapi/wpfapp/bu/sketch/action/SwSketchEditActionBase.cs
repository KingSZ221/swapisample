using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.log;
using wpfapp.bu.sketch.vo;
using wpfapp.bu.vo;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 草图绘制操作基类
    /// </summary>
    public class SwSketchEditActionBase : SwSketchActionBase
    {
        #region Fields
        #endregion

        #region Construction

        public SwSketchEditActionBase(object oInVo) : base(oInVo)
        {

        }

        #endregion


        public override RespVo execute()
        {
            // 检查当前激活文档是否零件
            ModelDoc2 swModelDoc = null;
            RespVo oRespVo = priCheckPartDoc(ref swModelDoc);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 获取扩展文档
            var swModelDocExt = swModelDoc.Extension;
            // 获取草图管理器
            var skeMgr = curDoc.SketchManager;

            // 获取绘制参数
            SketchEditInVoBase oInVo = this.actionInVo<SketchEditInVoBase>();
            if (string.IsNullOrEmpty(oInVo.SketchName))
            {
                //如果草图名称为空，则在当前选中的草图中绘制;
                //如果当前未选中草图，则以前视基准面创建草图;
                if(skeMgr.ActiveSketch == null)
                {
                    if (!swModelDocExt.SelectByID2("前视基准面", "PLANE", 0, 0, 0, false, 0, null, 0))
                    {
                        return RespVoLogExt.genOk("新建草图失败");
                    }

                    // 在这个基准面上插入一个草图，进入编辑草图模式
                    skeMgr.InsertSketch(true);
                }
            }
            else
            {
                if (skeMgr.ActiveSketch != null)
                {
                    // 退出编辑草图模式
                    skeMgr.InsertSketch(true);
                }

                // 如果草图名称不为空，则打开该草图进行绘制
                if (!swModelDocExt.SelectByID2(oInVo.SketchName, "SKETCH", 0, 0, 0, false, 0, null, 0))
                {
                    return RespVoLogExt.genOk($"草图不存在: {oInVo.SketchName}");
                }

                // 在这个基准面上插入一个草图，进入编辑草图模式
                skeMgr.InsertSketch(true);
            }

            // 获取用户设置
            // 先获取草图激活捕捉设置
            var hasInference = swApp.Sw.GetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference);

            // 修改用户设置
            if (hasInference)
            {
                // 用户已经打开了激活捕捉功能，则先关闭激活捕获
                swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, false);
            }

            // 执行绘制操作
            try
            {
                oRespVo = onExecute();
            }
            catch (Exception ex)
            {
                oRespVo = RespVoLogExt.genException(ex, "操作发送异常");
            }

            // 显示绘制图形
            swModelDoc.ViewZoomToSelection();

            // 还原用户设置
            // 还原草图激活捕捉设置
            swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, hasInference);

            if(oInVo.ExitEdit)
            {
                // 退出编辑草图模式
                skeMgr.InsertSketch(true);
            }

            return oRespVo;
        }
    }
}
