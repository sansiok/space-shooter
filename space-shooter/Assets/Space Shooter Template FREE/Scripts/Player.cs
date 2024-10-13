using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines which sprite the 'Player' uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance;

    public int health = 3; // Начальное количество здоровья

    private GameManager gameManager; // Ссылка на GameManager

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        // Находим GameManager в сцене
        gameManager = FindObjectOfType<GameManager>();
    }

    // Метод для обработки получения урона игроком
    public void GetDamage(int damage)
    {
        health -= damage; // Уменьшаем здоровье

        Debug.Log("Player health: " + health);

        // Проверяем, достигло ли здоровье нуля
        if (health <= 0)
        {
            Destruction(); // Если здоровье 0, вызываем процедуру уничтожения
        }
    }

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); // Генерируем визуальный эффект уничтожения
        gameManager.PlayerDied(); // Сообщаем GameManager о проигрыше
        Destroy(gameObject); // Уничтожаем объект игрока
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Пример: игрок получает урон при столкновении с врагом
            GetDamage(1); // Уменьшаем здоровье на 1
        }
    }
}
