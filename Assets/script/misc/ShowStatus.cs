﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;

/**
 * 显示当前帧数
 */
public class ShowStatus : MonoBehaviour {

    public float f_UpdateInterval = 0.5F;

    private float f_LastInterval;

    private int i_Frames = 0;

    private float f_Fps;

    

    void Start()
    {
        //Application.targetFrameRate=60;

        f_LastInterval = Time.realtimeSinceStartup;
        i_Frames = 0;

        
    }

    void OnGUI()
    {
        //GameCamera gc = Camera.main.GetComponent<GameCamera>();
        GUI.Label(new Rect(5, 0, 100, 100), "FPS:" + f_Fps.ToString("f2"));
        //GUI.Label(new Rect(5, 20, 500, 100), "width:" + Screen.width + ",height:" + Screen.height);
       // GUI.Label(new Rect(5, 40, 500, 100), "realDevHeight=" + gc.realDevHeight + ",devWidth=" + gc.realDevWidth);
       // GUI.Label(new Rect(5, 60, 500, 100), "aspec:" + gc.realDevWidth/gc.realDevHeight);
       
        
    }

    void Update()
    {
        ++i_Frames;

        if (Time.realtimeSinceStartup > f_LastInterval + f_UpdateInterval)
        {
            f_Fps = i_Frames / (Time.realtimeSinceStartup - f_LastInterval);

            i_Frames = 0;

            f_LastInterval = Time.realtimeSinceStartup;
        }
    }

}
