using UnityEngine;
using UnityEngine.SceneManagement; // �� �������� �������� ���

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // ������� ������ ������
    public int killThreshold = 4;   // ������� ������ ����� ����� ��� ������

    public GameObject winPanel; // ������ �� ������ ������ "�� ��������"
    public GameObject losePanel; // ������ �� ������ ������ "�� ���������"

    private void Start()
    {
        // �������� ������ �� ������ ����
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
        Time.timeScale = 0f; // ������������� �����
        losePanel.SetActive(true); // ���������� ������ "You Lose"
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        Time.timeScale = 0f; // ������������� �����
        winPanel.SetActive(true); // ���������� ������ "�� ��������"
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ������������� ������� �����
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        SceneManager.LoadScene("NextLevel"); // ��������� ��������� �����
    }

    // ����� ��� �������� �������� ����
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // ��������������� ���������� ��� �������
        SceneManager.LoadScene("MainMenu"); // �������� "MainMenu" �� ��� ����� �����
    }
}
