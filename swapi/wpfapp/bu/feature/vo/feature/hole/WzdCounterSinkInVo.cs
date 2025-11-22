using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.feature.vo.feature.hole
{
    [DisplayName("创建锥形沉头孔")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class WzdCounterSinkInVo : HoleWizardBaseInVo
    {
        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override swWzdGeneralHoleTypes_ext getHoleType()
        {
            return swWzdGeneralHoleTypes_ext.swWzdCounterSink;
        }

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override string getHoleTypeName()
        {
            return "锥形沉头孔";
        }

        /// <summary>
        /// 1近端锥孔直径
        /// </summary>
        [DisplayName("1近端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(8)]
        public double NearCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 2近端锥孔角度
        /// </summary>
        [DisplayName("2近端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(9)]
        public double NearCsinkAngle { get; set; } = 0;

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
        /// 6远端锥孔直径
        /// </summary>
        [DisplayName("6远端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(13)]
        public double FarCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 7远端锥孔角度
        /// </summary>
        [DisplayName("7远端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(14)]
        public double FarCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 8偏移量
        /// </summary>
        [DisplayName("8偏移量")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(15)]
        public double Offset { get; set; } = 0;

        /// <summary>
        /// 9头部间隙类型
        /// </summary>
        [DisplayName("9头部间隙")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(16)]
        public int HeadClearanceType { get; set; } = 0;

        public override double getValue(int i)
        {
            switch (i)
            {
                case 1: return NearCsinkDiameter / 1000;
                case 2: return NearCsinkAngle * Math.PI / 180;
                case 3: return HeadClearance / 1000;
                case 4: return (double)ScrewFit;
                case 5: return DrillAngleAtBottom * Math.PI / 180;
                case 6: return FarCsinkDiameter / 1000;
                case 7: return FarCsinkAngle * Math.PI / 180;
                case 8: return Offset / 1000;
                case 9: return HeadClearanceType;
                default: return -1;
            }
        }
    }
}
