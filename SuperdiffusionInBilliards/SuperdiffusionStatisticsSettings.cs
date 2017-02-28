using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace SuperdiffusionInBilliards
{
    public class SuperdiffusionStatisticsSettings
    {
        private const string SETTINGS_FILE_NAME = "StatisticFormSettings.xml";
        private const string NAME = "name";

        private Dictionary<String, String> map = new Dictionary<String, String>();

        public Dictionary<String, String> Map
        {
            get
            {
                return map;
            }
        }

        private static Dictionary<SuperdiffusionStatisticsModes, SuperdiffusionStatisticsSettings> settingsByMode = new Dictionary<SuperdiffusionStatisticsModes, SuperdiffusionStatisticsSettings>();

        public static Dictionary<SuperdiffusionStatisticsModes, SuperdiffusionStatisticsSettings> SettingsByMode
        {
            get
            {
                return settingsByMode;
            }
        }

        static SuperdiffusionStatisticsSettings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(SETTINGS_FILE_NAME);
            XmlElement modesNode = doc.DocumentElement;
            foreach (XmlNode modeNode in modesNode)
            {
                SuperdiffusionStatisticsSettings set = new SuperdiffusionStatisticsSettings();
                XmlNode nameNode = modeNode.Attributes.GetNamedItem(NAME);
                SuperdiffusionStatisticsModes mode = (SuperdiffusionStatisticsModes)Enum.Parse(typeof(SuperdiffusionStatisticsModes), nameNode.InnerText);
                foreach (XmlNode settingNode in modeNode.ChildNodes)
                {
                    set.map.Add(settingNode.Name, settingNode.InnerText);
                }
                settingsByMode.Add(mode, set);
            }

        }

    }
}
