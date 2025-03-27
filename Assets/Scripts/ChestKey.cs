using UnityEngine;
using TMPro; // Подключаем TextMeshPro для UI

public class ChestKey : MonoBehaviour
{
    public static int keysCollected = 0; // Количество собранных ключей
    public int chestID; // Уникальный ID сундука

    public static TextMeshProUGUI keyCounterText; // UI-счетчик
    public static int totalKeys = 4; // Общее количество ключей

    void Start()
    {
        if (keyCounterText == null)
        {
            keyCounterText = GameObject.Find("KeyCounter")?.GetComponent<TextMeshProUGUI>();
        }
        UpdateKeyCounterUI();

        // Загружаем количество ключей при старте (только один раз)
        if (PlayerPrefs.HasKey("KeysCollected"))
        {
            keysCollected = PlayerPrefs.GetInt("KeysCollected");
        }

        // Проверяем, был ли уже открыт этот сундук
        if (PlayerPrefs.GetInt($"Chest_{chestID}_Opened", 0) == 1)
        {
            Destroy(gameObject); // Удаляем сундук, если он уже был открыт
        }

        UpdateKeyCounterUI(); // Обновляем UI при старте
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keysCollected++; // Увеличиваем количество ключей
            UpdateKeyCounterUI(); // Обновляем UI

            // Сохраняем состояние сундука и ключей
            PlayerPrefs.SetInt($"Chest_{chestID}_Opened", 1);
            PlayerPrefs.SetInt("KeysCollected", keysCollected);
            PlayerPrefs.Save();

            Debug.Log($"Сундук {chestID} открыт. Ключи: {keysCollected}/{totalKeys}");

            Destroy(gameObject); // Удаляем сундук после сбора
        }
    }

    public static void UpdateKeyCounterUI()
    {
        if (keyCounterText != null)
        {
            keyCounterText.text = $"Ключи: {keysCollected}/{totalKeys}";
        }
    }
}
