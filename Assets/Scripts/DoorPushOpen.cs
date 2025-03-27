using System.Collections;
using UnityEngine;

public class CodeDoorPush : MonoBehaviour
{
    public GameObject door; // Дверь, которую нужно открыть
    private int[] correctCode = new int[] { 1, 5, 4, 3 }; // Правильная комбинация плит
    private int[] enteredCode = new int[4]; // Введенная комбинация плит
    private int currentIndex = 0; // Индекс текущей введенной плитки

    private bool isCooldown = false; // Чтобы избежать частых попыток

    // Метод для обработки нажатия плитки
    public void HandleTilePress(int tileIndex)
    {
        if (isCooldown)
            return; // Если в момент перезарядки (ожидание), ничего не происходит

        // Если плитка нажата правильно
        if (tileIndex == correctCode[currentIndex])
        {
            enteredCode[currentIndex] = tileIndex;
            currentIndex++;
            Debug.Log("Правильно!"); // Положительный фидбек

            // Если введена вся комбинация
            if (currentIndex >= correctCode.Length)
            {
                OpenDoor(); // Открыть дверь
            }
        }
        else
        {
            ResetCode(); // Сбросить код при неправильном вводе
            TakeDamage(); // Наносим урон
        }
    }

    // Открытие двери
    private void OpenDoor()
    {
        door.SetActive(false); // Дверь исчезает
        Debug.Log("Дверь открыта!");
    }

    // Сброс кода
    private void ResetCode()
    {
        currentIndex = 0;
        Debug.Log("Неправильный код.");
    }

    // Наносим урон
    private void TakeDamage()
    {
        // Ваш код для нанесения урона игроку (например, уменьшаем здоровье на 0.05)
        Debug.Log("Получен урон! Урон: 0.05.");
        StartCoroutine(Cooldown()); // Запускаем 1 секунду перезарядки
    }

    // Кулдаун (задержка перед повторным вводом)
    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f); // 1 секунда перезарядки
        isCooldown = false;
    }
}
