using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.mirror
{
    /// <summary>
    /// 影响范围
    /// </summary>
    public enum swFeatureScope_ext
    {
        [Description("所有实体")]
        swFeatureScope_AllBodies = 0,

        [Description("自动选择")]
        swFeatureScope_SelectedBodiesWithAutoSelect = 1,

        [Description("非自动选择")]
        swFeatureScope_SelectedBodiesWithOutAutoSelect = 2
    }
}
