# npm install pythonnet

import clr
import sys
import os

# swapilib动态库路径，实际使用时请修改为实际路径
swapilib_path = r'E:\1_repo_pub\swapisample\swapi\swapilib\bin\Debug'

# 添加swapilib动态库路径并添加swapilib动态库引用
sys.path.append(swapilib_path)
clr.AddReference('swapilib')

# 导入swapilib动态库类库
from swapilib import swapipy
from swapilib.basic.io import RespVo
from swapilib.bu.file.vo import NewDocInVo

# 打印返回结果
def printResult(strOp:str, oResult:RespVo):
    print(f" {strOp} : {oResult.ok} , {oResult.msg}")
    return

# 普通测试
print(swapipy.TestHello("sw"))

# 返回值测试
result = swapipy.TestRespVo()
printResult("swapipy.TestRespVo", result)

# region 1.初始化
print("1.初始化")

# 1.1.初始化SW资源路径
# swapilib_path\res 该目录为零件模板路径以及文件保存路径
result = swapipy.Init(swapilib_path)
printResult("swapipy.Init", result)

# 1.2.连接SW，需要Python以管理员权限运行
result = swapipy.ConnectSw()
printResult("swapipy.ConnectSw", result)

# endregion

# region 2.创建零件-护栏
print("2.创建零件-护栏")
from swapilib.bu.file.vo import NewDocInVo

# 2.1.创建零件
oNewDocInVo = NewDocInVo()
oNewDocInVo.DocType = 1
result = swapipy.NewDoc(oNewDocInVo)
printResult("swapipy.NewDoc", result)

# endregion

# region 3.绘制面管1
print("3.绘制面管1")
# 用户参数：面管宽度2000mm、圆管半径50mm、立柱高度1500mm

# 3.1.清空选择对象列表
from swapilib.bu.modeldoc.vo.select import ClearSelectionInVo
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 3.2.通过名称或位置选中对象
from swapilib.bu.modeldoc.vo.select import SelectByIDInVo
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "右视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 3.3.插入草图
from swapilib.bu.sketch.vo.sketch import InsertSketchInVo
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 3.4.绘制半径圆
from swapilib.bu.sketch.vo.draw.circle import CreateCircleByRadiusInVo
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 0
oCreateCircleByRadiusInVo.YC = 750 # 圆心Y=立柱高度1500mm / 2
oCreateCircleByRadiusInVo.Radius = 50 # 圆管半径50mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 3.5.创建拉伸基体特征
from swapilib.bu.feature.vo.feature.extrusion import FeatureExtrusionInVo
from swapilib.bu.feature.vo.feature.consts import swEndConditions_ext
from swapilib.bu.feature.vo.feature.consts import swStartConditions_ext
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 1000 # 拉伸距离=面管宽度2000mm / 2
oFeatureExtrusionInVo.D2 = 1000 # 拉伸距离=面管宽度2000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "面管1"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 4.绘制面管2
print("4.绘制面管2")
# 用户参数：面管宽度2000mm、圆管半径50mm、立柱高度1500mm

# 4.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 4.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "右视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 4.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 4.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 0
oCreateCircleByRadiusInVo.YC = -750.0 # 圆心Y=-立柱高度1500mm / 2
oCreateCircleByRadiusInVo.Radius = 50 # 圆管半径50mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 4.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 1000 # 拉伸距离=面管宽度2000mm / 2
oFeatureExtrusionInVo.D2 = 1000 # 拉伸距离=面管宽度2000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "面管2"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 5.绘制立柱1
print("5.绘制立柱1")
# 用户参数：立柱高度1500mm、圆管半径40mm、横杆宽度1000mm

# 5.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 5.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 5.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 5.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = -500 # 圆心X=-立柱高度1500mm / 2
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 40 # 圆管半径40mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 5.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 750 # 拉伸距离=立柱高度1500mm / 2
oFeatureExtrusionInVo.D2 = 750 # 拉伸距离=立柱高度1500mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "立柱1"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 6.绘制立柱2
print("6.绘制立柱2")
# 用户参数：立柱高度1500mm、圆管半径40mm、横杆宽度1000mm

# 6.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 6.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 6.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 6.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 500 # 圆心X=横杆宽度1000mm / 2
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 40 # 圆管半径40mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 6.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 750 # 拉伸距离=立柱高度1500mm / 2
oFeatureExtrusionInVo.D2 = 750 # 拉伸距离=立柱高度1500mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "立柱2"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 7.绘制横杆1
print("7.绘制横杆1")
# 用户参数：横杆宽度1000mm、圆管半径25mm、竖杆高度1000mm

# 7.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 7.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "右视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 7.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 7.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 0
oCreateCircleByRadiusInVo.YC = 500 # 圆心Y=竖杆高度1000mm / 2
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 7.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=横杆宽度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=横杆宽度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "横杆1"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 8.绘制横杆2
print("8.绘制横杆2")
# 用户参数：横杆宽度1000mm、圆管半径25mm、竖杆高度1000mm

# 8.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 8.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "右视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 8.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 8.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 0
oCreateCircleByRadiusInVo.YC = -500 # 圆心Y=-竖杆高度1000mm / 2
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 8.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=横杆宽度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=横杆宽度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "横杆2"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 9.绘制竖杆1
print("9.绘制竖杆1")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 9.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 9.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 9.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 9.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = -400.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 9.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆1"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 10.绘制竖杆2
print("10.绘制竖杆2")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 10.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 10.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 10.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 10.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = -240.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 10.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆2"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 11.绘制竖杆3
print("11.绘制竖杆3")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 11.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 11.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 11.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 11.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = -80.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 11.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆3"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 12.绘制竖杆4
print("12.绘制竖杆4")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 12.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 12.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 12.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 12.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 80.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 12.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆4"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 13.绘制竖杆5
print("13.绘制竖杆5")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 13.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 13.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 13.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 13.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 240.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 13.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆5"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 14.绘制竖杆6
print("14.绘制竖杆6")
# 用户参数：竖杆高度1000mm、圆管半径25mm、两端见光宽度100mm、5根竖杆
# 计算参数1：竖杆间距=(横杆宽度1000mm - 两端见光宽度100mm * 2) / (5根竖杆) = 160mm
# 计算参数2：第1个竖杆位置=-横杆宽度1000mm/2 + 两端见光宽度100mm = -400mm

# 14.1.清空选择对象列表
oClearSelectionInVo = ClearSelectionInVo()
oClearSelectionInVo.All = True
result = swapipy.ClearSelection(oClearSelectionInVo)
printResult("swapipy.ClearSelection", result)

# 14.2.通过名称或位置选中对象
oSelectByIDInVo = SelectByIDInVo()
oSelectByIDInVo.Name = "上视基准面"
oSelectByIDInVo.Type = "PLANE"
oSelectByIDInVo.Append = False
oSelectByIDInVo.Mark = 0
result = swapipy.SelectByID(oSelectByIDInVo)
printResult("swapipy.SelectByID", result)

# 14.3.插入草图
oInsertSketchInVo = InsertSketchInVo()
oInsertSketchInVo.UpdateEditRebuild = True
result = swapipy.InsertSketch(oInsertSketchInVo)
printResult("swapipy.InsertSketch", result)

# 14.4.绘制半径圆
oCreateCircleByRadiusInVo = CreateCircleByRadiusInVo()
oCreateCircleByRadiusInVo.XC = 400.0 # 圆心X=第i个竖杆位置 + (竖杆序号-1)*竖杆间距
oCreateCircleByRadiusInVo.YC = 0
oCreateCircleByRadiusInVo.Radius = 25 # 圆管半径25mm
result = swapipy.CreateCircleByRadius(oCreateCircleByRadiusInVo)
printResult("swapipy.CreateCircleByRadius", result)

# 14.5.创建拉伸基体特征
oFeatureExtrusionInVo = FeatureExtrusionInVo()
oFeatureExtrusionInVo.Sd = False # 双向拉伸
oFeatureExtrusionInVo.Flip = False
oFeatureExtrusionInVo.Dir = False
oFeatureExtrusionInVo.T1 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.T2 = swEndConditions_ext.swEndCondBlind
oFeatureExtrusionInVo.D1 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.D2 = 500 # 拉伸距离=竖杆高度1000mm / 2
oFeatureExtrusionInVo.Dchk1 = False
oFeatureExtrusionInVo.Dchk2 = False
oFeatureExtrusionInVo.Ddir1 = False
oFeatureExtrusionInVo.Ddir2 = False
oFeatureExtrusionInVo.Dang1 = 0
oFeatureExtrusionInVo.Dang2 = 0
oFeatureExtrusionInVo.OffsetReverse1 = False
oFeatureExtrusionInVo.OffsetReverse2 = False
oFeatureExtrusionInVo.TranslateSurface1 = False
oFeatureExtrusionInVo.TranslateSurface2 = False
oFeatureExtrusionInVo.Merge = False
oFeatureExtrusionInVo.UseFeatScope = False
oFeatureExtrusionInVo.UseAutoSelect = False
oFeatureExtrusionInVo.T0 = swStartConditions_ext.swStartSketchPlane
oFeatureExtrusionInVo.StartOffset = 0
oFeatureExtrusionInVo.FlipStartOffset = False
oFeatureExtrusionInVo.FeatrueName = "竖杆6"
result = swapipy.FeatureExtrusion(oFeatureExtrusionInVo)
printResult("swapipy.FeatureExtrusion", result)

# endregion

# region 15.调整视图
print("15.调整视图")
from swapilib.bu.modeldoc.vo.view import ShowNamedViewInVo

# 15.1.显示视图
oShowNamedViewInVo = ShowNamedViewInVo()
oShowNamedViewInVo.ViewId = 7 # 等轴侧视图
result = swapipy.ShowNamedView(oShowNamedViewInVo)
printResult("swapipy.ShowNamedView", result)

# endregion

# region 16.保存工程
print("16.保存工程")
from swapilib.bu.file.vo import SaveDocInVo
from swapilib.bu.file.vo import ExportDocInVo

# 16.1.保存工程
oSaveDocInVo = SaveDocInVo()
result = swapipy.SaveDoc(oSaveDocInVo)
printResult("swapipy.SaveDoc", result)

# 16.2.导出工程-dxf
oExportDocInVo = ExportDocInVo()
oExportDocInVo.ExportFileType = 1 #可选值:1-dxf，2-svg，3-igs
result = swapipy.ExportDoc(oExportDocInVo)
printResult("swapipy.ExportDoc", result)

# endregion

# 等待退出
input("按 Enter 键退出")