using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    public TextMeshProUGUI interactText;
    private bool playerInRange = false;
    private GameObject player;

    public int bonfireID; // Уникальный ID костра

    void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        // Загружаем игрока, если текущая сцена совпадает с сохранённой
        if (PlayerPrefs.HasKey("LastScene") && PlayerPrefs.GetString("LastScene") == SceneManager.GetActiveScene().name)
        {
            LoadGame();
        }
    }

    private void LoadGame()
    {
        if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ"))
        {
            float spawnX = PlayerPrefs.GetFloat("SpawnX", 100);
            float spawnY = PlayerPrefs.GetFloat("SpawnY", 11);
            float spawnZ = PlayerPrefs.GetFloat("SpawnZ", 110);

            Debug.Log($"ЗАГРУЖЕНЫ координаты: X={spawnX:F2}, Y={spawnY:F2}, Z={spawnZ:F2}");

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
            {
                playerObject.transform.position = new Vector3(spawnX, spawnY, spawnZ);
                Debug.Log($"Игрок перемещён в ({spawnX:F2}, {spawnY:F2}, {spawnZ:F2})");
            }
            else
            {
                Debug.LogError("Ошибка: Игрок не найден в сцене!");
            }
        }
        else
        {
            Debug.LogWarning("Координаты не найдены в сохранении! Устанавливаем начальные координаты.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.gameObject;

            HeroScripts heroScript = player.GetComponent<HeroScripts>();
            if (heroScript != null)
            {
                heroScript.SetBonfireID(bonfireID);
            }

            if (interactText != null)
                interactText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
            if (interactText != null)
                interactText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            SaveGame();
            Debug.Log($"Игра сохранена у костра {bonfireID} в сцене {SceneManager.GetActiveScene().name}!");
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            DeleteSaveData();
        }
    }

    void SaveGame()
    {
        if (player != null)
        {
            Vector3 position = player.transform.position;

            // Проверка, не сохраняем ли те же самые координаты
            if (PlayerPrefs.HasKey("SpawnX") && PlayerPrefs.HasKey("SpawnY") && PlayerPrefs.HasKey("SpawnZ"))
            {
                if (Mathf.Approximately(position.x, PlayerPrefs.GetFloat("SpawnX")) &&
                    Mathf.Approximately(position.y, PlayerPrefs.GetFloat("SpawnY")) &&
                    Mathf.Approximately(position.z, PlayerPrefs.GetFloat("SpawnZ")))
                {
                    Debug.Log("Позиция не изменилась, сохранение не требуется.");
                    return;
                }
            }

            Debug.Log($"СОХРАНЯЕМ: X={position.x:F2}, Y={position.y:F2}, Z={position.z:F2}");

            PlayerPrefs.SetFloat("SpawnX", position.x);
            PlayerPrefs.SetFloat("SpawnY", position.y);
            PlayerPrefs.SetFloat("SpawnZ", position.z);
            PlayerPrefs.SetInt("LastBonfireID", bonfireID);
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);

            PlayerPrefs.Save();
            Debug.Log($"Сохранено в костре с ID: {bonfireID}, координаты: ({position.x:F2}, {position.y:F2}, {position.z:F2})");
        }
        else
        {
            Debug.LogError("Ошибка сохранения: Игрок не найден!");
        }
    }

    public static void LoadSavedGame()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string lastScene = PlayerPrefs.GetString("LastScene");

            if (Application.CanStreamedLevelBeLoaded(lastScene))
            {
                SceneManager.LoadScene(lastScene);
            }
            else
            {
                Debug.LogError($"Ошибка загрузки: сцена '{lastScene}' не найдена в билде!");
            }
        }
        else
        {
            Debug.LogWarning("Нет сохранённой игры!");
        }
    }

    public static void DeleteSaveData()
    {
        Debug.Log("Удаление сохранённых данных...");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Сохранения очищены!");
    }
}
