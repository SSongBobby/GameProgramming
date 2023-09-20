using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        Destroy(this.gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
    }
}
