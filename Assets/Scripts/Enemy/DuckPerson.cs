using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckPerson : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField]
    private float movementSpeed = 20f; // 이동 속도 조절
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
            // 현재 위치에서 다음 웨이포인트로 이동
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, movementSpeed * Time.deltaTime);

            transform.LookAt(waypoints[currentWaypointIndex].position);

            // 만약 현재 위치가 웨이포인트에 도달했다면 다음 웨이포인트로 이동
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            // 모든 웨이포인트를 돌았으면 다시 첫 번째 웨이포인트로 돌아가기
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
