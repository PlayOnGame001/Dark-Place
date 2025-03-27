using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject exitPanel; // ������ ������������� ������

    public void ShowExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(true);
        }
    }

    public void HideExitPanel()
    {
        if (exitPanel != null)
        {
            exitPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("���� �����������...");
        Application.Quit();
    }
}
