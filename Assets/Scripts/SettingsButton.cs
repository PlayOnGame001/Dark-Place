using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public Camera mainCamera;
    public Camera settingsCamera;

    public void OpenSettings()
    {
        mainCanvas.SetActive(false);
        settingsCanvas.SetActive(true);

        mainCamera.gameObject.SetActive(false);
        settingsCamera.gameObject.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settingsCanvas.SetActive(false);
        mainCanvas.SetActive(true);

        settingsCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
}
