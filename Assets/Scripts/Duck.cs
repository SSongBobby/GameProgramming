using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Duck : MonoBehaviour
{
    private float spawnTransformX;
    private float spawnTransformZ;
    private float randomYRotation;
    [SerializeField]
    private GameObject duckBullet;
    public DuckSight sightSensor;

    public float speed;
    private NavMeshAgent agent;
    [SerializeField]
    private bool isAttacking;

    private Transform baseTransform, upgradeZoneTransform;

    public enum DuckState
    {
        Default,
        GoToBase,
        GoToUpgradeZone,
        AttackBase
    }

    private DuckState currentState;

    // Start is called before the first frame update
    void Start()
    {
        spawnTransformX = Random.Range(280f, 320f);
        spawnTransformZ = Random.Range(260f, 320f);
        randomYRotation = Random.Range(0f, 360f);

        Vector3 startPosition = new Vector3(spawnTransformX, -4, spawnTransformZ);
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);

        //SpawnRandomPosition();

        agent = GetComponent<NavMeshAgent>();

        Invoke("AgentEnableTrue", 1f);


        currentState = DuckState.Default;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpgradeZone")
        {
            Debug.Log("upgrade");
            EnemyManager.instance.SpawnDuckPerson();

            Destroy(this.gameObject);
        }
    }

    void GoToBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
    }

    void GoToUpgradeZone()
    {
        agent.isStopped = false;
        agent.SetDestination(upgradeZoneTransform.position);
    }

    void AttackBase()
    {
        agent.isStopped = true;
        transform.LookAt(baseTransform.position);

        if (!isAttacking)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        isAttacking = true;
        Debug.Log("duck shoot");
        Instantiate(duckBullet, transform.position, transform.rotation);

        yield return new WaitForSeconds(3f);

        isAttacking = false;
    }

    void DecideTarget()
    {
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        float distanceToUpgradeZone = Vector3.Distance(transform.position, upgradeZoneTransform.position);

        if (distanceToBase < distanceToUpgradeZone)
        {
            currentState =  DuckState.GoToBase;
        }
        else
            currentState =  DuckState.GoToUpgradeZone;
    }
    // Update is called once per frame
    void Update()
    {
        // transform.Translate(0, 0, speed * Time.deltaTime);
        if (sightSensor.isFindTarget)
            currentState = DuckState.AttackBase;

        if (currentState == DuckState.GoToBase) { GoToBase(); }
        else if (currentState == DuckState.GoToUpgradeZone) { GoToUpgradeZone(); }
        else if (currentState == DuckState.AttackBase) { AttackBase(); }
    }

    private void AgentEnableTrue()
    {
        agent.enabled = true;
        baseTransform = GameObject.Find("PlayerBase").transform;
        upgradeZoneTransform = GameObject.Find("UpgradeZone").transform;

        DecideTarget();
    }
}
