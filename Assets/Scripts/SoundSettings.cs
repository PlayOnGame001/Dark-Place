using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider volumeSlider;  // ������� ��� ����������� ���������
    public AudioListener audioListener;  // ������ �� AudioListener

    void Start()
    {
        // ������������� ��������� �������� ��������� �� �������� ���������
        volumeSlider.value = AudioListener.volume;

        // ��������� ��������� ��� ��������
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // �����, ������� ���������� ��� ��������� �������� ��������
    void OnVolumeChanged(float value)
    {
        // �������� ��������� � ���� � ����������� �� �������� ��������
        AudioListener.volume = value;
    }
}
