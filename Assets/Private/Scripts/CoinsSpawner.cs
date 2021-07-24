using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private List<Transform> spawnCenterList;

    private List<GameObject> coinsList = new List<GameObject>();

    private void Start()
    {
        foreach (Transform spawnCenter in spawnCenterList)
        {
            GameObject obj = Instantiate(coinPrefab, spawnCenter.position, Quaternion.identity);
            coinsList.Add(obj);
        }
    }


    public int GetNumberOfCoins()
    {
        int num = 0;
        foreach (GameObject coin in coinsList)
        {
            if (coin != null) num++;
        }

        return num;
    }
}