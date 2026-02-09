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
    [DisplayName("创建柱形沉头孔")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class WzdCounterBoreInVo : HoleWizardBaseInVo
    {
        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override swWzdGeneralHoleTypes_ext getHoleType()
        {
            return swWzdGeneralHoleTypes_ext.swWzdCounterBore;
        }

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override string getHoleTypeName()
        {
            return "柱形沉头孔";
        }

        /// <summary>
        /// 1沉头孔直径
        /// </summary>
        [DisplayName("1沉头孔直径")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(8)]
        public double CounterBoreDiameter { get; set; } = 0;

        /// <summary>
        /// 2沉头孔深度
        /// </summary>
        [DisplayName("2沉头孔深度")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(9)]
        public double CounterBoreDepth { get; set; } = 0;

        /// <summary>
        /// 3头部间隙
        /// </summary>
        [DisplayName("3头部间隙")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(10)]
        public double HeadClearance { get; set; } = 0;

        /// <summary>
        /// 4螺钉套合
        /// </summary>
        [DisplayName("4螺钉套合")]
        [Description("参考swWzdHoleScrewClearanceTypes_e")]
        [Category("孔规格")]
        [PropertyOrder(11)]
        public swWzdHoleScrewClearanceTypes_ext ScrewFit { get; set; } = 0;

        /// <summary>
        /// 5底部钻孔角度
        /// </summary>
        [DisplayName("5底部钻孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(12)]
        public double DrillAngleAtBottom { get; set; } = 0;

        /// <summary>
        /// 6近端锥孔直径
        /// </summary>
        [DisplayName("6近端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(13)]
        public double NearCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 7近端锥孔角度
        /// </summary>
        [DisplayName("7近端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(14)]
        public double NearCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 8螺钉下锥孔直径
        /// </summary>
        [DisplayName("8螺钉下锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(15)]
        public double UnderheadCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 9螺钉下锥孔角度
        /// </summary>
        [DisplayName("9螺钉下锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(16)]
        public double UnderheadCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 10远端锥孔直径
        /// </summary>
        [DisplayName("10远端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(17)]
        public double FarCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 11远端锥孔角度
        /// </summary>
        [DisplayName("11远端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(18)]
        public double FarCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 12偏移量
        /// </summary>
        [DisplayName("12偏移量")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(19)]
        public double Offset { get; set; } = 0;

        public override double getValue(int i)
        {
            switch(i)
            {
                case 1: return CounterBoreDiameter / 1000;
                case 2: return CounterBoreDepth / 1000;
                case 3: return HeadClearance / 1000;
                case 4: return (double)ScrewFit;
                case 5: return DrillAngleAtBottom;
                case 6: return NearCsinkDiameter / 1000;
                case 7: return NearCsinkAngle * Math.PI / 180;
                case 8: return UnderheadCsinkDiameter / 1000;
                case 9: return UnderheadCsinkAngle * Math.PI / 180;
                case 10: return FarCsinkDiameter / 1000;
                case 11: return FarCsinkAngle * Math.PI / 180;
                case 12: return Offset / 1000;
                default: return -1;
            }
        }
    }
}
