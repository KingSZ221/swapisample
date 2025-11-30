using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.feature.vo.feature.consts;
using wpfapp.bu.sketch.vo.entity;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.feature.vo.feature.mirror
{
    [DisplayName("创建镜像特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class InsertMirrorFeatureInVo
    {
        #region Fields

        /// <summary>
        /// 镜像实体
        /// </summary>
        [DisplayName("镜像实体")]
        [Description("true:镜像实体，false:镜像特征或面")]
        [PropertyOrder(1)]
        public bool BMirrorBody { get; set; } = false;

        /// <summary>
        /// 镜像几何体特征
        /// </summary>
        [DisplayName("镜像几何体特征")]
        [Description("true:只镜像几何体特征，false:求解所有特征")]
        [PropertyOrder(2)]
        public bool BGeometryPattern { get; set; } = false;

        /// <summary>
        /// 合并所有镜像实体
        /// </summary>
        [DisplayName("合并所有镜像实体")]
        [Description("true:合并所有镜像实体，false:不合并所有镜像实体")]
        [PropertyOrder(3)]
        public bool BMerge { get; set; } = false;

        /// <summary>
        /// knit表面
        /// </summary>
        [DisplayName("knit表面")]
        [Description("true:knit表面，false:不knit表面")]
        [PropertyOrder(4)]
        public bool BKnit { get; set; } = false;

        /// <summary>
        /// 影响实体
        /// </summary>
        [DisplayName("影响实体")]
        [Description("固定圆角可选:swFeatureFilletCircular/swFeatureFilletConicRho/swFeatureFilletConicRadius" +
            "面圆角可选：swFeatureFilletCircular/swFeatureFilletConicRho/swFeatureFilletConicRadius" +
            "完整圆角可选：swFeatureFilletCircular")]
        [PropertyOrder(5)]
        public swFeatureScope_ext ScopeOptions { get; set; } = 0;

        /// <summary>
        /// 拉伸特征名称
        /// </summary>
        [DisplayName("拉伸特征名称")]
        [Description("设置拉伸特征名称")]
        [Category("拉伸特征名称")]
        [PropertyOrder(6)]
        public string FeatrueName { get; set; } = "镜像特征1";

        #endregion
    }
}