using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.feature.vo.feature.fillet
{
    /// <summary>
    /// 圆角类型
    /// </summary>
    public enum swFeatureFilletProfileType_ext
    {
        [Description("圆形")]
        swFeatureFilletCircular = 0,

        [Description("圆锥Rho")]
        swFeatureFilletConicRho = 1,

        [Description("圆锥半径")]
        swFeatureFilletConicRadius = 2,

        [Description("曲率连续")]
        swFeatureFilletConicRhoZeroChamfer = 3
    }
}
