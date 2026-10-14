using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu_Button_Manager : MonoBehaviour
{
    public GameObject play;
    public GameObject option;
    public GameObject optionPanel;
    public GameObject setting;
    public GameObject quit;
    public GameObject music;
    public Slider volume;
    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 1f);

        volume.value = savedVolume;
        AudioListener.volume = savedVolume;
    }
    public void Play() 
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void Setting() 
    {
        play.SetActive(false);        
        music.SetActive(true);
    }
    public void Option()
    {
        play.SetActive(false);        
        optionPanel.SetActive(true);        
    }
    public void Menu()
    {
        play.SetActive(true);
        optionPanel.SetActive(false);
        music.SetActive(false);
    }
    public void Quit() 
    {
        Application.Quit();
    }
    public void SetVolume(float volume) 
    {
        PlayerPrefs.SetFloat("GameVolume", volume);
        AudioListener.volume = volume;
    }
}