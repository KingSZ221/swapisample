using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace swapilib.bu.feature.vo.feature.hole
{
    [DisplayName("创建常规孔")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class WzdHoleInVo : HoleWizardBaseInVo
    {
        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override swWzdGeneralHoleTypes_ext getHoleType()
        {
            return swWzdGeneralHoleTypes_ext.swWzdHole;
        }

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override string getHoleTypeName()
        {
            return "常规孔";
        }

        /// <summary>
        /// 1螺钉套合
        /// </summary>
        [DisplayName("1螺钉套合")]
        [Description("参考swWzdHoleScrewClearanceTypes_e")]
        [Category("孔规格")]
        [PropertyOrder(8)]
        public swWzdHoleScrewClearanceTypes_ext ScrewFit { get; set; } = 0;

        /// <summary>
        /// 2底部钻孔角度
        /// </summary>
        [DisplayName("2底部钻孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(9)]
        public double DrillAngleAtBottom { get; set; } = 0;

        /// <summary>
        /// 3近端锥孔直径
        /// </summary>
        [DisplayName("3近端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(10)]
        public double NearCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 4近端锥孔角度
        /// </summary>
        [DisplayName("4近端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(11)]
        public double NearCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 5远端锥孔直径
        /// </summary>
        [DisplayName("5远端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(12)]
        public double FarCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 6远端锥孔角度
        /// </summary>
        [DisplayName("6远端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(13)]
        public double FarCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 7偏移量
        /// </summary>
        [DisplayName("7偏移量")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(14)]
        public double Offset { get; set; } = 0;

        public override double getValue(int i)
        {
            switch (i)
            {
                case 1: return (int)ScrewFit;
                case 2: return DrillAngleAtBottom * Math.PI / 180;
                case 3: return NearCsinkDiameter / 1000;
                case 4: return NearCsinkAngle * Math.PI / 180;
                case 5: return FarCsinkDiameter / 1000;
                case 6: return FarCsinkAngle * Math.PI / 180;
                case 7: return Offset / 1000;
                default: return -1;
            }
        }
    }
}
