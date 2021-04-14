using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject grapics;

    private void Awake()
    {
        grapics.SetActive(false);
    }
}
