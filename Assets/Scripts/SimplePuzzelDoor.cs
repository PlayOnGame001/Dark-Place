using UnityEngine;

public class SimplePuzzleDoor : MonoBehaviour
{
    private bool isDoorOpen = false;

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            gameObject.SetActive(false); // ������ ����� ���������
            if (GetComponent<Collider>() != null)
            {
                GetComponent<Collider>().enabled = false; // ��������� ���������
            }
            isDoorOpen = true;
            Debug.Log("����� �������!");
        }
    }
}
