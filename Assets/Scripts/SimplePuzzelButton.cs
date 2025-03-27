using UnityEngine;

public class SimplePuzzleButton : MonoBehaviour
{
    public SimplePuzzleDoor door; // ������ �� �����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ���� ����� �������� �� �����
        {
            Debug.Log("����� �������� �� �����!");
            if (door != null)
            {
                door.OpenDoor(); // ��������� ����� (������ �� ���������)
            }
        }
    }
}
