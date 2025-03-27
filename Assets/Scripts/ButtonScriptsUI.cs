using UnityEngine;

public class ButtonScriptsUI : MonoBehaviour
{
    public string buttonValue; // Значение кнопки (цифра)

    // Метод для обработки нажатия
    [System.Obsolete]
    public void OnButtonPress()
    {
        // Получаем ссылку на CodeDoorUI и передаем нажатое значение
        CodeDoorUI codeDoorUI = FindObjectOfType<CodeDoorUI>();
        if (codeDoorUI != null)
        {
            codeDoorUI.OnButtonPress(buttonValue);
        }
    }
}
