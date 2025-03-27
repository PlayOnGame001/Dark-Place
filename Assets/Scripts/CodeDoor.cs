using UnityEngine;
using UnityEngine.UI; // Для кнопок и текста
using TMPro;
using System; // Если используешь TextMeshPro

public class CodeDoorUI : MonoBehaviour
{
    public GameObject uiPanel; // Панель с UI
    public TextMeshProUGUI codeDisplay; // Поле для отображения нажатых кнопок
    public GameObject door; // Дверь, которую нужно закрыть

    private string correctCode = "1543"; // Правильная комбинация
    private string enteredCode = ""; // Введённый код
    private float wrongSequenceDamage = 5f; // Урон за неправильный ввод

    private void Start()
    {
        // Скрываем панель UI изначально
        uiPanel.SetActive(false);
    }

    // Метод для открытия панели при подходе к двери
    public void OpenUIPanel()
    {
        uiPanel.SetActive(true); // Показываем панель
    }

    // Метод для закрытия панели при правильном пароле
    private void CloseUIPanel()
    {
        uiPanel.SetActive(false); // Скрываем панель
    }

    // Метод для обработки ввода кнопки
    [Obsolete]
    public void OnButtonPress(string buttonValue)
    {
        enteredCode += buttonValue; // Добавляем символ в код

        // Обновляем отображение нажатых кнопок
        codeDisplay.text = enteredCode;

        // Проверяем, если введённый код совпал с правильным
        if (enteredCode.Length == correctCode.Length)
        {
            if (enteredCode == correctCode)
            {
                Debug.Log("Код правильный!");
                CloseUIPanel(); // Закрыть панель при правильном вводе
                door.SetActive(false); // Убираем дверь
            }
            else
            {
                Debug.Log("Неправильный код!");
                ResetCode(); // Сбросить код при ошибке
            }
        }
    }

    // Метод для сброса введённого кода и очистки отображения
    [Obsolete]
    private void ResetCode()
    {
        // Наносим урон (если игрок есть в сцене)
        HeroScripts hero = FindObjectOfType<HeroScripts>();
        if (hero != null)
        {
            hero.TakeDamage(wrongSequenceDamage); // Наносим урон
        }

        enteredCode = ""; // Сбрасываем код
        codeDisplay.text = ""; // Очищаем текстовое поле

        // Можно добавить задержку перед новым вводом
        Invoke("ResetCodePanel", 1f); // Задержка 1 секунда перед новым вводом
    }

    // Восстанавливаем панель после сброса
    private void ResetCodePanel()
    {
        codeDisplay.text = ""; // Очищаем текст на панели
    }

    internal void HandleTilePress(int tileIndex)
    {
        throw new NotImplementedException();
    }
}
