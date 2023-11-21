using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSight : MonoBehaviour
{
    public float distance;
    public LayerMask objectsLayer;
    public LayerMask obstaclesLayer;
    public Collider detectedObject;
    public RaycastHit hit;
    public bool isFindTarget;

    // Start is called before the first frame update
    void Start()
    {
        isFindTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(
            transform.position, distance, (int)objectsLayer);

        detectedObject = null;
        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];

            Vector3 directionToController = Vector3.Normalize(
                collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(
                transform.forward, directionToController);

            if (!Physics.Linecast(transform.position,
                collider.bounds.center, out hit, (int)obstaclesLayer))
            {
                Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                detectedObject = collider;
                isFindTarget = true;
                break;
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
    }


}
