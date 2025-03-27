using System.Collections;
using UnityEngine;

public class CodeDoorPush : MonoBehaviour
{
    public GameObject door; // �����, ������� ����� �������
    private int[] correctCode = new int[] { 1, 5, 4, 3 }; // ���������� ���������� ����
    private int[] enteredCode = new int[4]; // ��������� ���������� ����
    private int currentIndex = 0; // ������ ������� ��������� ������

    private bool isCooldown = false; // ����� �������� ������ �������

    // ����� ��� ��������� ������� ������
    public void HandleTilePress(int tileIndex)
    {
        if (isCooldown)
            return; // ���� � ������ ����������� (��������), ������ �� ����������

        // ���� ������ ������ ���������
        if (tileIndex == correctCode[currentIndex])
        {
            enteredCode[currentIndex] = tileIndex;
            currentIndex++;
            Debug.Log("���������!"); // ������������� ������

            // ���� ������� ��� ����������
            if (currentIndex >= correctCode.Length)
            {
                OpenDoor(); // ������� �����
            }
        }
        else
        {
            ResetCode(); // �������� ��� ��� ������������ �����
            TakeDamage(); // ������� ����
        }
    }

    // �������� �����
    private void OpenDoor()
    {
        door.SetActive(false); // ����� ��������
        Debug.Log("����� �������!");
    }

    // ����� ����
    private void ResetCode()
    {
        currentIndex = 0;
        Debug.Log("������������ ���.");
    }

    // ������� ����
    private void TakeDamage()
    {
        // ��� ��� ��� ��������� ����� ������ (��������, ��������� �������� �� 0.05)
        Debug.Log("������� ����! ����: 0.05.");
        StartCoroutine(Cooldown()); // ��������� 1 ������� �����������
    }

    // ������� (�������� ����� ��������� ������)
    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(1f); // 1 ������� �����������
        isCooldown = false;
    }
}
