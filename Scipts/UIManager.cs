using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public GameObject startGame;
    public GameObject mainUI;
    public GameObject congratulationsUI;

    public void SetScoreText(string txt)
    {
        if (scoreText)
            scoreText.text = txt;
    }

    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
            gameoverPanel.SetActive(isShow);
    }
    public void ShowstartGame(bool isShow)
    {
        if (startGame)
            startGame.SetActive(isShow);
    }
    public void ShowMainUI(bool isShow)
    {
        if (mainUI)
            mainUI.SetActive(isShow);
    }    
    public void ShowCongratulationsUI(bool isShow)
    {
        if (congratulationsUI)
            congratulationsUI.SetActive(isShow);
    }    
}
