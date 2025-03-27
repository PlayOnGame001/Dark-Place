using UnityEngine;

public class ButtonTile : MonoBehaviour
{
    public int tileIndex; // Индекс этой плиты
    public CodeDoorUI codeDoorUI; // Ссылка на скрипт для кода двери

    // Метод для обработки нажатия на плиту
    private void OnMouseDown()
    {
        codeDoorUI.HandleTilePress(tileIndex); // Передаем индекс плитки в CodeDoorUI
    }
}
