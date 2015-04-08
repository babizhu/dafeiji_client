using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
   
    //public float xUnit = 0.6f;//x轴上的偏移,一波在某行出现多个怪，未避免重叠，x轴上做一定的偏移
    //public float rowHeight = 0.75f;//行高
    public Vector2 origin;//场景出怪的坐标原点，比如第四排就是坐标原点的y轴加上4个单位的rowHeight
    

    private MissionTemplet missionTemplet;
    
    //private ScrollBar monsterBar;


	// Use this for initialization
	void Start () {
        GameCamera gc = Camera.main.GetComponent<GameCamera>();
        origin = new Vector2(0, gc.top);
        //print("等待出怪");
        
        
        StartCoroutine( spawn() );
        
	}


    IEnumerator spawn()
    {
        
        //获取玩家当前的关卡模板
        missionTemplet = MissionTempletConfig.getInstance().get(1);
        print("当前关卡id为" + 1);
        //int totalSecond = 0;
        //计算总共需要的秒数
        

        foreach (WaveTemplet wt in missionTemplet.Waves)
        {
            //print(totalSecond);
            //print( )
            yield return new WaitForSeconds(wt.DelaySecond);
            
            
            
            spawnWave( wt );
        }


        print("敌人生成完毕");
    }


    private void spawnWave(WaveTemplet wt)
    {
        //int[] xOffset = new int[5];//记录各行怪物在x轴出现的次数
        
        foreach (EnemyWithPosition mp in wt.EnemyList)
        {
            EnemyTemplet t = mp.EnemyTemplet;
            //print(t.Name + "(" + t.Id + ") : row=" + mp.Row + " y=" + origin.y + mp.Row * rowHeight + " hp=" + t.Hp);
            
            Vector3 pos = new Vector3(mp.X,origin.y + mp.Y ,0);

            AbstractEnemy enemy = (Instantiate(Resources.Load("enemy/"+t.Prefab), pos, Quaternion.identity) as GameObject).GetComponent<AbstractEnemy>();
            enemy.applyTemplet(t);
            
        }


    }

    /**
     * 切换胜利场景
     */
    private IEnumerator loadWinScene()
    {
        //print(1111111111);
        yield return new WaitForSeconds(1.5f);
        Application.LoadLevel("win");
        //print(222222222222);
    }
}
