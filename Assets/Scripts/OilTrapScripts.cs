using UnityEngine;

public class OilTrap : MonoBehaviour
{
    public float slowMultiplier = 0.5f; // Насколько замедляется скорость (0.5 = в 2 раза медленнее)
    public float slowDuration = 2f; // Длительность замедления после выхода

    private void OnTriggerEnter(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            hero.speed *= slowMultiplier; // Уменьшаем скорость
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HeroScripts hero = other.GetComponent<HeroScripts>();
        if (hero != null)
        {
            StartCoroutine(RestoreSpeed(hero)); // Время через которое скорость вернется 
        }
    }

    private System.Collections.IEnumerator RestoreSpeed(HeroScripts hero)
    {
        yield return new WaitForSeconds(slowDuration);
        hero.speed /= slowMultiplier; // Скорость в норме )
    }
}
