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
        // ���� UI Text ��ü�� �����Ǿ� ���� �ʴٸ� ã�Ƽ� ����
        if (scoreText == null)
        {
            scoreText = scoreTextUI.GetComponent<Text>();
        }

        // �ʱ�ȭ�� ������ UI Text�� ǥ��
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // UI Text�� ������Ʈ�Ͽ� ���� ������ ǥ��
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
