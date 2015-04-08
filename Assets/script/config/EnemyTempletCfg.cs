
using UnityEngine;
#if NETFX_CORE &&　UNITY_METRO && !UNITY_EDITOR 
//using WinRTLegacy.Xml;
using System.Xml;
//using WinRTLegacy.Xml;
#else
using System.Xml;

//using System.Xml;
#endif
using System.Collections.Generic;

public class EnemyTempletCfg
{
    /**
     * 配置文件名
     */
    private const string fileName = "/enemy.xml";
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

    private Dictionary<int, EnemyTemplet> data = new Dictionary<int, EnemyTemplet>();
    private static EnemyTempletCfg m_instance = null;

    private EnemyTempletCfg()
    {
        init();
    }
    public static EnemyTempletCfg getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new EnemyTempletCfg();
        }
        return m_instance;
    }

    private void init()
    {
        
        parseXml();


    }
    private void parseXml()
    {
        XmlReader reader = null;
        try
        {
            reader = XmlReader.Create(filePath);
            while (reader.ReadToFollowing("enemy"))
            {
                EnemyTemplet t = new EnemyTemplet();
                reader.ReadToFollowing("id");
                t.Id = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("name");
                t.Name = reader.ReadElementContentAsString();
                reader.ReadToFollowing("hp");
                t.Hp = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("prefab");
                t.Prefab = reader.ReadElementContentAsString();
                
                reader.ReadToFollowing("attackDamage");
                t.AttackDamage = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("speed");
                t.Speed = reader.ReadElementContentAsFloat();
                reader.ReadToFollowing("score");
                t.Score = reader.ReadElementContentAsInt();
                data.Add(t.Id, t);
            }
        }
        finally
        {
           // if (reader != null)
               // reader.Close();
        }


    }

    public EnemyTemplet get(int id)
    {
        return data[id];
    }


}