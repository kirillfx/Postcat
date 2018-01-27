using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;

	// Use this for initialization
	void Awake () {

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    private void Start()
    {
        Play("MenuTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found, name: " + name);
            return;
        }
        else
        {
            s.source.Play();
        }
    }


    public void setVolume(float volume)
    {
        //audioMixer.SetFloat("volume", volume);
        Debug.Log(volume);
        foreach (Sound s in sounds)
        {
           // s.source.Stop();
            s.volume = volume;
            s.source.volume = volume;
            Debug.Log(volume);
        }

        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save();
    


    }
}
