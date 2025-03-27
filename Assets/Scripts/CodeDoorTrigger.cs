using UnityEngine;

public class CodeDoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject codePanel; // Панель UI
    [SerializeField] private GameObject door; // Дверь

    private void Start()
    {
        codePanel.SetActive(false); // Панель скрыта при старте
    }

    // Когда игрок входит в триггер (должен быть настроен Collider с режимом Trigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            // Открыть панель UI
            codePanel.SetActive(true);
        }
    }

    // Когда игрок выходит из триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Если это игрок
        {
            // Закрыть панель UI
            codePanel.SetActive(false);
        }
    }
}
