using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;  // Слайдер для регулировки громкости
    public AudioListener audioListener;  // Ссылка на AudioListener

    void Start()
    {
        // Устанавливаем начальное значение громкости из текущего состояния
        volumeSlider.value = AudioListener.volume;

        // Добавляем слушателя для слайдера
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // Метод, который вызывается при изменении значения слайдера
    void OnVolumeChanged(float value)
    {
        // Изменяем громкость в игре в зависимости от значения слайдера
        AudioListener.volume = value;
    }
}
