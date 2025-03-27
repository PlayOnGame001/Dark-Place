using UnityEngine;
using TMPro; // Подключаем TextMeshPro

public class HintSign : MonoBehaviour
{
    public TextMeshProUGUI hintDisplay; // Ссылка на компонент TextMeshPro

    private void Start()
    {
        hintDisplay.gameObject.SetActive(false); // Убедимся, что подсказка скрыта при старте
    }

    // Когда игрок входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            hintDisplay.gameObject.SetActive(true); // Показываем подсказку
        }
    }

    // Когда игрок выходит из триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            hintDisplay.gameObject.SetActive(false); // Прячем подсказку
        }
    }
}
