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
    [DisplayName("创建直螺纹孔")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class WzdTapInVo : HoleWizardBaseInVo
    {
        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override swWzdGeneralHoleTypes_ext getHoleType()
        {
            return swWzdGeneralHoleTypes_ext.swWzdTap;
        }

        /// <summary>
        /// 获取异形孔类型，由派生类实现
        /// </summary>
        /// <returns>swWzdGeneralHoleTypes_ext</returns>
        public override string getHoleTypeName()
        {
            return "直螺纹孔";
        }

        /// <summary>
        /// 1螺纹线深度
        /// </summary>
        [DisplayName("1螺纹线深度")]
        [Description("")]
        [Category("孔规格")]
        [PropertyOrder(8)]
        public double TabThreadDepth { get; set; } = 0;

        /// <summary>
        /// 2近端锥孔直径
        /// </summary>
        [DisplayName("2近端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(9)]
        public double NearCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 3近端锥孔角度
        /// </summary>
        [DisplayName("3近端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(10)]
        public double NearCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 4远端锥孔直径
        /// </summary>
        [DisplayName("4远端锥孔直径")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(11)]
        public double FarCsinkDiameter { get; set; } = 0;

        /// <summary>
        /// 5远端锥孔角度
        /// </summary>
        [DisplayName("5远端锥孔角度")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(12)]
        public double FarCsinkAngle { get; set; } = 0;

        /// <summary>
        /// 6装饰螺纹线
        /// </summary>
        [DisplayName("6装饰螺纹线")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(13)]
        public double CosmeticThread { get; set; } = 1;

        /// <summary>
        /// 7装饰螺纹线类型
        /// </summary>
        [DisplayName("7装饰螺纹线类型")]
        [Description("见swWzdHoleCosmeticThreadTypes_e")]
        [Category("选项")]
        [PropertyOrder(14)]
        public swWzdHoleCosmeticThreadTypes_ext CosmeticThreadType { get; set; } = swWzdHoleCosmeticThreadTypes_ext.swCosmeticThreadWithCallout;

        /// <summary>
        /// 8螺纹线终止条件
        /// </summary>
        [DisplayName("8螺纹线终止条件")]
        [Description("见?")]
        [Category("选项")]
        [PropertyOrder(15)]
        public int ThreadEndCondition { get; set; } = 0;

        /// <summary>
        /// 9Helicoil螺纹线类型
        /// </summary>
        [DisplayName("9Helicoil螺纹线类型")]
        [Description("仅当StanardIndex为swStandardHelicoilInCh或swStandardHelicoilMetric时才有效")]
        [Category("选项")]
        [PropertyOrder(16)]
        public int HelicoilTapType { get; set; } = 0;

        /// <summary>
        /// 10偏移量
        /// </summary>
        [DisplayName("10偏移量")]
        [Description("")]
        [Category("选项")]
        [PropertyOrder(17)]
        public double Offset { get; set; } = 0;

        public override double getValue(int i)
        {
            switch (i)
            {
                case 1: return TabThreadDepth / 1000;
                case 2: return NearCsinkDiameter / 1000;
                case 3: return NearCsinkAngle * Math.PI / 180;
                case 4: return FarCsinkDiameter / 1000;
                case 5: return FarCsinkAngle * Math.PI / 180;
                case 6: return 1;// DrillAngleAtBottom * Math.PI / 180;
                case 7: return (double)CosmeticThreadType;
                case 8: return ThreadEndCondition;
                case 9: return HelicoilTapType;
                case 10: return Offset / 1000;
                default: return -1;
            }
        }
    }
}

