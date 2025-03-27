using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("MenuCanvas"));
        SceneManager.LoadScene(1);
    }
}
