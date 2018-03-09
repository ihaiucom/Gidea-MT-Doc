using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generate
{
    class Program
    {
        static void Main(string[] args)
        {
            string iosRoot = "../../../../../gametm-ios/";
            string webRoot = "../../../../";

            if(args.Length == 2)
            {
                iosRoot = "../gametm-ios";
                webRoot = "./";
            }
            else
            {
                string setting = "generate_setting.txt";
                //setting = "../../../../" + setting;
                Dictionary<string, string> settingDict = new Dictionary<string, string>();
                if (File.Exists(setting))
                {
                    string[] lines =File.ReadAllLines(setting);
                    foreach(string line in lines)
                    {
                        string[] arr = line.Split('=');
                        if(arr.Length == 2)
                        {
                            string key = arr[0].Trim();
                            string val = arr[1].Trim();
                            settingDict[key] = val;
                        }
                    }
                }

                if (settingDict.ContainsKey("iosRoot"))
                    iosRoot = settingDict["iosRoot"];

                if (settingDict.ContainsKey("webRoot"))
                    webRoot = settingDict["webRoot"];

            }

            string tmpRoot = webRoot + "tmp/";

            Console.WriteLine("iosRoot=" + iosRoot);
            Console.WriteLine("webRoot=" + webRoot);

            if(!Directory.Exists(iosRoot))
            {
                Console.WriteLine("[Error] 不存在该目录: iosRoot=" + iosRoot);
                Console.ReadLine();
                return;
            }

            if (!Directory.Exists(webRoot))
            {
                Console.WriteLine("[Error] 不存在该目录: webRoot=" + webRoot);
                Console.ReadLine();
                return;
            }

            StringWriter indexSW = new StringWriter();


            string indexItemTmp = File.ReadAllText(tmpRoot + "index_item.html.tmp");
            string plistTmp = File.ReadAllText(tmpRoot + "ipa.plist.tmp");

            string[] fileList = Directory.GetFiles(iosRoot, "*.ipa", SearchOption.AllDirectories);
            for(int i = 0; i < fileList.Length; i ++)
            {
                string ipaName = fileList[i].Replace(iosRoot, "").Replace("\\", "/");
                string ipaPlistName = ipaName.Replace("/", "_").Replace("\\", "") + ".plist";

                indexSW.WriteLine(indexItemTmp.Replace("__IPA_NAME__", ipaName).Replace("__IPA_PLIST__", ipaPlistName));
                indexSW.WriteLine("\n");

                File.WriteAllText(webRoot + ipaPlistName, plistTmp.Replace("__IPD__NAME__", ipaName));
                Console.WriteLine(i + "\n" + ipaName);
            }

            string indexContent = File.ReadAllText(tmpRoot + "index.html.tmp");
            indexContent = indexContent.Replace("__LIST__", indexSW.ToString());
            File.WriteAllText(webRoot + "index.html", indexContent);



        }
    }
}
