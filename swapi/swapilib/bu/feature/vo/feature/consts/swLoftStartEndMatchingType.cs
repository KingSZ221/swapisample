using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swapilib.bu.feature.vo.feature.consts
{
    /// <summary>
    /// 放样特征起始或结束轮廓处的相切类型
    /// </summary>
    [Description("放样特征起始或结束轮廓处的相切类型")]
    public enum swLoftStartEndMatchingType
    {
        [Description("无")]
        none = 0,

        [Description("与轮廓法线相切(垂直于轮廓)")]
        swTangentProfileNormal  = 1,

        [Description("与选定的向量相切(方向向量)")]
        swTangentSelectedVector = 2,

        [Description("与起始轮廓共享一条边的所有相邻面相切")]
        swTangentAllAdjacentFaces = 3,

        [Description("与起始轮廓共享边的某些选定面相切(不可用)")]
        swTangentSomeSelectedFaces = 4
    }
}
