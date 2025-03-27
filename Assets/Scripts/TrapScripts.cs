using UnityEngine;

public class TrapScripts : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint; // проверка откуда стреляем
    public float projectileSpeed = 20f; // Скорость полета снаряда
    public float projectileLifetime = 2f; // Время жизни снаряда
    public float fireRate = 1.75f; // Интервал выстрелов
    public float damage = 0.9f; 

    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = false;
            rb.linearVelocity = firePoint.forward * projectileSpeed; // Двигаем вперед
        }

        Projectile projectileScript = projectile.AddComponent<Projectile>(); // Урон
        projectileScript.damage = damage;

        Destroy(projectile, projectileLifetime); // Снаряд пропадет через 2 секунды или сколько мы там зададим
    }
}

// Класс снаряда
public class Projectile : MonoBehaviour
{
    public float damage; // Изменили на float

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверка на столкновение с героем
        {
            HeroScripts hero = other.GetComponent<HeroScripts>();
            if (hero != null)
            {
                hero.TakeDamage(damage); // Наносим урон
            }
            Destroy(gameObject); // Снаряд пропадает после попадания
        }
    }
}
