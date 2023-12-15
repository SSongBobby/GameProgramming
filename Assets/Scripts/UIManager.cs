using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public ScoreManager scoreMng;
    public GameObject scoreTextUI;
    public Text scoreText;
    public GameObject pauseUI;

    void Start()
    {
        // 만약 UI Text 객체가 설정되어 있지 않다면 찾아서 연결
        if (scoreText == null)
        {
            scoreText = scoreTextUI.GetComponent<Text>();
        }

        // 초기화된 점수를 UI Text로 표시
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // UI Text를 업데이트하여 현재 점수를 표시
        scoreText.text = scoreMng.amount.ToString();
    }

    public void HideUI()
    {
        pauseUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    
    public void GameEnd()
    {
        Application.Quit();
    }
}
