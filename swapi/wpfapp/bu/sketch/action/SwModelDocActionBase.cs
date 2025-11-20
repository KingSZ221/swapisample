using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.app;
using wpfapp.bu.cmd.action;
using wpfapp.bu.log;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 文档操作基类
    /// </summary>
    public class SwModelDocActionBase : SwCmdActionBase
    {
        #region Fields

        /// <summary>
        /// SwApp
        /// </summary>
        private ISwApplication _swApp = null;

        /// <summary>
        /// 当前操作文档
        /// </summary>
        private ModelDoc2 _curDoc = null;

        #endregion

        #region Construction

        public SwModelDocActionBase() : base()
        {
        }

        ~SwModelDocActionBase()
        {
            _swApp = null;
            _curDoc = null;
        }

        #endregion

        #region execute

        public override RespVo execute()
        {
            // 检查当前激活文档是否零件
            ModelDoc2 doc = null;
            RespVo oRespVo = priCheckPartDoc(ref doc);
            if (!oRespVo.ok)
            {
                return oRespVo;
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

            // 还原用户设置
            // 还原草图激活捕捉设置
            swApp.Sw.SetUserPreferenceToggle((int)swUserPreferenceToggle_e.swSketchInference, hasInference);

            return oRespVo;
        }

        protected virtual RespVo onExecute()
        {
            return RespVoLogExt.genError("未实现");
        }

        #endregion

        #region get

        protected ISwApplication swApp
        {
            get
            {
                if (_swApp == null)
                {
                    _swApp = SwBuAppService.getInstance().getSwApp();
                }
                return _swApp;
            }
        }

        protected ModelDoc2 curDoc
        {
            get
            {
                if (_curDoc == null)
                {
                    _curDoc = swApp.Sw.IActiveDoc2;
                }
                return _curDoc;
            }
        }

        protected ModelDocExtension curDocExt
        {
            get
            {
                if (curDoc != null)
                {
                    return curDoc.Extension;
                }
                return null;
            }
        }

        protected T actionInVo<T>()
        {
            if (curDoc != null)
            {
                return (T)CmdInVo;
            }
            return default(T);
        }

        #endregion

        #region 绘制前准备

        /// <summary>
        /// 检查当前激活文档是否零件
        /// </summary>
        /// <returns>RespVo</returns>
        protected RespVo priCheckPartDoc(ref ModelDoc2 doc)
        {
            if (swApp == null)
            {
                return RespVoLogExt.genError("未连接SolidWorks");
            }

            //获取当前打开的文档
            doc = curDoc;
            if (doc == null)
            {
                return RespVoLogExt.genError("没有打开的文档");
            }

            //防御文档不是零件
            if (doc.GetType() != (int)swDocumentTypes_e.swDocPART)
            {
                return RespVoLogExt.genError("当前打开的不是零件");
            }

            return RespVo.genOk();
        }

        #endregion
    }
}
