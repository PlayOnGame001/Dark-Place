using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HeroScripts hero = other.GetComponent<HeroScripts>();
            if (hero != null)
            {
                hero.TakeDamage(2); // ������ ������� 2 ����� ��� ������� �������
            }

            Destroy(gameObject);
        }
    }
}
