using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {


    //public GameObject settings;
    public AudioMixer audioMixer;

    private void OnPreRender()
    {
        getVolume();
    }

    public void setVolume(float volume)
    {
        //Debug.Log("vol");
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();

        
    }
    public void getVolume()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }
        //пример для уровней
        /*if (PlayerPrefs.HasKey("savedLevel"))
        {
            // there is a saved level, load that one
            Application.LoadLevel(PlayerPrefs.GetInt("savedLevel"));
        }
        else
        {
            // no saved level, load the first one
            Application.LoadLevel(1);
        }*/

    }

}
