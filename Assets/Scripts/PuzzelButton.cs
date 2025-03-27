using UnityEngine;

public class PuzzelButton : MonoBehaviour
{
    public int plateIndex; // Индекс плиты
    private Vector3 initialPosition; // Начальная позиция плитки
    private bool isPressed = false; // Плитка нажата
    private Vector3 pressedPosition; // Вжимающаяся позиция плитки
    private float pressCooldown = 1f; // Время ожидания между нажатиями
    private float lastPressTime = 0f; // Время последнего нажатия

    private void Start()
    {
        initialPosition = transform.position;
        pressedPosition = new Vector3(initialPosition.x, initialPosition.y - 0.1f, initialPosition.z); // Вжимаем плитку на 0.1 единицу
    }

    public void PressPlate()
    {
        // Проверка, можно ли нажать плиту (прошло ли достаточно времени)
        if (Time.time - lastPressTime < pressCooldown)
            return; // Если нет, не нажимаем плиту

        lastPressTime = Time.time; // Обновляем время последнего нажатия
        isPressed = true;
        transform.position = pressedPosition; // Вжимаем плитку
        Debug.Log("Плитка нажата! Индекс: " + plateIndex); // Дебаг

        PuzzleManager.Instance.PlatePressed(this); // Уведомляем PuzzleManager о нажатой плите
    }

    public void ResetPlate()
    {
        isPressed = false;
        transform.position = initialPosition; // Восстанавливаем плитку в исходное положение
        Debug.Log("Плитка сброшена. Индекс: " + plateIndex); // Дебаг
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если игрок наступил на плиту
        {
            Debug.Log("Игрок наступил на плиту! Индекс: " + plateIndex); // Дебаг
            PressPlate(); // Нажимаем плитку
        }
    }
}
