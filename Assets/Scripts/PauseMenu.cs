using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsMenu; // Меню настроек
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        isPaused = !isPaused;
        settingsMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1; // Останавливаем время при открытии меню
    }
}
