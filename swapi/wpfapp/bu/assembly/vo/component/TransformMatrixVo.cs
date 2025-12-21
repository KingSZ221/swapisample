using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace wpfapp.bu.assembly.vo.component
{
    /// <summary>
    /// 变换矩阵
    /// </summary>
    [DisplayName("变换矩阵")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [JsonObject]
    public class TransformMatrixVo
    {
        #region Fields

        /// <summary>
        /// X轴旋转向量1
        /// </summary>
        [DisplayName("X轴旋转向量1")]
        [Description("X轴旋转向量[1,0,0]。")]
        [PropertyOrder(1)]
        public double XRotateVec1 { get; set; } = 1;

        /// <summary>
        /// X轴旋转向量2
        /// </summary>
        [DisplayName("X轴旋转向量2")]
        [Description("X轴旋转向量[1,0,0]。")]
        [PropertyOrder(2)]
        public double XRotateVec2 { get; set; } = 0;

        /// <summary>
        /// X轴旋转向量3
        /// </summary>
        [DisplayName("X轴旋转向量3")]
        [Description("X轴旋转向量[1,0,0]。")]
        [PropertyOrder(3)]
        public double XRotateVec3 { get; set; } = 0;

        /// <summary>
        /// Y轴旋转向量1
        /// </summary>
        [DisplayName("Y轴旋转向量1")]
        [Description("Y轴旋转向量[1,0,0]。")]
        [PropertyOrder(4)]
        public double YRotateVec1 { get; set; } = 1;

        /// <summary>
        /// Y轴旋转向量2
        /// </summary>
        [DisplayName("Y轴旋转向量2")]
        [Description("Y轴旋转向量[1,0,0]。")]
        [PropertyOrder(5)]
        public double YRotateVec2 { get; set; } = 0;

        /// <summary>
        /// Y轴旋转向量3
        /// </summary>
        [DisplayName("Y轴旋转向量3")]
        [Description("Y轴旋转向量[1,0,0]。")]
        [PropertyOrder(6)]
        public double YRotateVec3 { get; set; } = 0;

        /// <summary>
        /// Z轴旋转向量1
        /// </summary>
        [DisplayName("Z轴旋转向量1")]
        [Description("Z轴旋转向量[1,0,0]。")]
        [PropertyOrder(7)]
        public double ZRotateVec1 { get; set; } = 1;

        /// <summary>
        /// Z轴旋转向量2
        /// </summary>
        [DisplayName("Z轴旋转向量2")]
        [Description("Z轴旋转向量[1,0,0]。")]
        [PropertyOrder(8)]
        public double ZRotateVec2 { get; set; } = 0;

        /// <summary>
        /// Z轴旋转向量3
        /// </summary>
        [DisplayName("Z轴旋转向量3")]
        [Description("Z轴旋转向量[1,0,0]。")]
        [PropertyOrder(9)]
        public double ZRotateVec3 { get; set; } = 0;

        /// <summary>
        /// X轴平移距离
        /// </summary>
        [DisplayName("X轴平移距离")]
        [Description("X轴平移距离。")]
        [PropertyOrder(10)]
        public double XTranslation { get; set; } = 0;

        /// <summary>
        /// Y轴平移距离
        /// </summary>
        [DisplayName("Y轴平移距离")]
        [Description("Y轴平移距离。")]
        [PropertyOrder(11)]
        public double YTranslation { get; set; } = 0;

        /// <summary>
        /// Z轴平移距离
        /// </summary>
        [DisplayName("Z轴平移距离")]
        [Description("Z轴平移距离。")]
        [PropertyOrder(12)]
        public double ZTranslation { get; set; } = 0;

        /// <summary>
        /// 缩放系数
        /// </summary>
        [DisplayName("缩放系数")]
        [Description("缩放系数。")]
        [PropertyOrder(13)]
        public double Scale { get; set; } = 1;

        #endregion

        #region convert

        public double[] toDoubles()
        {
            //[X旋转向量1，X旋转向量2，X旋转向量3，预留]
            //[Y旋转向量1，Y旋转向量2，Y旋转向量3，预留]
            //[Z旋转向量1，Z旋转向量2，Z旋转向量3，预留]
            //[X平移距离 ，Y平移距离， Z平移距离，缩放系数]
            double[] dMatrix = new double[4*4];
            dMatrix[0] = XRotateVec1;
            dMatrix[1] = XRotateVec2;
            dMatrix[2] = XRotateVec3;
            dMatrix[3] = 0;
            dMatrix[4] = YRotateVec1;
            dMatrix[5] = YRotateVec2;
            dMatrix[6] = YRotateVec3;
            dMatrix[7] = 0;
            dMatrix[8] = ZRotateVec1;
            dMatrix[9] = ZRotateVec2;
            dMatrix[10] = ZRotateVec3;
            dMatrix[11] = 0;
            dMatrix[12] = XTranslation;
            dMatrix[13] = YTranslation;
            dMatrix[14] = ZTranslation;
            dMatrix[15] = Scale;

            return dMatrix;
        }

        #endregion
    }
}
