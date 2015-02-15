using UnityEngine;
#if NETFX_CORE &&　UNITY_METRO && !UNITY_EDITOR 
using WinRTLegacy.Xml;
//using WinRTLegacy.Xml;
#else
using System.Xml;

//using System.Xml;
#endif
using System.Collections.Generic;

public class WeaponTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/weapon.xml";
#if UNITY_EDITOR

    string filePath = "file://" + UnityEngine.Application.streamingAssetsPath + fileName;
#elif UNITY_IPHONE
        string filePath = Application.dataPath +"/Raw"+fileName;
#elif UNITY_ANDROID
       //string filePath= "jar:file://" + Application.dataPath + "!/assets" + fileName;
    string filePath = Application.streamingAssetsPath + fileName;
#else
    string filePath = "Data/StreamingAssets" + fileName;
#endif

    private Dictionary<int, WeaponTemplet> data = new Dictionary<int, WeaponTemplet>();
    private static WeaponTempletConfig m_instance = null;

    private WeaponTempletConfig()
    {
        init();
    }
    public static WeaponTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new WeaponTempletConfig();
        }
        return m_instance;
    }

    public void init()
    {
        
        parseXml();    

    }

    private void parseXml()
    {

        XmlReader reader = null;
        try
        {
            reader = XmlReader.Create(filePath);
            while (reader.ReadToFollowing("weapon"))
            {
                
                WeaponTemplet t = new WeaponTemplet();
                reader.ReadToFollowing("id");
                t.Id = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("name");
                t.Name = reader.ReadElementContentAsString();
                  reader.ReadToFollowing("coolDown");
                t.CoolDown = reader.ReadElementContentAsFloat();
               
                data.Add(t.Id, t);
            }
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }




    




    public WeaponTemplet get(int id)
    {
        
        return data[id];
    }
	
}
