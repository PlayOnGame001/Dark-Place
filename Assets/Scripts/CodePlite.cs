using UnityEngine;

public class CodePlite : MonoBehaviour
{
    public int plateIndex; // Индекс плиты
    private Vector3 initialPosition; // Начальная позиция плитки
    private bool isPressed = false; // Плитка нажата
    private Vector3 pressedPosition; // Вжимающаяся позиция плитки
    private float pressCooldown = 1f; // Время ожидания между нажатиями
    private float lastPressTime = 0f; // Время последнего нажатия
    private bool isBlocked = false; // Флаг блокировки плитки

    private void Start()
    {
        initialPosition = transform.position;
        pressedPosition = new Vector3(initialPosition.x, initialPosition.y - 0.1f, initialPosition.z); // Вжимаем плитку на 0.1 единицу
    }

    [System.Obsolete]
    public void PressPlate()
    {
        if (isBlocked)
            return; // Если плитка заблокирована, не нажимаем её

        // Проверка, можно ли нажать плиту (прошло ли достаточно времени)
        if (Time.time - lastPressTime < pressCooldown)
            return; // Если нет, не нажимаем плиту

        lastPressTime = Time.time; // Обновляем время последнего нажатия
        isPressed = true;
        transform.position = pressedPosition; // Вжимаем плитку
        Debug.Log("Плитка нажата! Индекс: " + plateIndex); // Дебаг

        CodeDoorManager.Instance.PlatePressed(this); // Уведомляем CodeDoorManager о нажатой плите
    }

    public void ResetPlate()
    {
        isPressed = false;
        transform.position = initialPosition; // Восстанавливаем плитку в исходное положение
        Debug.Log("Плитка сброшена. Индекс: " + plateIndex); // Дебаг
    }

    public void BlockPlate(float cooldown)
    {
        isBlocked = true;
        Debug.Log("Плитка заблокирована на " + cooldown + " секунд.");
    }

    public void UnblockPlate()
    {
        isBlocked = false;
        Debug.Log("Плитка разблокирована.");
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если игрок наступил на плиту
        {
            Debug.Log("Игрок наступил на плиту! Индекс: " + plateIndex); // Дебаг
            PressPlate(); // Нажимаем плитку
        }
    }
}
