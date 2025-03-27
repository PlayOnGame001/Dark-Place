using UnityEngine;
using UnityEngine.UI; // Подключаем UI компоненты

public class CodeImage : MonoBehaviour
{
    public RawImage codeImage; // Ссылка на компонент RawImage

    private void Start()
    {
        codeImage.gameObject.SetActive(false); // Убедимся, что изображение скрыто при старте
    }

    // Когда игрок входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            codeImage.gameObject.SetActive(true); // Показываем изображение
        }
    }

    // Когда игрок выходит из триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            codeImage.gameObject.SetActive(false); // Прячем изображение
        }
    }
}
