using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playOptionsPanel;
    public GameObject exitPanel;

    // Метод для закрытия всех панелей
    private void CloseAllPanels()
    {
        playOptionsPanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    public void OpenPlayOptions()
    {
        CloseAllPanels(); // Закрываем все панели перед открытием новой
        playOptionsPanel.SetActive(true);
    }

    public void OpenExitPanel()
    {
        CloseAllPanels();
        exitPanel.SetActive(true);
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("SampleScene"); // Загружаем сцену
    }

    public void ExitGame()
    {
        Application.Quit(); // Закрытие игры
    }
}
