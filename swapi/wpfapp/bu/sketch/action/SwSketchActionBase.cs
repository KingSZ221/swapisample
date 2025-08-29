using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;
using wpfapp.bu.log;
using wpfapp.bu.vo;
using Xarial.XCad.SolidWorks;

namespace wpfapp.bu.sketch.action
{
    /// <summary>
    /// 绘制操作基类
    /// </summary>
    public class SwSketchActionBase
    {
        #region Fields

        /// <summary>
        /// 操作参数
        /// </summary>
        private object _actionInVo = null;

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

        public SwSketchActionBase(object oInVo)
        {
            _actionInVo = oInVo;
        }

        ~SwSketchActionBase()
        {
            _swApp = null;
            _curDoc = null;
        }

        #endregion

        public virtual RespVo execute()
        {
            // 检查当前激活文档是否零件
            ModelDoc2 doc = null;
            RespVo oRespVo = priCheckPartDoc(ref doc);
            if (!oRespVo.ok)
            {
                return oRespVo;
            }

            // 选中基准面
            oRespVo = priSelectRefPlane(doc);
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

        #region get

        #region app

        protected ISwApplication swApp
        {
            get 
            { 
                if(_swApp == null)
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

        protected T actionInVo<T>()
        {
            if (_curDoc != null)
            {
                return (T)_actionInVo;
            }
            return default(T);
        }

        #endregion

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
            doc = swApp.Sw.IActiveDoc2;
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

        /// <summary>
        /// 选中基准面
        /// </summary>
        /// <param name="doc">文档</param>
        /// <returns></returns>
        protected RespVo priSelectRefPlane(ModelDoc2 doc, string refPlaneName = "")
        {
            string refPlaneFeatTypeName = "RefPlane";
            IFeature refPlaneFeature = null;
            var feat = doc.FirstFeature() as IFeature;
            while (feat != null)
            {
                var strTypeName = feat.GetTypeName2();
                var strFeatName = feat.Name;
                if (strTypeName == refPlaneFeatTypeName)
                {
                    // 如果未指定基准面名称，则返回第1个基准面
                    if (string.IsNullOrEmpty(refPlaneName))
                    {
                        refPlaneFeature = feat;
                        break;
                    }
                    else
                    {
                        if (refPlaneName == strFeatName)
                        {
                            refPlaneFeature = feat;
                            break;
                        }
                    }
                }
                feat = feat.GetNextFeature() as IFeature;
            }

            if (refPlaneFeature == null)
            {
                return RespVoLogExt.genError($"未找到基准面: {refPlaneName}");
            }

            //选中这个基准面
            refPlaneFeature.Select2(false, 0);

            return RespVo.genOk();
        }

        #endregion
    }
}
