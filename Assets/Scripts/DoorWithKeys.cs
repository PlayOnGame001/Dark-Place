using UnityEngine;
using TMPro; // ���������� TextMeshPro

public class DoorWithKeys : MonoBehaviour
{
    public int requiredKeys = 4; // ������� ������ ����� ��� ��������
    public GameObject door; // �����, ������� ����� �������
    public GameObject roof; // �����, ������� ��������
    public Collider doorCollider; // ���������, �������� ������
    public TextMeshProUGUI messageText; // UI ��� ���������

    private bool isPlayerNear = false; // ����, ��������� �� ����� �����

    private void Start()
    {
        // ���������, ������� �� ����� ��� ��������
        if (PlayerPrefs.GetInt("DoorUnlocked", 0) == 1)
        {
            OpenDoor();
        }

        // �������� ����� ��� ������
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // ���� ����� �����, ��������� ���������� ������
        if (isPlayerNear)
        {
            if (ChestKey.keysCollected >= requiredKeys)
            {
                OpenDoor();
            }
            else
            {
                ShowMessage("����� 4 �����, ����� ������� �����!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            messageText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            messageText.gameObject.SetActive(false);
        }
    }

    private void OpenDoor()
    {
        Debug.Log("����� �������!");
        door.SetActive(false); // ����� ��������
        if (doorCollider != null)
        {
            doorCollider.enabled = false; // ��������� ��������� �����
        }
        if (roof != null)
        {
            roof.SetActive(false); // ������� �����
        }

        PlayerPrefs.SetInt("DoorUnlocked", 1); // ��������� ��������� �����
        PlayerPrefs.Save();
        messageText.gameObject.SetActive(false); // �������� ���������
    }

    private void ShowMessage(string text)
    {
        if (messageText != null)
        {
            messageText.text = text;
        }
    }
}
