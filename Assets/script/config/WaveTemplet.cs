using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




public class WaveTemplet
{
    /**
     * 怪物出来的延迟秒数
     */
    private int delaySecond;
    private List<EnemyWithPosition> enemyList = new List<EnemyWithPosition>();


    public int DelaySecond
    {
        get { return delaySecond; }
        set { delaySecond = value; }
    }

    public List<EnemyWithPosition> EnemyList
    {
        set { enemyList = value; }
        get { return enemyList; }
    }
    public override string ToString()
    {
        string result = "[delaySecond=" + delaySecond + ",monsterList=[";
        foreach (EnemyWithPosition ewp in enemyList)
        {
            result += ewp.ToString()+",";
        }
        result += "]";

        result += "]";
        return result;
    }
}

