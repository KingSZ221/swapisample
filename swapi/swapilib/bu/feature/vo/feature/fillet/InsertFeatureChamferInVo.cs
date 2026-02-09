using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.fillet
{
    [DisplayName("创建倒角特征")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class InsertFeatureChamferInVo
    {
        #region Fields

        /// <summary>
        /// 倒角类型
        /// </summary>
        [DisplayName("倒角类型")]
        [Description("true:圆角不对称，false:对称")]
        [PropertyOrder(1)]
        public swChamferType_ext ChamferType { get; set; } = swChamferType_ext.swChamferAngleDistance;

        /// <summary>
        /// 倒角距离
        /// </summary>
        [DisplayName("倒角距离")]
        [Description("距离距离倒角的第一距离，倒角类型为角度和距离时")]
        [PropertyOrder(2)]
        public double Width { get; set; } = 20;

        /// <summary>
        /// 倒角角度
        /// </summary>
        [DisplayName("倒角角度")]
        [Description("倒角角度，倒角类型为角度和距离时")]
        [PropertyOrder(3)]
        public double Angle { get; set; } = 0;

        /// <summary>
        /// 等距倒角的距离
        /// </summary>
        [DisplayName("等距倒角的距离")]
        [Description("距离距离倒角的第二距离，倒角类型为等距离时")]
        [PropertyOrder(4)]
        public double OtherDist { get; set; } = 0;

        /// <summary>
        /// 顶点倒角距离1
        /// </summary>
        [DisplayName("顶点倒角距离1")]
        [Description("倒角类型为距离和距离或顶点时")]
        [PropertyOrder(5)]
        public double VertexChamDist1 { get; set; } = 0;

        /// <summary>
        /// 顶点倒角距离2
        /// </summary>
        [DisplayName("顶点倒角距离2")]
        [Description("倒角类型为距离和距离或顶点时")]
        [PropertyOrder(6)]
        public double VertexChamDist2 { get; set; } = 0;

        /// <summary>
        /// 顶点倒角距离3
        /// </summary>
        [DisplayName("顶点倒角距离3")]
        [Description("倒角类型为顶点时")]
        [PropertyOrder(7)]
        public double VertexChamDist3 { get; set; } = 0;

        /// <summary>
        /// 倒角选项-反向
        /// </summary>
        [DisplayName("倒角选项-反向")]
        [Description("ture:反向,false-不反向")]
        [PropertyOrder(8)]
        public bool FlipDirection { get; set; } = false;

        /// <summary>
        /// 倒角选项-保持特征
        /// </summary>
        [DisplayName("倒角选项-保持特征")]
        [Description("ture:保持特征,false-不保持特征")]
        [PropertyOrder(9)]
        public bool KeepFeature { get; set; } = false;

        /// <summary>
        /// 倒角选项-切线延伸
        /// </summary>
        [DisplayName("倒角选项-切线延伸")]
        [Description("ture:切线延伸,false-不切线延伸")]
        [PropertyOrder(10)]
        public bool TangentPropagation { get; set; } = false;

        /// <summary>
        /// 倒角选项-传播特征到零件
        /// </summary>
        [DisplayName("倒角选项-传播特征到零件")]
        [Description("ture:传播特征到零件,false-不传播特征到零件")]
        [PropertyOrder(11)]
        public bool PropagateFeatToParts { get; set; } = false;

        /// <summary>
        /// 倒角选项
        /// </summary>
        public int getOptions()
        {
            int option = 0;
            if (FlipDirection)
            {
                option |= (int)swFeatureChamferOption_ext.swFeatureChamferFlipDirection;
            }
            if (KeepFeature)
            {
                option |= (int)swFeatureChamferOption_ext.swFeatureChamferKeepFeature;
            }
            if (TangentPropagation)
            {
                option |= (int)swFeatureChamferOption_ext.swFeatureChamferTangentPropagation;
            }
            if (PropagateFeatToParts)
            {
                option |= (int)swFeatureChamferOption_ext.swFeatureChamferPropagateFeatToParts;
            }
            return option;
        }

        /// <summary>
        /// 拉伸特征名称
        /// </summary>
        [DisplayName("拉伸特征名称")]
        [Description("设置拉伸特征名称")]
        [Category("拉伸特征名称")]
        [PropertyOrder(12)]
        public string FeatrueName { get; set; } = "倒角特征1";

        #endregion
    }
}
