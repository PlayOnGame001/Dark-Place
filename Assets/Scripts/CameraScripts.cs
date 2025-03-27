using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform hero; // �������� (����� Hero)
    private float fixedHeight = 100f; // ������������� ������ ������
    private Vector3 cameraOffset;

    void Start()
    {
        FindHero();
    }

    void LateUpdate()
    {
        if (hero != null)
        {
            // ������� �� ������, �� � ������������� �������
            transform.position = new Vector3(hero.position.x + cameraOffset.x, fixedHeight, hero.position.z + cameraOffset.z);
            transform.rotation = Quaternion.Euler(90f, 0f, 0f); // ��������� ������ ������ (90� ����)
        }
    }

    public void FindHero()
    {
        if (hero == null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                hero = playerObject.transform;
                cameraOffset = new Vector3(transform.position.x - hero.position.x, 0, transform.position.z - hero.position.z);
            }
        }
    }
}
