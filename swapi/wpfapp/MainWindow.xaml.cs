using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Xarial.XCad.SolidWorks;
using SolidWorks.Interop.swconst;
using System.IO;
using SolidWorks.Interop.sldworks;
using wpfapp.bu;
using wpfapp.bu.vo;
using Microsoft.Owin.Hosting;
using wpfapp.nbi_web;
using System.Configuration;

namespace wpfapp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private IDisposable _webApp;
        private static string WebApiBaseUrl = System.Configuration.ConfigurationManager.AppSettings["WebApiBaseUrl"];

        //private ISwApplication _swApp = null;

        public MainWindow()
        {
            InitializeComponent();

            StartWebHost();
        }

        private void StartWebHost()
        {
            try
            {
                _webApp = WebApp.Start<Startup>(url: WebApiBaseUrl);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            StopWebHost();
        }

        private void StopWebHost()
        {
            _webApp?.Dispose();
            _webApp = null;
        }

        /// <summary>
        /// 连接SW
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().connectSw();
            msgBox.Text = oRespVo.msg;

        }

        /// <summary>
        /// 新建零件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplatePart);
        }

        /// <summary>
        /// 新建装配体
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplateAssembly);
        }

        /// <summary>
        /// 新建工程图
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            newDoc(swUserPreferenceStringValue_e.swDefaultTemplateDrawing);
        }

        private void newDoc(swUserPreferenceStringValue_e docType)
        {
            RespVo oRespVo = SwBuAppService.getInstance().newDoc(docType);
            if (!oRespVo.ok)
            {
                MessageBox.Show(oRespVo.msg);
            }

        }

        /// <summary>
        /// 打开零件
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            openDoc("零件测试1.SLDPRT", swDocumentTypes_e.swDocPART);
        }

        /// <summary>
        /// 打开装配体
        /// </summary>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            openDoc("装配体测试1.SLDASM", swDocumentTypes_e.swDocASSEMBLY);
        }

        /// <summary>
        /// 打开工程图
        /// </summary>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            openDoc("工程图测试1.SLDDRW", swDocumentTypes_e.swDocDRAWING);
        }

        private void openDoc(string strDocFileName, swDocumentTypes_e docType)
        {
            RespVo oRespVo = SwBuAppService.getInstance().openDoc(strDocFileName, docType);
            if (!oRespVo.ok)
            {
                MessageBox.Show(oRespVo.msg);
            }
        }

        /// <summary>
        /// 创建圆管
        /// </summary>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            //新建一个草图并且绘制一个圆管
            NewCirclePipeInVo oCreateCirclePipeInVo = new NewCirclePipeInVo();
            oCreateCirclePipeInVo.CircleRadius = Double.Parse(txtBoxRadius.Text);
            oCreateCirclePipeInVo.Length = Double.Parse(txtBoxLength.Text);
            oCreateCirclePipeInVo.Thickness = Double.Parse(txtBoxThickness.Text);

            RespVo oRespVo = SwBuAppService.getInstance().createCirclePipe(oCreateCirclePipeInVo);
            if (!oRespVo.ok)
            {
                MessageBox.Show(oRespVo.msg);
            }

        }

        /// <summary>
        /// 保存当前文档
        /// </summary>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().saveCurDoc();
            MessageBox.Show(oRespVo.msg);
        }

        /// <summary>
        /// 另存当前文档
        /// </summary>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().saveAsCurDoc(SwBuAppService.getInstance().getCurDocPath());
            MessageBox.Show(oRespVo.msg);
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().closeCurDoc();
            if (!oRespVo.ok)
            {
                MessageBox.Show(oRespVo.msg);
            }
        }

        /// <summary>
        /// 导出dxf
        /// </summary>
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().exportDxf();
            MessageBox.Show(oRespVo.msg);

        }

        /// <summary>
        /// 导出svg
        /// </summary>
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().exportSvg();
            MessageBox.Show(oRespVo.msg);
        }

        /// <summary>
        /// 导出iges
        /// </summary>
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            RespVo oRespVo = SwBuAppService.getInstance().exportIges();
            MessageBox.Show(oRespVo.msg);
        }
    }
}
