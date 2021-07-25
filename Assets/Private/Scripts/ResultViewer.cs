using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultViewer : MonoBehaviour
{
    [SerializeField] private Text resultText;

    private void Start()
    {
        gameObject.SetActive(false);
    }


    public void GameClear()
    {
        // ゲーム終了画面がアクティブな場合は何もしない
        if (gameObject.activeSelf) return;

        gameObject.SetActive(true);
        resultText.color = Color.blue;
        resultText.text = "GAME CLEAR!";
    }

    public void GameOver()
    {
        // ゲーム終了画面がアクティブな場合は何もしない
        if (gameObject.activeSelf) return;

        gameObject.SetActive(true);
        resultText.color = Color.red;
        resultText.text = "GAME OVER!";
    }
}
