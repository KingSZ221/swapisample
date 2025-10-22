using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.bu.sketch.vo.entity;

namespace wpfapp.bu.sketch.vo.edit.mirror
{
    /// <summary>
    /// 镜像实体
    /// </summary>
    [DisplayName("镜像实体")]
    public class SketchMirrorInVo : SketchEditInVoBase
    {
        #region Fields

        /// <summary>
        /// 镜像实体
        /// </summary>
        [DisplayName("镜像实体")]
        [Category("选择")]
        [Description("选择一个或多个顶点或边作为待镜像的实体")]
        public List<EntitySelectId> MirrorEntityIds { get; set; }

        /// <summary>
        /// 镜像轴
        /// </summary>
        [DisplayName("镜像轴")]
        [Category("选择")]
        [Description("选择一个中心线作为镜像轴")]
        public EntitySelectId CenterLineId { get; set; }

        #endregion
    }
}
