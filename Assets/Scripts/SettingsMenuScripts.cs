using UnityEngine;

public class SettingsMenuScripts : MonoBehaviour
{
    public GameObject soundPanel;
    public GameObject lightPanel;
   

    private void Start()
    {
        CloseAllPanels(); // �������� ��� ������ ��� �������
        
    }

    private void CloseAllPanels()
    {
        soundPanel.SetActive(false);
        lightPanel.SetActive(false);
       
    }

    public void OpenSoundPanel()
    {
        CloseAllPanels();
        soundPanel.SetActive(true);
    }

    public void OpenLightPanel()
    {
        CloseAllPanels();
        lightPanel.SetActive(true);
    }

}
