using UnityEngine;
using System.Collections.Generic;
using System;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<PuzzelButton> plates; // Все плиты
    public List<int> correctSequence = new List<int> { 1, 2, 3, 4, 5 }; // Правильная последовательность
    private List<int> currentSequence = new List<int>(); // Текущая последовательность

    public GameObject door; // Дверь, которую надо открыть
    public float wrongSequenceDamage = 2.0f; // Урон за неправильную последовательность

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        door.SetActive(true); // Дверь всегда загружается закрытой
    }

    public void PlatePressed(PuzzelButton plate)
    {
        // Добавляем индекс нажатой плиты в текущую последовательность
        currentSequence.Add(plate.plateIndex);

        // Проверка правильности последовательности
        if (currentSequence.Count > correctSequence.Count)
        {
            ResetPuzzle(); // Если последовательность слишком длинная, сбрасываем
            return;
        }

        // Проверка правильности последовательности
        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                ResetPuzzle(); // Если последовательность неправильная, сбрасываем
                return;
            }
        }

        // Если последовательность правильная
        if (currentSequence.Count == correctSequence.Count)
        {
            OpenDoor(); // Открываем дверь
        }
    }

    private void ResetPuzzle()
    {
        Debug.Log("Неправильная последовательность! Сбрасываем...");
        currentSequence.Clear(); // Очищаем текущую последовательность

        // Сбрасываем все плиты
        foreach (var plate in plates)
        {
            plate.ResetPlate();
        }

        // Наносим урон игроку за неправильную последовательность
        HeroScripts hero = FindObjectOfType<HeroScripts>();
        if (hero != null)
        {
            hero.TakeDamage(wrongSequenceDamage); // Наносим урон
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Последовательность правильная! Открываем дверь...");
        door.SetActive(false); // Дверь исчезает (или можно анимировать её открытие)
    }
}
