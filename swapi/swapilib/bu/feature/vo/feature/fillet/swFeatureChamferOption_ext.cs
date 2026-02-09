using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.fillet
{
    /// <summary>
    /// 倒角选项
    /// </summary>
    public enum swFeatureChamferOption_ext
    {
        [Description("反向")]
        swFeatureChamferFlipDirection = 1,

        [Description("保持特征")]
        swFeatureChamferKeepFeature = 2,

        [Description("顶点")]
        swFeatureChamferTangentPropagation = 4,

        [Description("等距离")]
        swFeatureChamferPropagateFeatToParts = 8
    }
}
