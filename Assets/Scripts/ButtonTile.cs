using UnityEngine;

public class ButtonTile : MonoBehaviour
{
    public int tileIndex; // ������ ���� �����
    public CodeDoorUI codeDoorUI; // ������ �� ������ ��� ���� �����

    // ����� ��� ��������� ������� �� �����
    private void OnMouseDown()
    {
        codeDoorUI.HandleTilePress(tileIndex); // �������� ������ ������ � CodeDoorUI
    }
}
