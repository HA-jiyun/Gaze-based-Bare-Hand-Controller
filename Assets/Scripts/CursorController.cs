using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    public GameObject handCursor;
    Vector3 standardVec;
    Vector3 dir;
    public static Vector3 rayDir;

    public Material[] highlight = new Material[3];
    Transform selected;

    void Start()
    {
        handCursor = Instantiate(handCursor, transform);
        standardVec = new Vector3(HandTracking.landmarkZero.x,
                                  HandTracking.landmarkZero.y,
                                  HandTracking.avgAngle / 90 * 3 - 1.5f);
    }

    void Update()
    {
        transform.position = Integration.gazeArea_vec;

        dir = handCursor.transform.position - Camera.main.transform.position;
        Quaternion rot = Quaternion.LookRotation(dir.normalized);
        transform.rotation = rot;
        
        if (Vector3.Distance(handCursor.transform.position, Integration.gazeArea_vec) < 2.0f)
        {
            float newX = HandTracking.landmarkZero.x - standardVec.x;
            float newY = HandTracking.landmarkZero.y - standardVec.y;
            handCursor.transform.localPosition = new Vector3(newX, newY,
                                                            HandTracking.avgAngle / 90 * 3 - 1.5f);
        }
        else
        {
            handCursor.transform.localPosition = new(0,0,0);
            standardVec = new Vector3(HandTracking.landmarkZero.x,
                                      HandTracking.landmarkZero.y,
                                      HandTracking.avgAngle / 90 * 3 - 1.5f);
        }
    }

    
    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(handCursor.transform.position);
        Ray ray = Camera.main.ScreenPointToRay(pos);
        RaycastHit hit;
        float MaxDistance = 50.0f;

        Debug.DrawRay(handCursor.transform.position, ray.direction * 50.0f, Color.green, 0.05f);
        rayDir = ray.direction;

        if (Physics.Raycast(handCursor.transform.position, ray.direction, out hit, MaxDistance))
        {
            Transform selectedObj = hit.transform;
            if (HandTracking.pinch == true)
                confirmHighlight(selectedObj);
            else
                addHighlight(selectedObj);
        }
        else
        {
            clearHighlight();
        }
    }

    void addHighlight(Transform obj)
    {
        if (obj == null) return;

        clearHighlight();
        selected = obj;
        obj.GetComponent<MeshRenderer>().material = highlight[1];
    }
    void clearHighlight()
    {
        if (selected == null) return;

        selected.GetComponent<MeshRenderer>().material = highlight[0];
        selected = null;
    }
    void confirmHighlight(Transform obj)
    {
        if (obj == null) return;

        clearHighlight();
        selected = obj;
        obj.GetComponent<MeshRenderer>().material = highlight[2];
    }
    
}
