using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemies;
    public GameObject duckPrefab;
    public Transform spawnPoint;
    public UnityEvent onChanged;

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

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
        onChanged.Invoke();
    }

    public void RemoveEnemy(Enemy enemy)
    {
        duckDeathSound.Play();
        enemies.Remove(enemy);
        onChanged.Invoke();
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
