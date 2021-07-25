using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class RemainingCoinViewer : MonoBehaviour
{
    [SerializeField] private CoinsSpawner coinsSpawner;
    [SerializeField] private Text remainingCoinInfo;
    [SerializeField] private UnityEvent gameClearEvent = new UnityEvent();

    private bool nowPlaying = true;
    private int remainingCoins;


    private void Update()
    { 
        remainingCoins = coinsSpawner.GetNumberOfCoins();
        remainingCoinInfo.text = "残りコイン" + remainingCoins.ToString() + "個";

        if (nowPlaying && remainingCoins == 0)
        {
            gameClearEvent.Invoke();
            nowPlaying = false;
        }
    }
}
