using swapilib.basic.io;
using swapilib.bu.app;
using swapilib.bu.assembly;
using swapilib.bu.feature;
using swapilib.bu.feature.cmd;
using swapilib.bu.feature.vo.feature.extrusion;
using swapilib.bu.file;
using swapilib.bu.file.cmd;
using swapilib.bu.file.vo;
using swapilib.bu.modeldoc;
using swapilib.bu.modeldoc.cmd;
using swapilib.bu.modeldoc.vo.select;
using swapilib.bu.modeldoc.vo.view;
using swapilib.bu.sketch;
using swapilib.bu.sketch.action;
using swapilib.bu.sketch.vo.draw.circle;
using swapilib.bu.sketch.vo.sketch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib
{
    public class swapipy
    {
        #region test

        public static string TestHello(string strName)
        {
            return "Hello," + strName;
        }

        public static RespVo TestRespVo()
        {
            return RespVo.genOk("sw version");
        }

        #endregion

        #region app

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strAppPath">app路径</param>
        /// <returns>RespVo</returns>
        public static RespVo Init(string strAppPath)
        {
            // 初始化Service
            SwBuAppService.getInstance().init(strAppPath);
            SwBuFileService.getInstance().init();
            SwBuModelDocService.getInstance().init();
            SwBuSketchService.getInstance().init();
            SwBuFeatureService.getInstance().init();
            SwBuAssemblyService.getInstance().init();

            return RespVo.genOk("swapipy init ok");
        }

        /// <summary>
        /// 连接SW
        /// </summary>
        /// <returns>RespVo</returns>
        public static RespVo ConnectSw()
        {
            return SwBuAppService.getInstance().connectSw();
        }

        #endregion

        #region file

        /// <summary>
        /// 新建工程
        /// </summary>
        /// <param name="oInVo">工程类型：NewDocInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo NewDoc(NewDocInVo oInVo)
        {
            return SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.NewDoc, oInVo);
        }

        /// <summary>
        /// 保存工程
        /// </summary>
        /// <param name="oInVo">SaveDocInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo SaveDoc(SaveDocInVo oInVo)
        {
            return SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.SaveDoc, oInVo);
        }

        /// <summary>
        /// 导出工程
        /// </summary>
        /// <param name="oInVo">ExportDocInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo ExportDoc(ExportDocInVo oInVo)
        {
            return SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.ExportDoc, oInVo);
        }

        #endregion

        #region modeldoc

        /// <summary>
        /// 清空选择对象列表
        /// </summary>
        /// <param name="oInVo">ClearSelectionInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo ClearSelection(ClearSelectionInVo oInVo)
        {
            return SwBuModelDocService.getInstance().executeCmdWithInVo(EnumSwModelDocCmdType.ClearSelection, oInVo);
        }

        /// <summary>
        /// 通过名称或位置选中对象
        /// </summary>
        /// <param name="oInVo">SelectByIDInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo SelectByID(SelectByIDInVo oInVo)
        {
            return SwBuModelDocService.getInstance().executeCmdWithInVo(EnumSwModelDocCmdType.SelectByID, oInVo);
        }

        /// <summary>
        /// 显示视图
        /// </summary>
        /// <param name="oInVo">ShowNamedViewInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo ShowNamedView(ShowNamedViewInVo oInVo)
        {
            return SwBuModelDocService.getInstance().executeCmdWithInVo(EnumSwModelDocCmdType.ShowNamedView, oInVo);
        }

        #endregion

        #region sketch

        /// <summary>
        /// 插入草图
        /// </summary>
        /// <param name="oInVo">InsertSketchInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo InsertSketch(InsertSketchInVo oInVo)
        {
            return SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.InsertSketch, oInVo);
        }

        /// <summary>
        /// 绘制半径圆
        /// </summary>
        /// <param name="oInVo">CreateCircleByRadiusInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo CreateCircleByRadius(CreateCircleByRadiusInVo oInVo)
        {
            return SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateCircleByRadius, oInVo);
        }

        #endregion

        #region feature

        /// <summary>
        /// 创建拉伸基体特征
        /// </summary>
        /// <param name="oInVo">FeatureExtrusionInVo</param>
        /// <returns>RespVo</returns>
        public static RespVo FeatureExtrusion(FeatureExtrusionInVo oInVo)
        {
            return SwBuFeatureService.getInstance().executeCmdWithInVo(EnumSwFeatureCmdType.FeatureExtrusion, oInVo);
        }

        #endregion
    }
}
