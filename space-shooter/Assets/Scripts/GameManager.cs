using UnityEngine;
using UnityEngine.SceneManagement; // ��� �������� ����
using UnityEngine.UI; // ��� ������ � UI ����������

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // ������� ������ ������
    public int killThreshold = 4;   // ������� ������ ����� ����� ��� ������

    public GameObject winPanel; // ������ �� ������ ������ "�� ��������"
    public GameObject losePanel; // ������ �� ������ ������ "�� ���������"
    public Text enemyKillText; // ������ �� ����� ��� ����������� ���������� ������ ������

    // ������ �� ������
    public Button nextLevelButton; // ������ �� ������ "Next Level"
    public Button mainMenuButton; // ������ �� ������ "Main Menu"

    private void Start()
    {
        // �������� ������ �� ������ ����
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        // ���������, ��� ������ ������ � ������ ����
        nextLevelButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);

        // ��������� UI ��� ������
        UpdateEnemyKillText();
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy killed! Current count: " + enemyKillCount);

        // ��������� ����� � ����������� ������ ������
        UpdateEnemyKillText();

        if (enemyKillCount >= killThreshold)
        {
            WinGame();
        }
    }

    public void PlayerDied()
    {
        Debug.Log("You Lose!");
        Time.timeScale = 0f; // ������������� �����
        losePanel.SetActive(true); // ���������� ������ "You Lose"
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f; // ������������� �����
        winPanel.SetActive(true); // ���������� ������ "�� ��������"

        // ���������� ������ "Next Level"
        nextLevelButton.gameObject.SetActive(true);
    }

    // ����� ��� ���������� ������ � ����������� ������ ������
    void UpdateEnemyKillText()
    {
        enemyKillText.text = "Enemies killed: " + enemyKillCount + "/" + killThreshold;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� ������� �����
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        nextLevelButton.gameObject.SetActive(false); // ������ ������ ����� ��������� ���������� ������
        SceneManager.LoadScene("Level3"); // ��������� ��������� �����
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        SceneManager.LoadScene("MainMenu"); // �������� "MainMenu" �� ��� ����� �����
    }
}
