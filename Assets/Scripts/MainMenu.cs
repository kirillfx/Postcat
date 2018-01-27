using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlaySound()
    {
        //TODO: добавить задрежку для проигрывания звука слайдера - зайдает
        FindObjectOfType<AudioManager>().Play("btn");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
