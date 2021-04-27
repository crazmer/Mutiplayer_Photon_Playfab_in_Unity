using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class FPSGameManager : MonoBehaviour
{
    public float startTime = 120;
    public static FPSGameManager Instance;
    public TMP_Text TimeText;
    SpawnPoint[] spawnPoints;
    [SerializeField] GameObject playerPrefab;
    float timer = 0;
    private void Awake()
    {
        Instance = this;
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }
    #region Spawnner
    void Start()
    {
       
        

        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (playerPrefab != null)
            {

                GetSpawnpoint();
                Spawnner();

            }
            else
            {
                Debug.Log("Player prefab is not set");
            }
        }
    }
    public Transform GetSpawnpoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
        
    }

    public void Spawnner()
    {
        Transform spawnpoint = GetSpawnpoint();
        PhotonNetwork.Instantiate(playerPrefab.name,spawnpoint.position, spawnpoint.rotation);
    }
    
    #endregion

}
