using UnityEngine;
using System.Collections.Generic;
using System;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    public List<PuzzelButton> plates; // ��� �����
    public List<int> correctSequence = new List<int> { 1, 2, 3, 4, 5 }; // ���������� ������������������
    private List<int> currentSequence = new List<int>(); // ������� ������������������

    public GameObject door; // �����, ������� ���� �������
    public float wrongSequenceDamage = 2.0f; // ���� �� ������������ ������������������

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        door.SetActive(true); // ����� ������ ����������� ��������
    }

    public void PlatePressed(PuzzelButton plate)
    {
        // ��������� ������ ������� ����� � ������� ������������������
        currentSequence.Add(plate.plateIndex);

        // �������� ������������ ������������������
        if (currentSequence.Count > correctSequence.Count)
        {
            ResetPuzzle(); // ���� ������������������ ������� �������, ����������
            return;
        }

        // �������� ������������ ������������������
        for (int i = 0; i < currentSequence.Count; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                ResetPuzzle(); // ���� ������������������ ������������, ����������
                return;
            }
        }

        // ���� ������������������ ����������
        if (currentSequence.Count == correctSequence.Count)
        {
            OpenDoor(); // ��������� �����
        }
    }

    private void ResetPuzzle()
    {
        Debug.Log("������������ ������������������! ����������...");
        currentSequence.Clear(); // ������� ������� ������������������

        // ���������� ��� �����
        foreach (var plate in plates)
        {
            plate.ResetPlate();
        }

        // ������� ���� ������ �� ������������ ������������������
        HeroScripts hero = FindObjectOfType<HeroScripts>();
        if (hero != null)
        {
            hero.TakeDamage(wrongSequenceDamage); // ������� ����
        }
    }

    private void OpenDoor()
    {
        Debug.Log("������������������ ����������! ��������� �����...");
        door.SetActive(false); // ����� �������� (��� ����� ����������� � ��������)
    }
}
