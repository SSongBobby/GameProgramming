using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public GameObject duckPrefab;
    public Transform spawnPoint;

    public static EnemyManager instance;

    [SerializeField]
    private AudioSource duckDeathSound;

    public int amount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Debug.Log("Duplicated EnemyManager, ignoring this one", gameObject);
    }

    public void PlayDeathSound()
    {
        duckDeathSound.Play();
    }

    //// Start is called before the first frame update
    void Start()
    {
        duckDeathSound = this.GetComponent<AudioSource>();
    }

    //private void SpawnEnemy()
    //{
    //    Instantiate(duckPrefab, spawnPoint);
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
