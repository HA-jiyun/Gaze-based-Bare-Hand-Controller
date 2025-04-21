using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionFilter : MonoBehaviour
{
    public Material occlusionMaterial;
    public Material originalMaterial;

    private void OnTriggerEnter(Collider other)
    {
        Renderer otherRenderer = other.GetComponent<Renderer>();
        if (otherRenderer != null)
            otherRenderer.material = occlusionMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        Renderer otherRenderer = other.GetComponent<Renderer>();
        if (otherRenderer != null)
            otherRenderer.material = originalMaterial;
    }
}
