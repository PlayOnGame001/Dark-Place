using UnityEngine;
using TMPro; // Подключаем TextMeshPro

public class DoorWithKeys : MonoBehaviour
{
    public int requiredKeys = 4; // Сколько ключей нужно для открытия
    public GameObject door; // Дверь, которую нужно открыть
    public GameObject roof; // Крыша, которая исчезает
    public Collider doorCollider; // Коллайдер, мешающий пройти
    public TextMeshProUGUI messageText; // UI для сообщения

    private bool isPlayerNear = false; // Флаг, находится ли игрок рядом

    private void Start()
    {
        // Проверяем, открыта ли дверь при загрузке
        if (PlayerPrefs.GetInt("DoorUnlocked", 0) == 1)
        {
            OpenDoor();
        }

        // Скрываем текст при старте
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Если игрок рядом, проверяем количество ключей
        if (isPlayerNear)
        {
            if (ChestKey.keysCollected >= requiredKeys)
            {
                OpenDoor();
            }
            else
            {
                ShowMessage("Нужно 4 ключа, чтобы открыть дверь!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            messageText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messageText.gameObject.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Дверь открыта!");
        door.SetActive(false); // Дверь исчезает
        if (doorCollider != null)
        {
            doorCollider.enabled = false; // Отключаем коллайдер двери
        }
        if (roof != null)
        {
            roof.SetActive(false); // Убираем крышу
        }

        PlayerPrefs.SetInt("DoorUnlocked", 1); // Сохраняем состояние двери
        PlayerPrefs.Save();
        messageText.gameObject.SetActive(false); // Скрываем сообщение
    }

    private void ShowMessage(string text)
    {
        if (messageText != null)
        {
            messageText.text = text;
        }
    }
}
