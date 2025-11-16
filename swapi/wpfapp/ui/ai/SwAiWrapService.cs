using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wpfapp.bu.app;
using wpfapp.bu.file;
using wpfapp.bu.file.cmd;
using wpfapp.bu.file.vo;
using wpfapp.bu.log;
using wpfapp.bu.sketch;
using wpfapp.bu.sketch.action;
using wpfapp.bu.sketch.vo.compose.ladder;
using wpfapp.basic.io;
using wpfapp.ui.ai.ladder;

namespace wpfapp.ui.ai
{
    class SwAiWrapService
    {
        #region Fields

        private static SwAiWrapService _instance = new SwAiWrapService();

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwAiWrapService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwAiWrapService getInstance()
        {
            return _instance;
        }

        #endregion

        #region 创建扶梯

        public void CreateLadder()
        {
            CreateLadderDialog swAiWrapDlg = new CreateLadderDialog();
            swAiWrapDlg.Owner = SwBuAppService.getMainWindow();
            bool? bResult = swAiWrapDlg.ShowDialog();

            if (bResult == true)
            {
                SwBuLogService.getInstance().Info("");
                string strCmd = $"用户需求: {swAiWrapDlg.txtContent.Text}";
                SwBuLogService.getInstance().Info(strCmd);

                SwBuLogService.getInstance().Info("AI 分解需求中...");

                SwBuLogService.getInstance().Info("AI 调用SW中...");

                Task.Delay(1000); // 短暂延迟，让UI更新

                // 用户点击确定, 调用SW
                // 1.连接SW
                SwBuAppService.getInstance().connectSw();

                // 2.创建零件
                NewDocInVo oInVo = new NewDocInVo();
                oInVo.DocType = 1;
                SwBuFileService.getInstance().executeCmdWithInVo(EnumSwDocCmdType.NewDoc, oInVo);

                // 3.绘制图形
                SwBuSketchService.getInstance().executeCmdWithInVo(EnumSwSketchCmdType.CreateLadder, new CreateLadderInVo());

                SwBuLogService.getInstance().Info("AI 调用SW完成");
                SwBuLogService.getInstance().Info("");
            }
        }

        #endregion
    }
}
