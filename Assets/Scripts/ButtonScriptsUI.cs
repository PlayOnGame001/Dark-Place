using UnityEngine;

public class ButtonScriptsUI : MonoBehaviour
{
    public string buttonValue; // �������� ������ (�����)

    // ����� ��� ��������� �������
    [System.Obsolete]
    public void OnButtonPress()
    {
        // �������� ������ �� CodeDoorUI � �������� ������� ��������
        CodeDoorUI codeDoorUI = FindObjectOfType<CodeDoorUI>();
        if (codeDoorUI != null)
        {
            codeDoorUI.OnButtonPress(buttonValue);
        }
    }
}
