using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using System.Threading; 
using System.Windows;

namespace MachineVision.Extensions
{
    public static class LanguageHelper
    {
        public static string AppCurrentLanguage { get; set; }

        public static Dictionary<string, string> KeyValues { get; set; }

        public static void SetLanguage(string key)
        {
            //在资源文件中找到Assets中写好的资源字典
            var resource = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(t => t.Source != null &&
                 t.Source.OriginalString != null &&
                 t.Source.OriginalString.Contains(key));
            //找到了就把他删除重新添加变为置顶文件
            if (resource != null)
                Application.Current.Resources.MergedDictionaries.Remove(resource);

            Application.Current.Resources.MergedDictionaries.Add(resource);

            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            //遍历语言资源文件中所有的key和对应的 value加入到字典中让后续语言刷新进行替换
            foreach (DictionaryEntry item in resource)
                keyValues.Add(item.Key.ToString(), item.Value.ToString());

            AppCurrentLanguage = key;
            KeyValues = keyValues;

            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(key);
        }
    }
}
