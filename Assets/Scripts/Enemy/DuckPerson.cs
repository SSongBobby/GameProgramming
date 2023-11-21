using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPerson : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField]
    private float movementSpeed = 20f; // �̵� �ӵ� ����
    public Sight sightSensor;

    private Animator animator;

    public enum DuckPersonState
    {
        Run,
        AttackPlayer
    }

    private DuckPersonState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = DuckPersonState.Run;
        animator = GetComponent<Animator>();

        GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("waypoint");
        waypoints = new Transform[waypointObjects.Length];

        for (int i = 0; i < waypointObjects.Length; i++)
        {
            string waypointsName = "waypoint" + i.ToString();
            Debug.Log(waypointsName);
            waypoints[i] = GameObject.Find(waypointsName).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sightSensor.isFindTarget)
            currentState = DuckPersonState.AttackPlayer;

        if (currentState == DuckPersonState.Run) { Run(); }
        else if (currentState == DuckPersonState.AttackPlayer) { Attack();  }
        
    }

    private void Run()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // ���� ��ġ���� ���� ��������Ʈ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, movementSpeed * Time.deltaTime);

            transform.LookAt(waypoints[currentWaypointIndex].position);

            // ���� ���� ��ġ�� ��������Ʈ�� �����ߴٸ� ���� ��������Ʈ�� �̵�
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // ��� ��������Ʈ�� �������� �ٽ� ù ��° ��������Ʈ�� ���ư���
            currentWaypointIndex = 0;
        }
    }

    private void Attack()
    {
        if (sightSensor.detectedObject == null)
        {
            currentState = DuckPersonState.Run;
            animator.SetTrigger("RunTrigger");
            return;
        }
        //GetComponent<Rigidbody>().velocity = Vector3.zero;

        animator.SetTrigger("AttackTrigger");

    }
}
