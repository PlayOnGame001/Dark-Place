using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class HeroScripts : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    private AudioSource stepsSound;

    // физика героя
    public float speed = 5f;
    public float dashSpeed = 100f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 0.5f;
    public Vector3 startPosition;
    private int bonfireID;  // Идентификатор костра

    // переменные для здоровья
    private bool isDead = false;
    public HpBarScripts healthBar;
    public float maxHealth = 10f;
    private float currentHealth;

    private bool isDashing = false;
    private bool canDash = true;
    private Vector3 moveDirection;
    private float gravity = -9.81f;

    private GameObject player;

    void Start()
    {
        healthBar = FindObjectOfType<HpBarScripts>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        stepsSound = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

        // Стартовая позиция фиксирована
        startPosition = new Vector3(100, 10, 110);

        if (healthBar == null)
        {
            return;
        }

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);

        // Загружаем сохраненную позицию костра или ставим стартовую позицию
        Vector3 spawnPosition = GetSavedBonfirePosition();

        // Если данных нет (или они дефолтные 0,0,0), используем начальную позицию
        if (spawnPosition == Vector3.zero)
        {
            spawnPosition = startPosition;
        }

        ResetToSpawnPosition(spawnPosition);
    }
    
    public void SetBonfireID(int id)
    {
        bonfireID = id;
    }

    void Update()
    {
        if (isDashing || isDead) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(moveX, 0, moveZ).normalized;

        if (moveDirection.magnitude > 0)
        {
            controller.Move(moveDirection * speed * Time.deltaTime);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        controller.Move(new Vector3(0, gravity * Time.deltaTime, 0));

        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Die");

        StartCoroutine(RespawnCoroutine());
    }


    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(2f);

        Vector3 spawnPosition = GetSavedBonfirePosition();
        ResetToSpawnPosition(spawnPosition);

        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);
        isDead = false;
    }

    private Vector3 GetSavedBonfirePosition()
    {
        // Проверяем, есть ли сохранённые координаты
        if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ"))
        {
            float spawnX = PlayerPrefs.GetFloat("SpawnX");
            float spawnY = PlayerPrefs.GetFloat("SpawnY");
            float spawnZ = PlayerPrefs.GetFloat("SpawnZ");

            // Проверяем, что сохранённые координаты не (0,0,0), иначе используем стартовую позицию
            Vector3 savedPosition = new Vector3(spawnX, spawnY, spawnZ);
            if (savedPosition != Vector3.zero)
            {
                return savedPosition;
            }
        }

        // Если данных нет или они равны (0,0,0), возвращаем стартовую позицию
        return startPosition;
    }


    public void ResetToSpawnPosition(Vector3 spawnPosition)
    {
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = spawnPosition;
            controller.enabled = true;
        }
        else
        {
            transform.position = spawnPosition;
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        animator.SetTrigger("03_Dash");

        Vector3 dashVector = moveDirection * dashSpeed;

        float elapsed = 0;
        while (elapsed < dashDuration)
        {
            controller.Move(dashVector * Time.deltaTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
        animator.ResetTrigger("03_Dash");
        animator.SetTrigger("DashEnded");

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    public bool IsDashing()
    {
        return isDashing;
    }

    public void ResetToStartPosition()
    {
        if (controller != null)
        {
            controller.enabled = false;
            transform.position = startPosition;
            controller.enabled = true;
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public bool IsDeads() // проверка смерти для шипов
    {
        return isDead;
    }

    internal bool IsDead()
    {
        throw new NotImplementedException();
    }
}