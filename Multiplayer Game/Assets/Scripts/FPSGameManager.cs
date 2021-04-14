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
        StartCoroutine(TimeStart());
        Timer();

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
    IEnumerator TimeStart() {
        yield return new WaitForSeconds(10f);
        
    }
    #endregion

    #region GameOver

    private IEnumerator Timer()
    {
         timer = startTime;
        do
        {
            timer -= Time.deltaTime;
            
            int min =(int)(timer/60)%60 ;
            int sec = (int)(timer%60);

            TimeText.text = "00:00";
            if (min > 0)
            {
                TimeText.text += min + ":";
            }
            if (min > 0)
            {
                TimeText.text += sec;
            }

            yield return null;
        }
        while (timer > 0);
    }

    #endregion
}
