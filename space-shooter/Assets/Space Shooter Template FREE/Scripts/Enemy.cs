using GameDevLabirinth;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;

    [HideInInspector] public int shotChance; // Probability of shooting
    [HideInInspector] public float shotTimeMin, shotTimeMax; // Shooting time range
    #endregion

    private GameManager gameManager; // Ссылка на GameManager

    private void Start()
    {
        // Находим GameManager в сцене
        gameManager = FindObjectOfType<GameManager>();

        // Планируем стрельбу
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    void ActivateShooting()
    {
        if (Random.value < (float)shotChance / 100)
        {
            Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage; // Уменьшаем здоровье

        if (health <= 0)
            Destruction(); // Если здоровье <= 0, уничтожаем врага
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile.GetComponent<Projectile>() != null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);
        }
    }

    void Destruction()
    {
        // Сообщаем GameManager об уничтожении врага
        if (gameManager != null)
        {
            gameManager.EnemyKilled(); // Увеличиваем счётчик убитых врагов
        }

        // Визуальные эффекты разрушения
        Instantiate(destructionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject); // Уничтожаем объект врага
    }
}
