using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfapp.bu.modeldoc.vo.select
{
    /// <summary>
    /// 选中对象类型
    /// </summary>
    public enum swSelectType_ext
    {
        [Description("")]
        swSelNOTHING = 0,

        [Description("EDGE")]
        swSelEDGES = 1,

        [Description("FACE")]
        swSelFACES = 2,

        [Description("VERTEX")]
        swSelVERTICES = 3,

        [Description("PLANE")]
        swSelDATUMPLANES = 4,

        [Description("AXIS")]
        swSelDATUMAXES = 6,

        [Description("DATUMPOINT")]
        swSelDATUMPOINTS = 7,

        [Description("OLEITEM")]
        swSelOLEITEMS = 8,

        [Description("ATTRIBUTE")]
        swSelATTRIBUTES = 9,

        [Description("SKETCH")]
        swSelSKETCHES = 10,

        [Description("SKETCHSEGMENT")]
        swSelSKETCHSEGS = 11,

        [Description("SKETCHPOINT")]
        swSelSKETCHPOINTS = 12,

        [Description("DRAWINGVIEW")]
        swSelDRAWINGVIEWS = 13,

        [Description("GTOL")]
        swSelGTOLS = 14,

        [Description("DIMENSION")]
        swSelDIMENSIONS = 15,

        [Description("NOTE")]
        swSelNOTES = 16,

        [Description("SECTIONLINE")]
        swSelSECTIONLINES = 17,

        [Description("DETAILCIRCLE")]
        swSelDETAILCIRCLES = 18,

        [Description("SECTIONTEXT")]
        swSelSECTIONTEXT = 19,

        [Description("SHEET")]
        swSelSHEETS = 20,

        [Description("COMPONENT")]
        swSelCOMPONENTS = 21,

        [Description("MATE")]
        swSelMATES = 22,

        [Description("BODYFEATURE")]
        swSelBODYFEATURES = 23,

        [Description("REFCURVE")]
        swSelREFCURVES = 24,

        [Description("EXTSKETCHSEGMENT")]
        swSelEXTSKETCHSEGS = 25,

        [Description("EXTSKETCHPOINT")]
        swSelEXTSKETCHPOINTS = 26,

        [Description("HELIX")]
        swSelHELIX = 27,

        [Description("REFERENCECURVES")]
        swSelREFERENCECURVES = 28,

        [Description("REFSURFACE")]
        swSelREFSURFACES = 29,

        [Description("CENTERMARKS")]
        swSelCENTERMARKS = 30
    }
}
