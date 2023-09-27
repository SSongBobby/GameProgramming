using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField]
    private Life playerLife;

    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerDied);
        EnemyManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    void OnPlayerDied()
    {
        SceneManager.LoadScene("LoseScreen");
    }

    void CheckWinCondition()
    {
        if (EnemyManager.instance.enemies.Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}      
