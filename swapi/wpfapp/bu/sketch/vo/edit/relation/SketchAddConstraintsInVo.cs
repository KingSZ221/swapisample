using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.sketch.vo.edit.relation
{
    /// <summary>
    /// 添加草图约束关系
    /// </summary>
    [DisplayName("添加草图约束关系")]
    public class SketchAddConstraintsInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 草图约束关系类型
        /// </summary>
        [DisplayName("草图约束关系")]
        [Description("草图约束关系参考")]
        public string ConstraintId { get; set; } = "sgFIXED";

        #endregion

        #region consts

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGX3D = "sgALONGX3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgHORIZONTAL2D = "sgHORIZONTAL2D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgHORIZONTALPOINTS2D = "sgHORIZONTALPOINTS2D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGXPOINTS3D = "sgALONGXPOINTS3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgVERTICAL2D = "sgVERTICAL2D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGY3D = "sgALONGY3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgVERTPOINTS2D = "sgVERTPOINTS2D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGYPOINTS3D = "sgALONGYPOINTS3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGZPOINTS3D = "sgALONGZPOINTS3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgALONGZ3D = "sgALONGZ3D";

        /// <summary>
        /// 
        /// </summary>
        public const string sgCOLINEAR = "sgCOLINEAR";

        /// <summary>
        /// 
        /// </summary>
        public const string sgCORADIAL = "sgCORADIAL";

        /// <summary>
        /// 
        /// </summary>
        public const string sgPERPENDICULAR = "sgPERPENDICULAR";

        /// <summary>
        /// 
        /// </summary>
        public const string sgPARALLEL = "sgPARALLEL";

        /// <summary>
        /// 
        /// </summary>
        public const string sgTANGENT = "sgTANGENT";

        /// <summary>
        /// 
        /// </summary>
        public const string sgCONCENTRIC = "sgCONCENTRIC";

        /// <summary>
        /// 
        /// </summary>
        public const string sgCOINCIDENT = "sgCOINCIDENT";

        /// <summary>
        /// 
        /// </summary>
        public const string sgSYMMETRIC = "sgSYMMETRIC";

        /// <summary>
        /// 
        /// </summary>
        public const string sgATMIDDLE = "sgATMIDDLE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgATINTERSECT = "sgATINTERSECT";

        /// <summary>
        /// 
        /// </summary>
        public const string sgATPIERCE = "sgATPIERCE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgFIXED = "sgFIXED";

        /// <summary>
        /// 
        /// </summary>
        public const string sgANGLE = "sgANGLE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANG180 = "sgARCANG180";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANG270 = "sgARCANG270";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANG90 = "sgARCANG90";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANGBOTTOM = "sgARCANGBOTTOM";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANGLEFT = "sgARCANGLEFT";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANGRIGHT = "sgARCANGRIGHT";

        /// <summary>
        /// 
        /// </summary>
        public const string sgARCANGTOP = "sgARCANGTOP";

        /// <summary>
        /// 
        /// </summary>
        public const string sgDIAMETER = "sgDIAMETER";

        /// <summary>
        /// 
        /// </summary>
        public const string sgDISTANCE = "sgDISTANCE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgSAMELENGTH = "sgSAMELENGTH";

        /// <summary>
        /// 
        /// </summary>
        public const string sgOFFSETEDGE = "sgOFFSETEDGE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgSNAPANGLE = "sgSNAPANGLE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgSNAPGRID = "sgSNAPGRID";

        /// <summary>
        /// 
        /// </summary>
        public const string sgSNAPLENGTH = "sgSNAPLENGTH";

        /// <summary>
        /// 
        /// </summary>
        public const string sgUSEEDGE = "sgUSEEDGE";

        /// <summary>
        /// 
        /// </summary>
        public const string sgMERGEPOINTS = "sgMERGEPOINTS";

        #endregion
    }
}
