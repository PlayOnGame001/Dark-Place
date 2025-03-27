using UnityEngine;
using UnityEngine.UI;

public class FogScripts : MonoBehaviour
{
    public Toggle fogToggle; // Ссылка на чекбокс

    private void Start()
    {
        // Загружаем сохранённое значение (если оно есть)
        if (PlayerPrefs.HasKey("FogEnabled"))
        {
            bool isFogEnabled = PlayerPrefs.GetInt("FogEnabled") == 1;
            RenderSettings.fog = isFogEnabled;
            fogToggle.isOn = isFogEnabled;
        }

        // Подписываемся на событие изменения чекбокса
        fogToggle.onValueChanged.AddListener(ToggleFog);
    }

    private void ToggleFog(bool isOn)
    {
        RenderSettings.fog = isOn;
        PlayerPrefs.SetInt("FogEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
