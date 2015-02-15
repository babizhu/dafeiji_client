using UnityEngine;
using System.Collections;

public class Pause
{

    public static int timeScale =1;
    public bool click(GameObject prevChoose)
    {
        if (timeScale == 0)
        {
            timeScale = 1;

        }
        else
        {
            timeScale = 0;
        }
        Time.timeScale = timeScale;
        
        return false;
    }

    public static bool IS_PAUSE()
    {
        return (timeScale == 0);
    }

    public void unClick()
    {
        
    }

    
}
