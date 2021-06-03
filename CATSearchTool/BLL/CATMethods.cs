using CATSearchTool.UI;
using INFITF;
using PLMAccessIDLItf;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace CATSearchTool.BLL
{
    public static class CATMethods
    {
        private static bool GetUniqueCATProcess()
        {
            System.Diagnostics.Process[] processes = 
                System.Diagnostics.Process.GetProcesses();

            int count = 0;
            bool onlyOne = true;
            foreach (System.Diagnostics.Process proc in processes)
            {
                if (proc.ProcessName == "CNEXT" || proc.ProcessName == "3DEXPERIENCE")
                {
                    count++;
                    if (count > 1) { onlyOne = false; break; }
                }
            }
            return onlyOne;
        }
        private static INFITF.Application GetCatiaAPP()
        {
            INFITF.Application CATIA = null;
            if (GetUniqueCATProcess())
            {
                try
                {
                    CATIA = (INFITF.Application)Marshal.GetActiveObject("CATIA.Application");

                }
                catch
                {
                    Type oType = System.Type.GetTypeFromProgID("CATIA.Application");
                    CATIA = (INFITF.Application)Activator.CreateInstance(oType);
                    CATIA.Visible = true;
                }
                if (CATIA == null)
                {
                    MessageBox.Show("当前计算机未安装CATIA！", "错误");
                }
            }
            else
            {
                MessageBox.Show("当前有多个版本的CATIA在运行！","错误");
            }
            return CATIA;
        }

        public static bool Search(MainWindow mainwin)
        {
            try
            {
                if (GetCatiaAPP() != null)
                {
                    SearchService searchService = (SearchService)GetCatiaAPP().GetSessionService("Search");
                    DatabaseSearch databaseSearch = searchService.DatabaseSearch;
                    switch (mainwin.SearchKeyForBinding.Type)
                    {
                        case "物理产品":
                            databaseSearch.set_BaseType("VPMReference");
                            break;
                        case "图纸":
                            databaseSearch.set_BaseType("Drawing");
                            break;
                        case "3D形状":
                            databaseSearch.set_BaseType("VPMRepReference");
                            break;
                        case "工程模板":
                            databaseSearch.set_BaseType("PLMTemplateRepReference");
                            break;
                        case "场地":
                            databaseSearch.set_BaseType("AecSite");
                            break;
                        case "文件夹":
                            databaseSearch.set_BaseType("ENOFLD_FolderRootReference");
                            break;
                        case "目录":
                            databaseSearch.set_BaseType("ENOCLG_LibraryReference");
                            break;
                        case "章节":
                            databaseSearch.set_BaseType("ENOCLG_ClassReference");
                            break;
                        case "桥塔":
                            databaseSearch.set_BaseType("BridgeTower");
                            break;
                        case "桥塔节段":
                            databaseSearch.set_BaseType("BridgeTowerSegment");
                            break;
                        case "VPM文档":
                            databaseSearch.set_BaseType("PLMDMTDocument");
                            break;
                        default:
                            databaseSearch.set_BaseType("VPMReference");
                            break;
                    }
                    // Title or Name
                    if (mainwin.SearchKeyForBinding.Name != "")
                    {
                        switch (mainwin.SearchKeyForBinding.Type)
                        {
                            case "文件夹":
                                databaseSearch.AddEasyCriteria("name", mainwin.SearchKeyForBinding.Name);
                                break;
                            case "目录":
                                databaseSearch.AddEasyCriteria("name", mainwin.SearchKeyForBinding.Name);
                                break;
                            case "章节":
                                databaseSearch.AddEasyCriteria("name", mainwin.SearchKeyForBinding.Name);
                                break;
                            default:
                                databaseSearch.AddEasyCriteria("V_Name", mainwin.SearchKeyForBinding.Name);
                                break;
                        }
                    }
                    // Name
                    if (mainwin.SearchKeyForBinding.Id != "")
                    {
                        databaseSearch.AddEasyCriteria("PLM_ExternalID", mainwin.SearchKeyForBinding.Id);
                    }
                    // revision
                    if (mainwin.SearchKeyForBinding.Revision != "")
                    {
                        databaseSearch.AddEasyCriteria("revision", mainwin.SearchKeyForBinding.Revision);
                    }
                    searchService.Search();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
