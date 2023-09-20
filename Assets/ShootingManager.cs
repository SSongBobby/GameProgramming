using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingManager : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject gunBullet;
    public GameObject sharkBullet;
    public GameObject gun;
    public GameObject shark;
    private GameObject currentBullet;

    public void OnFire()
    {
        Debug.Log("onShoot");
        Instantiate(currentBullet, shootingPoint);
    }

    public void OnChangeShark()
    {
        gun.SetActive(false);
        shark.SetActive(true);
        currentBullet = sharkBullet;
    }
    public void OnChangeGun()
    {
        gun.SetActive(true);
        shark.SetActive(false);
        currentBullet = gunBullet;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBullet = gunBullet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
