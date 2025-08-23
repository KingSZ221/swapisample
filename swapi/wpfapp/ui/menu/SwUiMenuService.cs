using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using wpfapp.bu.app;
using wpfapp.bu.file;
using wpfapp.bu.sketch;
using wpfapp.bu.vo;
using wpfapp.ui.prop;

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

            menu.Items.Add(priCreateMenuItem("新建零件", Button_Click_NewPart));
            menu.Items.Add(priCreateMenuItem("新建装配体", Button_Click_NewAssembly));
            menu.Items.Add(priCreateMenuItem("新建工程图", Button_Click_NewDrawing));

            menu.Items.Add(new Separator());

            menu.Items.Add(priCreateMenuItem("打开零件", Button_Click_OpenPart));
            menu.Items.Add(priCreateMenuItem("打开装配体", Button_Click_OpenAssembly));
            menu.Items.Add(priCreateMenuItem("打开工程图", Button_Click_OpenDrawing));

            menu.Items.Add(new Separator());

            menu.Items.Add(priCreateMenuItem("保存当前文档", Button_Click_SaveCurDoc));
            menu.Items.Add(priCreateMenuItem("另存当前文档", Button_Click_SaveAsCurDoc));

            menu.Items.Add(new Separator());

            menu.Items.Add(priCreateMenuItem("关闭当前文档", Button_Click_CloseCurDoc));

            menu.Items.Add(new Separator());

            menu.Items.Add(priCreateMenuItem("导出Dxf", Button_Click_ExportDxf));
            menu.Items.Add(priCreateMenuItem("导出Svg", Button_Click_ExportSvg));
            menu.Items.Add(priCreateMenuItem("导出Igs", Button_Click_ExportIges));
        }

        private void priCreateMenu4Sketch(Menu mainMenu)
        {
            MenuItem menu = new MenuItem();
            menu.Header = "草图";
            mainMenu.Items.Add(menu);

            menu.Items.Add(priCreateMenuItem("创建圆管", Button_Click_CreateCirclePipe));
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

            // 设置ItemsPanelTemplate为WrapPanel
            var itemsPanelTemplate = new ItemsPanelTemplate();
            var wrapPanelFactory = new FrameworkElementFactory(typeof(WrapPanel));
            //wrapPanelFactory.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
            wrapPanelFactory.SetValue(FrameworkElement.WidthProperty, 100.0);
            itemsPanelTemplate.VisualTree = wrapPanelFactory;
            toolBar.ItemsPanel = itemsPanelTemplate;

            // 添加按钮
            toolBar.Items.Add(priCreateToolBarBtn("新建零件", Button_Click_NewPart));
            toolBar.Items.Add(priCreateToolBarBtn("新建装配体", Button_Click_NewAssembly));
            toolBar.Items.Add(priCreateToolBarBtn("新建工程图", Button_Click_NewDrawing));

            toolBar.Items.Add(new Separator());

            toolBar.Items.Add(priCreateToolBarBtn("打开零件", Button_Click_OpenPart));
            toolBar.Items.Add(priCreateToolBarBtn("打开装配体", Button_Click_OpenAssembly));
            toolBar.Items.Add(priCreateToolBarBtn("打开工程图", Button_Click_OpenDrawing));

            toolBar.Items.Add(new Separator());

            toolBar.Items.Add(priCreateToolBarBtn("保存当前文档", Button_Click_SaveCurDoc));
            toolBar.Items.Add(priCreateToolBarBtn("另存当前文档", Button_Click_SaveAsCurDoc));

            toolBar.Items.Add(new Separator());

            toolBar.Items.Add(priCreateToolBarBtn("关闭当前文档", Button_Click_CloseCurDoc));

            toolBar.Items.Add(new Separator());

            toolBar.Items.Add(priCreateToolBarBtn("导出Dxf", Button_Click_ExportDxf));
            toolBar.Items.Add(priCreateToolBarBtn("导出Svg", Button_Click_ExportSvg));
            toolBar.Items.Add(priCreateToolBarBtn("导出Igs", Button_Click_ExportIges));

            // 添加到ToolBarTray
            mainToolbar.ToolBars.Add(toolBar);
        }
        private void priCreateToolbar4Sketch(ToolBarTray mainToolbar)
        {
            ToolBar toolBar = new ToolBar();
            mainToolbar.ToolBars.Add(toolBar);

            toolBar.Items.Add(priCreateToolBarBtn("创建圆管", Button_Click_CreateCirclePipe));
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

        /// <summary>
        /// 创建圆管
        /// </summary>
        private void Button_Click_CreateCirclePipe(object sender, RoutedEventArgs e)
        {
            //新建一个草图并且绘制一个圆管
            NewCirclePipeInVo oCreateCirclePipeInVo = new NewCirclePipeInVo();
            if(SwUiPropService.getInstance().showPropObjDlg("创建圆管", oCreateCirclePipeInVo))
            {
                SwBuSketchService.getInstance().createCirclePipe(oCreateCirclePipeInVo);
            }
        }

        #endregion
    }
}
