using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun, leftGun, centralGun;
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{
    [Tooltip("Shooting frequency. The higher, the more frequent")]
    public float fireRate;

    [Tooltip("Projectile prefab")]
    public GameObject projectileObject;

    [Tooltip("Sound clip for shooting")]
    public AudioClip shootSound; // Звук выстрела

    private AudioSource audioSource; // Источник звука

    // Time for a new shot
    [HideInInspector] public float nextFire;

    [Tooltip("Current weapon power")]
    [Range(1, 4)]       // Change it if you wish
    public int weaponPower = 1;

    public Guns guns;
    bool shootingIsActive = true;
    [HideInInspector] public int maxweaponPower = 4;
    public static PlayerShooting instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        // Получаем компонент AudioSource на игроке
        audioSource = GetComponent<AudioSource>();

        // Receiving shooting visual effects components
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeAShot();
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    // Method for a shot
    void MakeAShot()
    {
        // Проигрываем звук выстрела
        PlayShootSound();

        switch (weaponPower) // According to weapon power, 'pooling' the defined amount of projectiles on the defined position and rotation
        {
            case 1:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play();
                break;
            case 2:
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play();
                break;
            case 3:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                break;
            case 4:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                break;
        }
    }

    // Проигрывание звука выстрела
    void PlayShootSound()
    {
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound); // Проигрываем звук выстрела
        }
    }

    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot) // Translating 'pooled' lazer shot to the defined position in the defined rotation
    {
        Instantiate(lazer, pos, Quaternion.Euler(rot));
    }
}
