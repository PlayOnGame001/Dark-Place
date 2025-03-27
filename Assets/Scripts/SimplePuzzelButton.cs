using UnityEngine;

public class SimplePuzzleButton : MonoBehaviour
{
    public SimplePuzzleDoor door; // Ссылка на дверь

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Если игрок наступил на плиту
        {
            Debug.Log("Игрок наступил на плиту!");
            if (door != null)
            {
                door.OpenDoor(); // Открываем дверь (делаем ее невидимой)
            }
        }
    }
}
