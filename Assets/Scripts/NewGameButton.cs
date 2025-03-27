using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("������ ������ '����� ����'. ������� ����������...");
        SpawnPoint.DeleteSaveData(); // ������� ��� ������ ������ ����������

        string firstSceneName = "SampleScene"; // �������� ������ �����
        Debug.Log("��������� �����: " + firstSceneName);
        SceneManager.LoadScene(firstSceneName);
    }
}
