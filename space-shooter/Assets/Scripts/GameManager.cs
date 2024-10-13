using UnityEngine;
using UnityEngine.UI; // ��� ������ � UI ����������
using UnityEngine.SceneManagement; // ��� �������� ��������� �����

public class GameManager : MonoBehaviour
{
    public int enemyKillCount = 0; // ������� ������ ������
    public int killThreshold = 4;  // ������� ������ ����� ����� ��� ������

    public GameObject winPanel; // ������ �� ������ ������ (Panel)

    private void Start()
    {
        // �������� ������ �� ������ ����
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
        // ������������� �����
        Time.timeScale = 0f;

        // ���������� ������ � ������� � �������
        winPanel.SetActive(true);
    }

    // ����� ��� �������� ���������� ������
    public void LoadNextLevel()
    {
        // ��������������� ���������� ��� �������
        Time.timeScale = 1f;

        // ����� ����� ��������� ��������� �����
        SceneManager.LoadScene("NextLevel");
    }
}

