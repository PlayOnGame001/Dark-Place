using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CodeDoorManager : MonoBehaviour
{
    public static CodeDoorManager Instance;

    public List<CodePlite> plates; // ��� �����
    public List<int> correctSequence = new List<int> { 1, 5, 4, 3 }; // ���������� ������������������
    private List<int> currentSequence = new List<int>(); // ������� ������������������

    public GameObject door; // �����, ������� ���� �������
    public float wrongSequenceDamage = 2.0f; // ���� �� ������������ ������������������
    public float plateCooldown = 0.5f; // ����� �������� ����� ������������� �����

    private bool isDoorOpen = false; // ��������� �����

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        door.SetActive(true); // ������ ��������� ����� � �������� ���������
    }

    public void PlatePressed(CodePlite plate)
    {
        if (isDoorOpen) return; // ���� ����� ��� �������, ��������� ����

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
        Debug.Log("������������ ������������������! ����������...");
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
        Debug.Log("������������������ ����������! ��������� �����...");
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
