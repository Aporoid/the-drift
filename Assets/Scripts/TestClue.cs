using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClue : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        meshRenderer.enabled = true;
    }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}
