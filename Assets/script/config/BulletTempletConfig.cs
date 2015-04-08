using UnityEngine;
//using System.Collections;
#if NETFX_CORE &&　UNITY_METRO && !UNITY_EDITOR 
//using WinRTLegacy.Xml;
using System.Xml;
//using WinRTLegacy.Xml;
#else
using System.Xml;

//using System.Xml;
#endif
using System.Collections.Generic;

public class BulletTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/arrow.xml";
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

    private Dictionary<int, BulletTemplet> data = new Dictionary<int, BulletTemplet>();
    private static BulletTempletConfig m_instance = null;

    private BulletTempletConfig()
    {
        init();
    }
    public static BulletTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new BulletTempletConfig();
        }
        return m_instance;
    }

    public void init()
    {
        
        parseXml();    

    }

    private void parseXml()
    {
        XmlReader reader=null;
         try
        {
            reader = XmlReader.Create(filePath);
            while (reader.ReadToFollowing("arrow"))
            {
                BulletTemplet t = new BulletTemplet();
                reader.ReadToFollowing("id");
                t.Id =  reader.ReadElementContentAsInt();
                reader.ReadToFollowing("name");
                t.Name = reader.ReadElementContentAsString();
                reader.ReadToFollowing("prefab");
                t.Prefab = reader.ReadElementContentAsString();
                reader.ReadToFollowing("damage");
                t.Damage = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("speed");
                t.Speed = reader.ReadElementContentAsInt();
                data.Add(t.Id, t);
            }
        }
        finally
        {
            //if (reader != null)
              //  reader.Close();
        }

        }

    public BulletTemplet get(int id)
    {
        return data[id];
    }

    }


