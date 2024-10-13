using UnityEngine;
using UnityEngine.UI; // Для работы с UI элементами
using UnityEngine.SceneManagement; // Для загрузки следующей сцены

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // Счётчик убитых врагов
    public int killThreshold = 4;  // Сколько врагов нужно убить для победы

    public GameObject winPanel; // Ссылка на объект панели (Panel)

    private void Start()
    {
        // Скрываем панель на старте игры
        winPanel.SetActive(false);
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy killed! Current count: " + enemyKillCount);

        if (enemyKillCount >= killThreshold)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        // Останавливаем время
        Time.timeScale = 0f;

        // Отображаем панель с текстом и кнопкой
        winPanel.SetActive(true);
    }

    // Метод для загрузки следующего уровня
    public void LoadNextLevel()
    {
        // Восстанавливаем нормальный ход времени
        Time.timeScale = 1f;

        // Здесь можно загрузить следующую сцену
        SceneManager.LoadScene("NextLevel");
    }
}

