using UnityEngine;

public class SimplePuzzleDoor : MonoBehaviour
{
    private bool isDoorOpen = false;

    public void OpenDoor()
    {
        if (!isDoorOpen)
        {
            gameObject.SetActive(false); // Делаем дверь невидимой
            if (GetComponent<Collider>() != null)
            {
                GetComponent<Collider>().enabled = false; // Отключаем коллайдер
            }
            isDoorOpen = true;
            Debug.Log("Дверь исчезла!");
        }
    }
}
