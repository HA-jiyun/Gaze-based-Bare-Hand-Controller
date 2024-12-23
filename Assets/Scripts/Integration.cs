using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using Tobii.GameIntegration.Net;

public class Integration : MonoBehaviour
{
    GazePoint gazeP_sn; // scale normalized gaze Point (-1, 0)
    public static GazePoint gazeP_n; // normalized gaze Point (0, 1)
    public GameObject gazeArea;
    public static Vector3 gazeArea_vec;

    public float filterFrequency = 120.0f;
    OneEuroFilter<Vector3> vector3Filter;

    // WindowConsoleHandle
    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    void Start()
    {
        gazeArea = Instantiate(gazeArea, new Vector3(0,0,0), Quaternion.identity);
        vector3Filter = new OneEuroFilter<Vector3>(filterFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        TobiiGameIntegrationApi.Update();
        IntPtr handle = GetForegroundWindow();
        TobiiGameIntegrationApi.TrackWindow(handle);
        TobiiGameIntegrationApi.UpdateTrackerInfos();


        TobiiGameIntegrationApi.TryGetLatestGazePoint(out gazeP_sn);
        gazeP_n.X = (gazeP_sn.X + 1) / 2;
        gazeP_n.Y = (gazeP_sn.Y + 1) / 2;

        Vector3 gazeScreen = Camera.main.ViewportToScreenPoint(new Vector3(gazeP_n.X, gazeP_n.Y, 0));

        vector3Filter.UpdateParams(filterFrequency);
        Vector3 gazeFiltered = vector3Filter.Filter(gazeScreen);
        Vector3 gazeWorld = Camera.main.ScreenToWorldPoint(new Vector3(gazeFiltered.x, gazeFiltered.y, 10.0f));

        gazeArea.transform.position = gazeWorld;
        gazeArea_vec = gazeWorld;

        Quaternion rot = Quaternion.LookRotation(CursorController.rayDir.normalized);
        gazeArea.transform.rotation = rot;
    }
}

