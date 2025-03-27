using UnityEngine;
using UnityEngine.UI; // ��� ������ � ������
using TMPro;
using System; // ���� ����������� TextMeshPro

public class CodeDoorUI : MonoBehaviour
{
    public GameObject uiPanel; // ������ � UI
    public TextMeshProUGUI codeDisplay; // ���� ��� ����������� ������� ������
    public GameObject door; // �����, ������� ����� �������

    private string correctCode = "1543"; // ���������� ����������
    private string enteredCode = ""; // �������� ���
    private float wrongSequenceDamage = 5f; // ���� �� ������������ ����

    private void Start()
    {
        // �������� ������ UI ����������
        uiPanel.SetActive(false);
    }

    // ����� ��� �������� ������ ��� ������� � �����
    public void OpenUIPanel()
    {
        uiPanel.SetActive(true); // ���������� ������
    }

    // ����� ��� �������� ������ ��� ���������� ������
    private void CloseUIPanel()
    {
        uiPanel.SetActive(false); // �������� ������
    }

    // ����� ��� ��������� ����� ������
    [Obsolete]
    public void OnButtonPress(string buttonValue)
    {
        enteredCode += buttonValue; // ��������� ������ � ���

        // ��������� ����������� ������� ������
        codeDisplay.text = enteredCode;

        // ���������, ���� �������� ��� ������ � ����������
        if (enteredCode.Length == correctCode.Length)
        {
            if (enteredCode == correctCode)
            {
                Debug.Log("��� ����������!");
                CloseUIPanel(); // ������� ������ ��� ���������� �����
                door.SetActive(false); // ������� �����
            }
            else
            {
                Debug.Log("������������ ���!");
                ResetCode(); // �������� ��� ��� ������
            }
        }
    }

    // ����� ��� ������ ��������� ���� � ������� �����������
    [Obsolete]
    private void ResetCode()
    {
        // ������� ���� (���� ����� ���� � �����)
        HeroScripts hero = FindObjectOfType<HeroScripts>();
        if (hero != null)
        {
            hero.TakeDamage(wrongSequenceDamage); // ������� ����
        }

        enteredCode = ""; // ���������� ���
        codeDisplay.text = ""; // ������� ��������� ����

        // ����� �������� �������� ����� ����� ������
        Invoke("ResetCodePanel", 1f); // �������� 1 ������� ����� ����� ������
    }

    // ��������������� ������ ����� ������
    private void ResetCodePanel()
    {
        codeDisplay.text = ""; // ������� ����� �� ������
    }

    internal void HandleTilePress(int tileIndex)
    {
        throw new NotImplementedException();
    }
}
