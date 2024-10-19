using UnityEngine;
using UnityEngine.SceneManagement; // Для загрузки сцен
using UnityEngine.UI; // Для работы с UI элементами

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // Счётчик убитых врагов
    public int killThreshold = 4;   // Сколько врагов нужно убить для победы

    public GameObject winPanel; // Ссылка на объект панели "Вы выиграли"
    public GameObject losePanel; // Ссылка на объект панели "Вы проиграли"
    public Text enemyKillText; // Ссылка на текст для отображения количества убитых врагов

    // Ссылки на кнопки
    public Button nextLevelButton; // Ссылка на кнопку "Next Level"
    public Button mainMenuButton; // Ссылка на кнопку "Main Menu"

    private void Start()
    {
        // Скрываем панели на старте игры
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        // Убедитесь, что кнопки скрыты в начале игры
        nextLevelButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);

        // Обновляем UI при старте
        UpdateEnemyKillText();
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy killed! Current count: " + enemyKillCount);

        // Обновляем текст с количеством убитых врагов
        UpdateEnemyKillText();

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

        // Показываем кнопку "Next Level"
        nextLevelButton.gameObject.SetActive(true);
    }

    // Метод для обновления текста с количеством убитых врагов
    void UpdateEnemyKillText()
    {
        enemyKillText.text = "Enemies killed: " + enemyKillCount + "/" + killThreshold;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезагружаем текущую сцену
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        nextLevelButton.gameObject.SetActive(false); // Скрыть кнопку перед загрузкой следующего уровня
        SceneManager.LoadScene("Level3"); // Загружаем следующую сцену
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Восстанавливаем нормальный ход времени
        SceneManager.LoadScene("MainMenu"); // Замените "MainMenu" на имя вашей сцены
    }
}
