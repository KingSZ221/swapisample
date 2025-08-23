using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.app;

namespace wpfapp.ui.prop
{
    public class SwUiPropService
    {
        #region Fields

        private static SwUiPropService _instance = new SwUiPropService();

        #endregion

        #region Construction

        /// <summary>
        /// 构造函数
        /// </summary>
        public SwUiPropService() { }

        /// <summary>
        /// 获取单例
        /// </summary>
        /// <returns></returns>
        public static SwUiPropService getInstance()
        {
            return _instance;
        }

        #endregion

        #region init

        public void init()
        {

        }

        public void destroy()
        {

        }

        public bool showPropObjDlg(string strDlgTitle, object oPropObj)
        {
            SwUiPropDialog oPropDlg = new SwUiPropDialog();
            oPropDlg.Owner = SwBuAppService.getMainWindow();
            oPropDlg.Title = strDlgTitle;
            oPropDlg.setPropObj(oPropObj);
            bool? bResult = oPropDlg.ShowDialog();

            if(bResult == true)
            {
                // 用户点击确定
                return true;
            }
            else if (bResult == false)
            {
                // 用户点击取消
                return false;
            }
            else
            {
                // 用户直接关闭窗口
                return false;
            }
        }

        #endregion
    }
}
