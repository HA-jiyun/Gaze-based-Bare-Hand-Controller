using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    public static Vector3 landmarkZero;
    public static float avgAngle;
    public static bool pinch;

    int[] a = new int[] { 0, 9, 10, 11, 0, 13, 14, 15, 0, 17, 18, 19 };
    int[] b = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        List<Vector3> angleLandmarks = new();
        List<float> angles = new();

        data = data.Remove(0, 1);
        data = data.Remove(data.Length - 1, 1);
        string[] points = data.Split(',');

        //0        1*3      2*3
        //x1,y1,z1,x2,y2,z2,x3,y3,z3

        for (int i = 0; i < 21; i++)
        {

            float x = 7 - float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
            angleLandmarks.Add(new Vector3(x, y, z));
        }

        // avoid outofrange
        for (int i = 0; i < 3; i++)
        {
            addAngle(angleLandmarks, i, angles);
        }
        for (int i = 4; i < 7; i++)
        {
            addAngle(angleLandmarks, i, angles);
        }
        for (int i = 8; i < 11; i++)
        {
            addAngle(angleLandmarks, i, angles);
        }

        avgAngle = calculateAvg(angles);
        landmarkZero = handPoints[0].GetComponent<Transform>().position;
        pinch = pinchConfirm(handPoints[4].transform.localPosition, handPoints[8].transform.localPosition);

    }

    void addAngle(List<Vector3> angleLm, int idx, List<float> anglesList)
    {
        Vector3 vec1 = Vector3.Normalize(angleLm[a[idx]] - angleLm[b[idx]]);
        Vector3 vec2 = Vector3.Normalize(angleLm[a[idx + 1]] - angleLm[b[idx + 1]]);
        float angle = Mathf.Acos(Vector3.Dot(vec1, vec2)) * Mathf.Rad2Deg;
        anglesList.Add(angle);
    }

    float calculateAvg(List<float> anglesList)
    {
        float avg = 0;
        for (int i = 0; i < anglesList.Count; i++)
        {
            avg += anglesList[i];
        }
        avg /= anglesList.Count;
        return avg;
    }

    bool pinchConfirm(Vector3 landmark4, Vector3 landmark8)
    {
        float disX = Mathf.Abs(landmark4.x - landmark8.x);
        float disY = Mathf.Abs(landmark4.y - landmark8.y);
        if (disX <= 0.2 && disY <= 0.2)
            return true;
        else
            return false;
    }
}