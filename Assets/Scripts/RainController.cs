using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField]
    private GameObject rainPrefab;

    private void OnTriggerEnter(Collider other)
    {
        rainPrefab.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        rainPrefab.SetActive(true);
    }

}
