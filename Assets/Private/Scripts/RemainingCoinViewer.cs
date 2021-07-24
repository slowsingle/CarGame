using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingCoinViewer : MonoBehaviour
{
    [SerializeField] private CoinsSpawner coinsSpawner;
    [SerializeField] private Text remainingCoinInfo;

    private int remainingCoins;


    private void Update()
    { 
        remainingCoins = coinsSpawner.GetNumberOfCoins();
        remainingCoinInfo.text = "残りコイン" + remainingCoins.ToString() + "個";
    }
}
