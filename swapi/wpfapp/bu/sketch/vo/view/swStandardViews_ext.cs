using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.view
{
    /// <summary>
    /// 视图ID
    /// </summary>
    public enum swStandardViews_ext
    {
        [Description("swFrontView")]
        swFrontView = 1,

        [Description("swBackView")]
        swBackView = 2,

        [Description("swLeftView")]
        swLeftView = 3,

        [Description("swRightView")]
        swRightView = 4,

        [Description("swTopView")]
        swTopView = 5,

        [Description("swBottomView")]
        swBottomView = 6,

        [Description("swIsometricView")]
        swIsometricView = 7,

        [Description("swTrimetricView")]
        swTrimetricView = 8,

        [Description("swDimetricView")]
        swDimetricView = 9
    }
}
