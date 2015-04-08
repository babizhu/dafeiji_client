using UnityEngine;
#if NETFX_CORE &&　UNITY_METRO && !UNITY_EDITOR 
using WinRTLegacy.Xml;
//using WinRTLegacy.Xml;
#else
using System.Xml;

//using System.Xml;
#endif
using System.Collections.Generic;

public class MissionTempletConfig {
    /**
     * 配置文件名
     */
    private const string fileName = "/mission.xml";
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

    private Dictionary<int, MissionTemplet> data = new Dictionary<int, MissionTemplet>();
    private static MissionTempletConfig m_instance = null;

    private int maxId = 0;

    private MissionTempletConfig()
    {
        init();
    }
    public static MissionTempletConfig getInstance()
    {
        if (m_instance == null)
        {
            m_instance = new MissionTempletConfig();
        }
        return m_instance;
    }

    public void init()
    {
        
        parseXml();
        Debug.Log("mission map 的尺寸是" + data.Count);

    }

    private void parseXml()
    {
        /**
        XmlReader reader = null;
        try
        {
            reader = XmlReader.Create(filePath);
            while (reader.ReadToFollowing("mission"))
            {
                MissionTemplet t = new MissionTemplet();
                reader.ReadToFollowing("id");
                t.Id = reader.ReadElementContentAsInt();
                reader.ReadToFollowing("name");
                t.Name = reader.ReadElementContentAsString();
               // while (reader.ReadToFollowing("wave"))
                {
                    //t.Waves.Add(parseWave(reader.ReadSubtree()));
                }
               
                data.Add(t.Id, t);
                Debug.Log(t.Name);
            }
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
        */
        XmlReader reader = null;
        //int i = 1;
        try
        {
            reader = XmlReader.Create(filePath);
            while (reader.ReadToFollowing("mission"))
            {
                //Debug.Log("mission" + i++);
                XmlReader missionReader = reader.ReadSubtree();
                MissionTemplet t = new MissionTemplet();
                missionReader.ReadToFollowing("id");
                t.Id = missionReader.ReadElementContentAsInt();
                missionReader.ReadToFollowing("name");
                t.Name = missionReader.ReadElementContentAsString();
                while (missionReader.ReadToFollowing("wave"))
                {                    
                    t.Waves.Add(parseWave(missionReader.ReadSubtree()));
                }
                if (t.Id > maxId)
                {
                    maxId = t.Id;
                }
                data.Add(t.Id, t);
                Debug.Log("MissionTemplet =" + t);
            }
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
        
    }

    private WaveTemplet parseWave(XmlReader reader)
    {
        
        WaveTemplet waveTemplet = new WaveTemplet();
        
            
            reader.ReadToFollowing("delaySecond");
            waveTemplet.DelaySecond = reader.ReadElementContentAsInt();
            
            while(reader.ReadToFollowing("enemy")){
                string[] arr = reader.ReadElementContentAsString().Split(',');
                int enemyId = int.Parse(arr[0]);
                float x = float.Parse(arr[1]);
                float y = float.Parse(arr[2]);
                EnemyWithPosition ewp = new EnemyWithPosition();
                ewp.EnemyTemplet = EnemyTempletCfg.getInstance().get(enemyId);
                ewp.X = x;
                ewp.Y = y;
                waveTemplet.EnemyList.Add(ewp);
                
            }
            //Debug.Log("waveTemplet = " + waveTemplet);
        return waveTemplet;
    }



    public MissionTemplet get(int id)
    {
        
        return data[id];
    }

    public int getMaxId()
    {
        return maxId;
    }

}
