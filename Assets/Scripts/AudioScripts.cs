using UnityEngine;
using UnityEngine.Audio;

public class AudioScripts : MonoBehaviour
{
    [SerializeField]
    private AudioMixer audioMixer;
    private const string ambientParam = "AmbientVolume";
    private const string effectParam = "EffectsVolume";  // Исправлено
    private const string musicParam = "MusicVolume";
    private const string masterParam = "MasterVolume";

    private float MasterVolume;

    void Start()
    {
        audioMixer.SetFloat(ambientParam, -10.0f);  // Исправлено
        audioMixer.SetFloat(effectParam, -7.0f);
        audioMixer.SetFloat(musicParam, -5.0f);
        audioMixer.SetFloat(masterParam, -10.0f);  // Убран `out`
    }

    void Update()
    {
        float masterVolume;
        float step = 0;

        if (audioMixer.GetFloat(masterParam, out masterVolume) && Input.GetKeyDown(KeyCode.UpArrow))
        {
            step = 5 + Mathf.Abs(masterVolume + 5) * 0.25f;
            masterVolume = Mathf.Clamp(masterVolume + step, -80.0f, 20.0f);
        }
        else if (audioMixer.GetFloat(masterParam, out masterVolume) && Input.GetKeyDown(KeyCode.DownArrow))
        {
            step = 5 + Mathf.Abs(masterVolume + 5) * 0.25f;
            masterVolume = Mathf.Clamp(masterVolume - step, -80.0f, 20.0f);
        }

        if (step > 0)
        {
            audioMixer.SetFloat(masterParam, masterVolume);
        }
    }

    private void ChangedMasterVolume(bool isLouder)
    {
        if (audioMixer.GetFloat(masterParam, out float volume))  // Исправлено
        {
            // Здесь можно добавить логику изменения громкости
        }
    }
}
