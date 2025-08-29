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
using wpfapp.bu.file;
using wpfapp.bu.log;
using wpfapp.bu.sketch;
using wpfapp.bu.sketch.action;
using wpfapp.bu.vo;
using wpfapp.ui.prop;
using wpfapp.utils.reflect;

namespace wpfapp.ui.menu
{
    public class SwUiMenuService
    {
        #region Fields

        private static SwUiMenuService _instance = new SwUiMenuService();

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

            priCreateToolbar4App(mainToolbar);
            priCreateToolbar4File(mainToolbar);
            priCreateToolbar4Sketch(mainToolbar);
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

        private void priCreateMenu4Sketch(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "草图";
            mainMenu.Items.Add(menu);

            priCreateSubMenu4Sketch(null, menu);
        }

        private void priCreateSubMenu4Sketch(Menu menu1, MenuItem menu2)
        {
            MenuItem menuEdit = priCreateMenuItem("绘制草图", null);
            menuEdit.Items.Add(priCreateMenuItem("绘制草图", Button_Click_EditSketch));
            menuEdit.Items.Add(priCreateMenuItem("退出草图", Button_Click_ExitSketch));

            MenuItem menuLine = priCreateMenuItem("绘制直线", null);
            menuLine.Items.Add(priCreateMenuItem("绘制直线", Button_Click_CreateLine));
            menuLine.Items.Add(priCreateMenuItem("绘制中心直线", Button_Click_CreateCenterLine));

            MenuItem menuRect = priCreateMenuItem("绘制矩形", null);
            menuRect.Items.Add(priCreateMenuItem("绘制边角矩形", Button_Click_CreateCornerRectangle));
            menuRect.Items.Add(priCreateMenuItem("绘制中心矩形", Button_Click_CreateCenterRectangle));
            menuRect.Items.Add(priCreateMenuItem("绘制3点边角矩形", Button_Click_Create3PointCornerRectangle));
            menuRect.Items.Add(priCreateMenuItem("绘制3点中心矩形", Button_Click_Create3PointCenterRectangle));
            menuRect.Items.Add(priCreateMenuItem("绘制平行四边形", Button_Click_CreateParallelogram));

            MenuItem menuSlot = priCreateMenuItem("绘制槽口", null);
            menuSlot.Items.Add(priCreateMenuItem("绘制直槽口", Button_Click_CreateSketchSlot_line));
            menuSlot.Items.Add(priCreateMenuItem("绘制中心点直槽口", Button_Click_CreateSketchSlot_center_line));
            menuSlot.Items.Add(priCreateMenuItem("绘制三点圆弧槽口", Button_Click_CreateSketchSlot_3pointarc));
            menuSlot.Items.Add(priCreateMenuItem("绘制中心点圆弧槽口", Button_Click_CreateSketchSlot_arc));

            MenuItem menuCircle = priCreateMenuItem("绘制圆", null);
            menuCircle.Items.Add(priCreateMenuItem("绘制圆", Button_Click_CreateCircle));
            menuCircle.Items.Add(priCreateMenuItem("绘制周边圆", Button_Click_PerimeterCircle));

            MenuItem menuArc = priCreateMenuItem("绘制圆弧", null);
            menuArc.Items.Add(priCreateMenuItem("绘制圆心/起/终点画弧", Button_Click_CreateArc));
            menuArc.Items.Add(priCreateMenuItem("绘制切线弧", Button_Click_CreateTangentArc));
            menuArc.Items.Add(priCreateMenuItem("绘制3点圆弧", Button_Click_Create3PointArc));

            MenuItem menuPipe = priCreateMenuItem("绘制管材", null);
            menuPipe.Items.Add(priCreateMenuItem("绘制圆管", Button_Click_CreateCirclePipe));

            if (menu1 != null)
            {
                menu1.Items.Add(menuEdit);
                menu1.Items.Add(menuLine);
                menu1.Items.Add(menuRect);
                menu1.Items.Add(menuSlot);
                menu1.Items.Add(menuCircle);
                menu1.Items.Add(menuArc);
                menu1.Items.Add(menuPipe);
            }
            else
            {
                menu2.Items.Add(menuEdit);
                menu2.Items.Add(menuLine);
                menu2.Items.Add(menuRect);
                menu2.Items.Add(menuSlot);
                menu2.Items.Add(menuCircle);
                menu2.Items.Add(menuArc);
                menu2.Items.Add(menuPipe);
            }
        }

        private MenuItem priCreateMenuItem(string strHeader, Action<object, RoutedEventArgs> clickHandler = null)
        {
            MenuItem menuItem = new MenuItem();
            menuItem.Header = strHeader;

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
        private void priCreateToolbar4Sketch(ToolBarTray mainToolbar)
        {
            // 创建ToolBar
            ToolBar toolBar = new ToolBar();

            // 添加到ToolBarTray
            mainToolbar.ToolBars.Add(toolBar);

            // 添加按钮
            Menu menu = new Menu();
            toolBar.Items.Add(menu);
            priCreateSubMenu4Sketch(menu, null); 
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

        #endregion

        #region 文档操作

        /// <summary>
        /// 新建零件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_NewPart(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplatePart);
        }

        /// <summary>
        /// 新建装配体
        /// </summary>
        private void Button_Click_NewAssembly(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplateAssembly);
        }

        /// <summary>
        /// 新建工程图
        /// </summary>
        private void Button_Click_NewDrawing(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplateDrawing);
        }

        private void newDoc(swUserPreferenceStringValue_e docType)
        {
            SwBuFileService.getInstance().newDoc(docType);

        }

        /// <summary>
        /// 打开零件
        /// </summary>
        private void Button_Click_OpenPart(object sender, RoutedEventArgs e)
        {
            openDoc("零件测试1.SLDPRT", swDocumentTypes_e.swDocPART);
        }

        /// <summary>
        /// 打开装配体
        /// </summary>
        private void Button_Click_OpenAssembly(object sender, RoutedEventArgs e)
        {
            openDoc("装配体测试1.SLDASM", swDocumentTypes_e.swDocASSEMBLY);
        }

        /// <summary>
        /// 打开工程图
        /// </summary>
        private void Button_Click_OpenDrawing(object sender, RoutedEventArgs e)
        {
            openDoc("工程图测试1.SLDDRW", swDocumentTypes_e.swDocDRAWING);
        }

        private void openDoc(string strDocFileName, swDocumentTypes_e docType)
        {
            SwBuFileService.getInstance().openDoc(strDocFileName, docType);
        }

        /// <summary>
        /// 保存当前文档
        /// </summary>
        private void Button_Click_SaveCurDoc(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().saveCurDoc();
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        private void Button_Click_SaveAsCurDoc(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().saveAsCurDoc(SwBuFileService.getInstance().getCurDocPath());
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        private void Button_Click_CloseCurDoc(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().closeCurDoc();
        }

        /// <summary>
        /// 导出dxf
        /// </summary>
        private void Button_Click_ExportDxf(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().exportDxf();
        }

        /// <summary>
        /// 导出svg
        /// </summary>
        private void Button_Click_ExportSvg(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().exportSvg();
        }

        /// <summary>
        /// 导出iges
        /// </summary>
        private void Button_Click_ExportIges(object sender, RoutedEventArgs e)
        {
            SwBuFileService.getInstance().exportIges();
        }

        #endregion

        #region 草图操作

        #region 绘制草图

        /// <summary>
        /// 草图绘制
        /// </summary>
        private void Button_Click_EditSketch(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.EditSketch);
        }

        /// <summary>
        /// 退出草图
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void Button_Click_ExitSketch(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.ExitSketch);
        }

        #endregion

        #region 绘制直线

        /// <summary>
        /// 绘制直线
        /// </summary>
        private void Button_Click_CreateLine(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateLine);
        }

        /// <summary>
        /// 绘制中心直线
        /// </summary>
        private void Button_Click_CreateCenterLine(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateCenterLine);
        }

        #endregion

        #region 绘制矩形

        /// <summary>
        /// 绘制边角矩形
        /// </summary>
        private void Button_Click_CreateCornerRectangle(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateCornerRectangle);
        }

        /// <summary>
        /// 绘制中心矩形
        /// </summary>
        private void Button_Click_CreateCenterRectangle(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateCenterRectangle);
        }

        /// <summary>
        /// 绘制3点边角矩形
        /// </summary>
        private void Button_Click_Create3PointCornerRectangle(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.Create3PointCornerRectangle);
        }

        /// <summary>
        /// 绘制3点中心矩形
        /// </summary>
        private void Button_Click_Create3PointCenterRectangle(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.Create3PointCenterRectangle);
        }

        /// <summary>
        /// 绘制平行四边形
        /// </summary>
        private void Button_Click_CreateParallelogram(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateParallelogram);
        }

        #endregion

        #region 绘制槽口

        /// <summary>
        /// 绘制直槽口
        /// </summary>
        private void Button_Click_CreateSketchSlot_line(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateSketchSlot_line);
        }

        /// <summary>
        /// 绘制中心点直槽口
        /// </summary>
        private void Button_Click_CreateSketchSlot_center_line(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateSketchSlot_center_line);
        }

        /// <summary>
        /// 绘制三点圆弧槽口
        /// </summary>
        private void Button_Click_CreateSketchSlot_3pointarc(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateSketchSlot_3pointarc);
        }

        /// <summary>
        /// 绘制中心点圆弧槽口
        /// </summary>
        private void Button_Click_CreateSketchSlot_arc(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateSketchSlot_arc);
        }
        #endregion

        #region 绘制圆

        /// <summary>
        /// 绘制圆
        /// </summary>
        private void Button_Click_CreateCircle(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateCircle);
        }

        /// <summary>
        /// 绘制周边圆
        /// </summary>
        private void Button_Click_PerimeterCircle(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.PerimeterCircle);
        }

        #endregion

        #region 绘制圆弧

        /// <summary>
        /// 绘制圆心/起/终点画弧
        /// </summary>
        private void Button_Click_CreateArc(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateArc);
        }

        /// <summary>
        /// 绘制切线弧
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private void Button_Click_CreateTangentArc(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateTangentArc);
        }

        /// <summary>
        /// 绘制3点圆弧
        /// </summary>
        private void Button_Click_Create3PointArc(object arg1, RoutedEventArgs arg2)
        {
            priExecuteSketchActon(EnumSwSketchActionType.Create3PointArc);
        }

        #endregion

        /// <summary>
        /// 绘制圆管
        /// </summary>
        private void Button_Click_CreateCirclePipe(object sender, RoutedEventArgs e)
        {
            priExecuteSketchActon(EnumSwSketchActionType.CreateCirclePipe);
        }

        private RespVo priExecuteSketchActon(EnumSwSketchActionType actionType)
        {
            FieldInfo field = actionType.GetType().GetField(actionType.ToString());
            SwSketchActionAttribute attribute = field.GetCustomAttribute<SwSketchActionAttribute>();
            string strActionName = attribute.ActionName;
            object actionInVo = Activator.CreateInstance(attribute.ActionType);
            if (SwUiPropService.getInstance().showPropObjDlg(strActionName, actionInVo))
            {
                return SwBuSketchService.getInstance().executeSketchAction(actionType, actionInVo);
            }
            else
            {
                return RespVoLogExt.genOk($"绘制草图操作取消, {strActionName}");
            }
        }

        #endregion
    }
}
