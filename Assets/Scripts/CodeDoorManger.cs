using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CodeDoorManager : MonoBehaviour
{
    public static CodeDoorManager Instance;

    public List<CodePlite> plates; // Все плиты
    public List<int> correctSequence = new List<int> { 1, 5, 4, 3 }; // Правильная последовательность
    private List<int> currentSequence = new List<int>(); // Текущая последовательность

    public GameObject door; // Дверь, которую надо открыть
    public float wrongSequenceDamage = 2.0f; // Урон за неправильную последовательность
    public float plateCooldown = 0.5f; // Время ожидания после неправильного ввода

    private bool isDoorOpen = false; // Состояние двери

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        door.SetActive(true); // Всегда загружаем дверь в закрытом состоянии
    }

    public void PlatePressed(CodePlite plate)
    {
        if (isDoorOpen) return; // Если дверь уже открыта, отключаем ввод

        currentSequence.Add(plate.plateIndex);

        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                ResetPuzzle();
                return;
            }
        }

        if (currentSequence.Count == correctSequence.Count)
        {
            OpenDoor();
        }
    }

    private void ResetPuzzle()
    {
        Debug.Log("Неправильная последовательность! Сбрасываем...");
        currentSequence.Clear();

        foreach (var plate in plates)
        {
            plate.ResetPlate();
        }

        HeroScripts hero = FindObjectOfType<HeroScripts>();
        if (hero != null)
        {
            hero.TakeDamage(wrongSequenceDamage);
        }

        StartCoroutine(PlateCooldown());
    }

    private void OpenDoor()
    {
        Debug.Log("Последовательность правильная! Открываем дверь...");
        isDoorOpen = true;
        door.SetActive(false);
    }

    private IEnumerator PlateCooldown()
    {
        foreach (var plate in plates)
        {
            plate.BlockPlate(plateCooldown);
        }
        yield return new WaitForSeconds(plateCooldown);

        foreach (var plate in plates)
        {
            plate.UnblockPlate();
        }
    }
}
