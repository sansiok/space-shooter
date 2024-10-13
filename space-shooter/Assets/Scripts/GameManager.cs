using UnityEngine;
using UnityEngine.SceneManagement; // Не забудьте добавить это

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // Счётчик убитых врагов
    public int killThreshold = 4;   // Сколько врагов нужно убить для победы

    public GameObject winPanel; // Ссылка на объект панели "Вы выиграли"
    public GameObject losePanel; // Ссылка на объект панели "Вы проиграли"

    private void Start()
    {
        // Скрываем панели на старте игры
        winPanel.SetActive(false);
        losePanel.SetActive(false);
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

    public void PlayerDied()
    {
        Debug.Log("You Lose!");
        Time.timeScale = 0f; // Останавливаем время
        losePanel.SetActive(true); // Отображаем панель "You Lose"
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f; // Останавливаем время
        winPanel.SetActive(true); // Отображаем панель "Вы выиграли"
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагружаем текущую сцену
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        SceneManager.LoadScene("NextLevel"); // Загружаем следующую сцену
    }

    // Метод для загрузки главного меню
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        SceneManager.LoadScene("MainMenu"); // Замените "MainMenu" на имя вашей сцены
    }
}
