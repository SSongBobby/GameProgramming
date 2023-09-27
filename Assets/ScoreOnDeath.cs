using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    private void Awake()
    {
        var Life = GetComponent<Life>();
        Life.onDeath.AddListener(GivePoints);
    }

    void GivePoints()
    {
        ScoreManager.instance.amount += amount;
        Debug.Log(ScoreManager.instance.amount);
    }

}
