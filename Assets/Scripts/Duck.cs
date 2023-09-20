using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private float spawnTransformX;
    private float spawnTransformZ;
    private float randomYRotation;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        spawnTransformX = Random.Range(260f, 320f);
        spawnTransformZ = Random.Range(260f, 320f);
        randomYRotation = Random.Range(0f, 360f);

        Vector3 startPosition = new Vector3(spawnTransformX, -4, spawnTransformZ);
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(0f, randomYRotation, 0f);
        Destroy(this.gameObject, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
