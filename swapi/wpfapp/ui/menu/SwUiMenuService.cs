using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpfapp.bu.app;
using wpfapp.bu.cmd;
using wpfapp.bu.cmd.cmdtype;
using wpfapp.bu.cmd.usecase.design;
using wpfapp.bu.cmd.usecase.excute;
using wpfapp.bu.feature;
using wpfapp.bu.feature.cmd;
using wpfapp.bu.file;
using wpfapp.bu.file.cmd;
using wpfapp.bu.log;
using wpfapp.bu.sketch;
using wpfapp.bu.sketch.action;
using wpfapp.bu.sketch.vo.draw.spline;
using wpfapp.bu.usecase.vo;
using wpfapp.bu.file.vo;
using wpfapp.ui.ai;
using wpfapp.ui.prop;
using wpfapp.utils.reflect;
using wpfapp.basic.io;
using wpfapp.bu.assembly;
using wpfapp.bu.modeldoc;

namespace wpfapp.ui.menu
{
    public class SwUiMenuService
    {
        #region Fields

        private static SwUiMenuService _instance = new SwUiMenuService();

        private MenuItem menuUseCase;

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwUiMenuService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwUiMenuService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init
        
        public void init(Menu mainMenu, ToolBarTray mainToolbar)
        {
            priCreateMenu4App(mainMenu);
            priCreateMenu4File(mainMenu);
            priCreateMenu4Sketch(mainMenu);
            priCreateMenu4Feature(mainMenu);
            priCreateMenu4Part(mainMenu);
            priCreateMenu4Assembly(mainMenu);
            priCreateMenu4UseCase(mainMenu);

            priCreateToolbar4App(mainToolbar);
            priCreateToolbar4UseCase(mainToolbar);
        }

        public void destroy()
        {

        }

        private void priCreateMenu4App(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "应用";
            mainMenu.Items.Add(menu);

            menu.Items.Add(priCreateMenuItem("连接SW", Button_Click_ConnectSw));
            menu.Items.Add(priCreateMenuItem("AI调用SW", Button_Click_AiInvokeSw));
        }

        private void priCreateMenu4File(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "文件";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4File(null, menu);
        }

        private void priCreateSubMenu4File(Menu menu1, MenuItem menu2)
        {
            MenuItem menuNew = priCreateMenuItem("新建", null);
            menuNew.Items.Add(priCreateMenuItem("新建零件", Button_Click_NewPart));
            menuNew.Items.Add(priCreateMenuItem("新建装配体", Button_Click_NewAssembly));
            menuNew.Items.Add(priCreateMenuItem("新建工程图", Button_Click_NewDrawing));

            MenuItem menuOpen = priCreateMenuItem("打开", null);
            menuOpen.Items.Add(priCreateMenuItem("打开零件", Button_Click_OpenPart));
            menuOpen.Items.Add(priCreateMenuItem("打开装配体", Button_Click_OpenAssembly));
            menuOpen.Items.Add(priCreateMenuItem("打开工程图", Button_Click_OpenDrawing));

            MenuItem menuSave = priCreateMenuItem("保存", null);
            menuSave.Items.Add(priCreateMenuItem("保存当前文档", Button_Click_SaveCurDoc));
            menuSave.Items.Add(priCreateMenuItem("另存当前文档", Button_Click_SaveAsCurDoc));

            MenuItem menuClose = priCreateMenuItem("关闭", null);
            menuClose.Items.Add(priCreateMenuItem("关闭当前文档", Button_Click_CloseCurDoc));

            MenuItem menuExport = priCreateMenuItem("导出", null);
            menuExport.Items.Add(priCreateMenuItem("导出Dxf", Button_Click_ExportDxf));
            menuExport.Items.Add(priCreateMenuItem("导出Svg", Button_Click_ExportSvg));
            menuExport.Items.Add(priCreateMenuItem("导出Igs", Button_Click_ExportIges));

            if (menu1 != null)
            {
                menu1.Items.Add(menuNew);
                menu1.Items.Add(menuOpen);
                menu1.Items.Add(menuSave);
                menu1.Items.Add(menuClose);
                menu1.Items.Add(menuExport);
            }
            else
            {
                menu2.Items.Add(menuNew);
                menu2.Items.Add(menuOpen);
                menu2.Items.Add(menuSave);
                menu2.Items.Add(menuClose);
                menu2.Items.Add(menuExport);
            }
        }

        private void priCreateMenu4ModelDoc(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "模型文档";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Moudle(menu, SwBuModelDocService.MoudleName);
        }

        private void priCreateMenu4Sketch(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "草图";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Moudle(menu, SwBuSketchService.MoudleName);
        }

        private void priCreateMenu4Feature(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "特征";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Moudle(menu, SwBuFeatureService.MoudleName);
        }

        private void priCreateMenu4Part(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "零件";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Part(null, menu);
        }

        private void priCreateMenu4Assembly(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "装配体";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Moudle(menu, SwBuAssemblyService.MoudleName);
        }

        private void priCreateMenu4UseCase(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "用例";
            mainMenu.Items.Add(menu);

            menuUseCase = menu;

            priCreateSubMenu4UseCase(menuUseCase);
        }

        internal void updateUseCaseSubMenu()
        {
            priCreateSubMenu4UseCase(menuUseCase);
        }

        private void priCreateSubMenu4UseCase(MenuItem menu1)
        {
            menu1.Items.Clear();

            Dictionary<string, MenuItem> subMenuGroups = new Dictionary<string, MenuItem>();
            foreach(SwUseCaseInfo oSwUseCaseInfo in SwUseCaseDesignService.getInstance().getAll())
            {
                string strGroup = oSwUseCaseInfo.Group;
                if (string.IsNullOrEmpty(strGroup))
                {
                    strGroup = "Default";
                }
                MenuItem subMenuGroup;
                subMenuGroups.TryGetValue(strGroup, out subMenuGroup);
                if(subMenuGroup == null)
                {
                    subMenuGroup = priCreateMenuItem(strGroup, null);
                    subMenuGroups[strGroup] = subMenuGroup;
                    menu1.Items.Add(subMenuGroup);
                }
                subMenuGroup.Items.Add(priCreateMenuItem(oSwUseCaseInfo.Name, Button_Click_ExcuteUseCase, oSwUseCaseInfo.Id));
            }
        }

        private void priCreateSubMenu4Moudle(MenuItem menu1, string strMoudleName)
        {
            menu1.Items.Clear();

            Dictionary<string, MenuItem> subMenuGroups = new Dictionary<string, MenuItem>();
            List<SwCmdType> cmdTypes = SwCmdTypeManager.getInstance().getCmdsByModule(strMoudleName);
            foreach (SwCmdType cmdType in cmdTypes)
            {
                if(cmdType.CmdTypeId == 0)
                {
                    continue;
                }
                string strGroup = cmdType.CmdGroupName;
                if (string.IsNullOrEmpty(strGroup))
                {
                    menu1.Items.Add(priCreateMenuItem(cmdType.CmdTypeName, Button_Click_CmdType, cmdType));
                }
                else
                {
                    MenuItem subMenuGroup;
                    subMenuGroups.TryGetValue(strGroup, out subMenuGroup);
                    if (subMenuGroup == null)
                    {
                        subMenuGroup = priCreateMenuItem(strGroup, null);
                        subMenuGroups[strGroup] = subMenuGroup;
                        menu1.Items.Add(subMenuGroup);
                    }
                    subMenuGroup.Items.Add(priCreateMenuItem(cmdType.CmdTypeName, Button_Click_CmdType, cmdType));
                }
                
            }
        }

        private void priCreateSubMenu4Part(Menu menu1, MenuItem menu2)
        {
            MenuItem menuPart= priCreateMenuItem("绘制零件", null);
            menuPart.Items.Add(priCreateMenuItem("绘制圆管", Button_Click_CreateCirclePipe));
            menuPart.Items.Add(priCreateMenuItem("绘制立方体", Button_Click_CreateCube)); 
            menuPart.Items.Add(priCreateMenuItem("绘制扶梯", Button_Click_CreateLadder));

            ItemCollection menuItems = (menu1 != null) ? menu1.Items : menu2.Items;
            menuItems.Add(menuPart);
        }

        private MenuItem priCreateMenuItem(string strHeader, Action<object, RoutedEventArgs> clickHandler = null, object tag = null)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = strHeader;
            if(tag != null)
            {
                menuItem.Tag = tag;
            }

            // 事件绑定
            if (clickHandler != null)
            {
                menuItem.Click += (sender, e) => clickHandler(sender, e);
            }

            return menuItem;
        }

        private void priCreateToolbar4App(ToolBarTray mainToolbar)
        {
            // 创建ToolBar
            ToolBar toolBar = new ToolBar();

            // 添加到ToolBarTray
            mainToolbar.ToolBars.Add(toolBar);

            // 设置ItemsPanelTemplate为WrapPanel
            var itemsPanelTemplate = new ItemsPanelTemplate();
            var wrapPanelFactory = new FrameworkElementFactory(typeof(WrapPanel));
            wrapPanelFactory.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            itemsPanelTemplate.VisualTree = wrapPanelFactory;
            toolBar.ItemsPanel = itemsPanelTemplate;

            // 添加按钮
            toolBar.Items.Add(priCreateToolBarBtn("连接SW", Button_Click_ConnectSw));
            toolBar.Items.Add(priCreateToolBarBtn("AI调用SW", Button_Click_AiInvokeSw));
        }

        private void priCreateToolbar4UseCase(ToolBarTray mainToolbar)
        {
            // 创建ToolBar
            ToolBar toolBar = new ToolBar();

            // 添加到ToolBarTray
            mainToolbar.ToolBars.Add(toolBar);

            // 设置ItemsPanelTemplate为WrapPanel
            var itemsPanelTemplate = new ItemsPanelTemplate();
            var wrapPanelFactory = new FrameworkElementFactory(typeof(WrapPanel));
            wrapPanelFactory.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            itemsPanelTemplate.VisualTree = wrapPanelFactory;
            toolBar.ItemsPanel = itemsPanelTemplate;

            // 添加按钮
            toolBar.Items.Add(priCreateToolBarBtn("用例设计", Button_Click_DesignUseCase)); 
        }
        
        private void priCreateToolbar4File(ToolBarTray mainToolbar)
        {
            // 创建ToolBar
            ToolBar toolBar = new ToolBar();

            // 添加到ToolBarTray
            mainToolbar.ToolBars.Add(toolBar);

            // 设置ItemsPanelTemplate为WrapPanel
            var itemsPanelTemplate = new ItemsPanelTemplate();
            var wrapPanelFactory = new FrameworkElementFactory(typeof(WrapPanel));
            //wrapPanelFactory.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            wrapPanelFactory.SetValue(FrameworkElement.WidthProperty, 100.0);
            itemsPanelTemplate.VisualTree = wrapPanelFactory;
            toolBar.ItemsPanel = itemsPanelTemplate;

            // 添加按钮
            Menu menu = new Menu();
            toolBar.Items.Add(menu);
            priCreateSubMenu4File(menu, null);

            
        }

        private Button priCreateToolBarBtn(string strHeader, Action<object, RoutedEventArgs> clickHandler = null)
        {
            Button btn = new Button();
            btn.Content = strHeader;

            // 事件绑定
            if (clickHandler != null)
            {
                btn.Click += (sender, e) => clickHandler(sender, e);
            }

            return btn;
        }

        #endregion

        #region 应用操作

        /// <summary>
        /// 连接SW
        /// </summary>
        private void Button_Click_ConnectSw(object sender, RoutedEventArgs e)
        {
            SwBuAppService.getInstance().connectSw();
        }

        /// <summary>
        /// AI调用SW
        /// </summary>
        private void Button_Click_AiInvokeSw(object sender, RoutedEventArgs e)
        {
            SwAiWrapService.getInstance().CreateLadder();
        }

        #endregion

        #region 用例操作

        private void Button_Click_DesignUseCase(object sender, RoutedEventArgs e)
        {
            SwUseCaseDesignService.getInstance().showUseCaseListDialog();
        }

        private void Button_Click_ExcuteUseCase(object sender, RoutedEventArgs arg2)
        {
            if (sender is MenuItem menuItem && menuItem.Tag is string useCaseId)
            {
                SwUseCaseExcuteService.getInstance().excuteUseCase(useCaseId);
            }
        }

        #endregion

        #region 文档操作

        /// <summary>
        /// 新建零件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_NewPart(object sender, RoutedEventArgs e)
        {
            NewDocInVo oNewDocInVo = new NewDocInVo();
            oNewDocInVo.DocType = 1;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.NewDoc, oNewDocInVo);
        }

        /// <summary>
        /// 新建装配体
        /// </summary>
        private void Button_Click_NewAssembly(object sender, RoutedEventArgs e)
        {
            NewDocInVo oNewDocInVo = new NewDocInVo();
            oNewDocInVo.DocType = 2;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.NewDoc, oNewDocInVo);
        }

        /// <summary>
        /// 新建工程图
        /// </summary>
        private void Button_Click_NewDrawing(object sender, RoutedEventArgs e)
        {
            NewDocInVo oNewDocInVo = new NewDocInVo();
            oNewDocInVo.DocType = 3;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.NewDoc, oNewDocInVo);
        }

        /// <summary>
        /// 打开零件
        /// </summary>
        private void Button_Click_OpenPart(object sender, RoutedEventArgs e)
        {
            OpenDocInVo oOpenDocInVo = OpenDocInVo.genTestOpenFileInVo(1);
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.OpenDoc, oOpenDocInVo);
        }

        /// <summary>
        /// 打开装配体
        /// </summary>
        private void Button_Click_OpenAssembly(object sender, RoutedEventArgs e)
        {
            OpenDocInVo oOpenDocInVo = OpenDocInVo.genTestOpenFileInVo(2);
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.OpenDoc, oOpenDocInVo);
        }

        /// <summary>
        /// 打开工程图
        /// </summary>
        private void Button_Click_OpenDrawing(object sender, RoutedEventArgs e)
        {
            OpenDocInVo oOpenDocInVo = OpenDocInVo.genTestOpenFileInVo(3);
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.OpenDoc, oOpenDocInVo);
        }

        /// <summary>
        /// 保存当前文档
        /// </summary>
        private void Button_Click_SaveCurDoc(object sender, RoutedEventArgs e)
        {
            SaveDocInVo oSaveDocInVo = new SaveDocInVo();
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.SaveDoc, oSaveDocInVo);
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        private void Button_Click_SaveAsCurDoc(object sender, RoutedEventArgs e)
        {
            SaveAsDocInVo oSaveAsDocInVo = new SaveAsDocInVo();
            oSaveAsDocInVo.SaveAsDocTitle = "SaveAsSample";
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.SaveAsDoc, oSaveAsDocInVo);
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        private void Button_Click_CloseCurDoc(object sender, RoutedEventArgs e)
        {
            CloseDocInVo oCloseDocInVo = new CloseDocInVo();
            oCloseDocInVo.DocTitle = "";
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.CloseDoc, oCloseDocInVo);
        }

        /// <summary>
        /// 导出dxf
        /// </summary>
        private void Button_Click_ExportDxf(object sender, RoutedEventArgs e)
        {
            ExportDocInVo oExportDocInVo = new ExportDocInVo();
            oExportDocInVo.ExportFileType = 1;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.ExportDoc, oExportDocInVo);
        }

        /// <summary>
        /// 导出svg
        /// </summary>
        private void Button_Click_ExportSvg(object sender, RoutedEventArgs e)
        {
            ExportDocInVo oExportDocInVo = new ExportDocInVo();
            oExportDocInVo.ExportFileType = 2;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.ExportDoc, oExportDocInVo);
        }

        /// <summary>
        /// 导出iges
        /// </summary>
        private void Button_Click_ExportIges(object sender, RoutedEventArgs e)
        {
            ExportDocInVo oExportDocInVo = new ExportDocInVo();
            oExportDocInVo.ExportFileType = 3;
            priExecuteCmdWithInVo(SwBuFileService.MoudleName, (int)EnumSwDocCmdType.ExportDoc, oExportDocInVo);
        }

        #endregion

        #region 草图操作和特征操作

        private void Button_Click_CmdType(object sender, RoutedEventArgs arg2)
        {
            if (sender is MenuItem menuItem && menuItem.Tag is SwCmdType cmdType)
            {
                // 特殊命令处理-绘制B样条曲线
                if (cmdType.CmdModule == SwBuSketchService.MoudleName && cmdType.CmdTypeId == (int)EnumSwSketchCmdType.CreateSpline)
                {
                    priExecuteCmdWithInVo(SwBuSketchService.MoudleName, (int)EnumSwSketchCmdType.CreateSpline, CreateSplineInVo.Default());
                }
                else
                {
                    // 通用命令处理
                    priExecuteCmdAndConfigInVo(cmdType.CmdModule, cmdType.CmdTypeId);
                }
            }
        }

        #endregion

        #region 零件操作

        /// <summary>
        /// 绘制圆管
        /// </summary>
        private void Button_Click_CreateCirclePipe(object sender, RoutedEventArgs e)
        {
            priExecuteSketchCmdAndConfigInVo(EnumSwSketchCmdType.CreateCirclePipe);
        }

        /// <summary>
        /// 绘制立方体
        /// </summary>
        private void Button_Click_CreateCube(object sender, RoutedEventArgs e)
        {
            priExecuteSketchCmdAndConfigInVo(EnumSwSketchCmdType.CreateCube);
        }

        /// <summary>
        /// 绘制扶梯
        /// </summary>
        private void Button_Click_CreateLadder(object sender, RoutedEventArgs e)
        {
            priExecuteSketchCmdAndConfigInVo(EnumSwSketchCmdType.CreateLadder);
        }

        #endregion

        #region 执行命令

        /// <summary>
        /// 执行文档命令，弹出命令参数设置对话框
        /// </summary>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <returns>RespVo</returns>
        private RespVo priExecuteDocCmdAndConfigInVo(EnumSwDocCmdType cmdTypeId)
        {
            return priExecuteCmdAndConfigInVo(SwBuFileService.MoudleName, (int)cmdTypeId);
        }

        /// <summary>
        /// 执行草图命令，弹出命令参数设置对话框
        /// </summary>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <returns>RespVo</returns>
        private RespVo priExecuteSketchCmdAndConfigInVo(EnumSwSketchCmdType cmdTypeId)
        {
            return priExecuteCmdAndConfigInVo(SwBuSketchService.MoudleName, (int)cmdTypeId);
        }

        /// <summary>
        /// 执行特征命令，弹出命令参数设置对话框
        /// </summary>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <returns>RespVo</returns>
        private RespVo priExecuteFeatureCmdAndConfigInVo(EnumSwFeatureCmdType cmdTypeId)
        {
            return priExecuteCmdAndConfigInVo(SwBuFeatureService.MoudleName, (int)cmdTypeId);
        }

        /// <summary>
        /// 执行命令，弹出命令参数设置对话框
        /// </summary>
        /// <param name="cmdModule">命令模块</param>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <returns>RespVo</returns>
        private RespVo priExecuteCmdAndConfigInVo(string moduleName, int cmdTypeId)
        {
            // 获取命令类型
            SwCmdType cmdType = SwCmdTypeManager.getInstance().getByTypeId(moduleName, cmdTypeId);
            if (cmdType == null)
            {
                return RespVoLogExt.genError($"未找到命令: {SwBuSketchService.MoudleName} {cmdTypeId}");
            }

            // 弹出命令参数设置对话框
            object cmdInVo = null;
            if (cmdType.ActionInVoType != null)
            {
                cmdInVo = Activator.CreateInstance(cmdType.ActionInVoType);
                if (!SwUiPropService.getInstance().showPropObjDlg(cmdType.CmdTypeName, "请输入命令参数:", cmdInVo))
                {
                    return RespVoLogExt.genOk($"命令取消, {cmdType.CmdTypeName}");
                }
            }

            // 执行命令
            return SwBuCmdService.getInstance().executeCmdWithInVo(cmdType, cmdInVo);
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="cmdModule">命令模块</param>
        /// <param name="cmdTypeId">命令类型ID</param>
        /// <returns>RespVo</returns>
        private RespVo priExecuteCmdWithInVo(string moduleName, int cmdTypeId, object cmdInVo)
        {
            // 执行命令
            return SwBuCmdService.getInstance().executeCmdWithInVo(moduleName, cmdTypeId, cmdInVo);
        }

        #endregion
    }
}
