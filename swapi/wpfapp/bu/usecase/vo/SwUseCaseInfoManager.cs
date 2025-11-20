using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfapp.basic.io;
using wpfapp.bu.cmd.cmdtype;

namespace wpfapp.bu.usecase.vo
{
    /// <summary>
    /// 用例管理器
    /// </summary>
    public class SwUseCaseInfoManager
    {
        #region Fields

        private static SwUseCaseInfoManager _inst = null;

        private List<SwUseCaseInfo> useCaseInfoList = new List<SwUseCaseInfo>();

        #endregion

        #region Construction

        public SwUseCaseInfoManager()
        {
            this.loadFromFile();
        }

        public static SwUseCaseInfoManager getInstance()
        {
            if(_inst == null)
            {
                _inst = new SwUseCaseInfoManager();
            }
            return _inst;
        }

        #endregion

        #region 增删查改

        public List<SwUseCaseInfo> getAll()
        {
            return useCaseInfoList;
        }

        public SwUseCaseInfo getById(string id)
        {
            for(int i = 0; i < useCaseInfoList.Count; i++)
            {
                SwUseCaseInfo oSwUseCaseInfo = useCaseInfoList[i];
                if (oSwUseCaseInfo.Id.Equals(id))
                {
                    return oSwUseCaseInfo;
                }
            }
            return null;
        }

        public void add(SwUseCaseInfo oSwUseCaseInfo)
        {
            oSwUseCaseInfo.Id = Guid.NewGuid().ToString();
            useCaseInfoList.Add(oSwUseCaseInfo);
        }

        public bool remove(SwUseCaseInfo oSwUseCaseInfo)
        {
            return useCaseInfoList.Remove(oSwUseCaseInfo);
        }

        public bool removeById(string id)
        {
            for (int i = 0; i < useCaseInfoList.Count; i++)
            {
                SwUseCaseInfo oSwUseCaseInfo = useCaseInfoList[i];
                if (oSwUseCaseInfo.Id.Equals(id))
                {
                    useCaseInfoList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void removeAll()
        {
            useCaseInfoList.Clear();
        }

        public bool update(SwUseCaseInfo oUpdateUseCaseInfo)
        {
            if(string.IsNullOrEmpty(oUpdateUseCaseInfo.Id))
            {
                return false;
            }
            for (int i = 0; i < useCaseInfoList.Count; i++)
            {
                SwUseCaseInfo oSwUseCaseInfo = useCaseInfoList[i];
                if (oSwUseCaseInfo.Id.Equals(oUpdateUseCaseInfo.Id))
                {
                    useCaseInfoList.RemoveAt(i);
                    useCaseInfoList.Insert(i, oUpdateUseCaseInfo);
                    return true;
                }
            }
            return false;
        }

        public bool copy(string id)
        {
            for (int i = 0; i < useCaseInfoList.Count; i++)
            {
                SwUseCaseInfo oSwUseCaseInfo = useCaseInfoList[i];
                if (oSwUseCaseInfo.Id.Equals(id))
                {
                    SwUseCaseInfo oNewUseCaseInfo = new SwUseCaseInfo(oSwUseCaseInfo);
                    oNewUseCaseInfo.Id = Guid.NewGuid().ToString();
                    oNewUseCaseInfo.Name = oNewUseCaseInfo.Name + "_copy";
                    useCaseInfoList.Insert(i + 1, oNewUseCaseInfo);
                    return true;
                }
            }
            return false;
        }

        public bool moveUpDownUseCase(string id, bool bMoveDown)
        {
            for (int i = 0; i < useCaseInfoList.Count; i++)
            {
                SwUseCaseInfo oSwUseCaseInfo = useCaseInfoList[i];
                if (oSwUseCaseInfo.Id.Equals(id))
                {
                    if(bMoveDown)
                    {
                        // 下移
                        if(i < useCaseInfoList.Count - 1)
                        {
                            useCaseInfoList.RemoveAt(i);
                            useCaseInfoList.Insert(i + 1, oSwUseCaseInfo);
                            return true;
                        }
                    }
                    else
                    {
                        // 上移
                        if(i > 0)
                        {
                            useCaseInfoList.RemoveAt(i);
                            useCaseInfoList.Insert(i-1, oSwUseCaseInfo);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        #endregion

        #region 文件存储

        private string getFilePath()
        {
            return PathUtilsEx.GetRelativeToAssemblyPath("res/usecase.json");
        }

        public void loadFromFile()
        {
            useCaseInfoList = JsonFileUtilsEx.ReadFromJsonFile<List<SwUseCaseInfo>>(getFilePath());
            if(useCaseInfoList == null)
            {
                useCaseInfoList = new List<SwUseCaseInfo>();
            }
        }

        //public void solveTypeId()
        //{
        //    foreach (SwUseCaseInfo oSwUseCaseInfo in useCaseInfoList)
        //    {
        //        foreach (SwUseCaseStepInfo oSwUseCaseStepInfo in oSwUseCaseInfo.Steps)
        //        {
        //            foreach (SwUseCaseStepCmdInfo oSwUseCaseStepCmdInfo in oSwUseCaseStepInfo.CmdInfos)
        //            {
        //                SwCmdType oSwCmdType = SwCmdTypeManager.getInstance().getByTypeId(oSwUseCaseStepCmdInfo.CmdModule, oSwUseCaseStepCmdInfo.CmdTypeId);
        //                oSwUseCaseStepCmdInfo.CmdTypeIdStr = oSwCmdType.CmdTypeIdStr;
        //            }
        //        }
        //    }
        //}

        public void saveToFile()
        {
            JsonFileUtilsEx.WriteToJsonFile<List<SwUseCaseInfo>>(getFilePath(), useCaseInfoList);
        }

        #endregion
    }
}
