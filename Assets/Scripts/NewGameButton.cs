using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void StartNewGame()
    {
        Debug.Log("Нажата кнопка 'Новая игра'. Удаляем сохранения...");
        SpawnPoint.DeleteSaveData(); // Удаляем все старые данные сохранения

        string firstSceneName = "SampleScene"; // Название первой сцены
        Debug.Log("Загружаем сцену: " + firstSceneName);
        SceneManager.LoadScene(firstSceneName);
    }
}
