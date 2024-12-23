using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class RunMediaPipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            Process psi = new Process();

            // 환경 지정
            psi.StartInfo.FileName = "C:/Users/user/anaconda3/python.exe";
            // 파일 지정
            psi.StartInfo.Arguments = "D:/KHU/2024 - 02/Projects/UDPsend.py";

            psi.StartInfo.CreateNoWindow = true;
            psi.StartInfo.UseShellExecute = false;

            psi.Start();

            UnityEngine.Debug.Log("[알림] .py file 실행");
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("[알림] 에러발생: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
