using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playOptionsPanel;
    public GameObject exitPanel;

    // ����� ��� �������� ���� �������
    private void CloseAllPanels()
    {
        playOptionsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    public void OpenPlayOptions()
    {
        CloseAllPanels(); // ��������� ��� ������ ����� ��������� �����
        playOptionsPanel.SetActive(true);
    }

    public void OpenExitPanel()
    {
        CloseAllPanels();
        exitPanel.SetActive(true);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene"); // ��������� �����
    }

    public void ExitGame()
    {
        Application.Quit(); // �������� ����
    }
}
