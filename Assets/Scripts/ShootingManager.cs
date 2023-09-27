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

    [SerializeField]
    private AudioSource watergunSound, sharkSound;

    private AudioSource currentBulletSound;

    public void OnFire()
    {
        Instantiate(currentBullet, shootingPoint);
        currentBulletSound.Play();
    }

    public void OnChangeShark()
    {
        gun.SetActive(false);
        shark.SetActive(true);
        currentBullet = sharkBullet;
        currentBulletSound = sharkSound;
    }
    public void OnChangeGun()
    {
        gun.SetActive(true);
        shark.SetActive(false);
        currentBullet = gunBullet;
        currentBulletSound = watergunSound;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentBullet = gunBullet;
        currentBulletSound = watergunSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
