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

            // ȯ�� ����
            psi.StartInfo.FileName = "C:/Users/user/anaconda3/python.exe";
            // ���� ����
            psi.StartInfo.Arguments = "D:/KHU/2024 - 02/Projects/UDPsend.py";

            psi.StartInfo.CreateNoWindow = true;
            psi.StartInfo.UseShellExecute = false;

            psi.Start();

            UnityEngine.Debug.Log("[�˸�] .py file ����");
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("[�˸�] �����߻�: " + e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
