using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const int TimeLevel = 300;
    private const int InitialLives = 3;

    public void LoadScenes(string cene)
    {
        SceneManager.LoadScene(cene);
        GameController.GCInstance.TimeCount = TimeLevel;
        GameController.GCInstance.Lives = InitialLives;
        GameController.GCInstance.Coins = 0;
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = true;
    }

    public void ButtonReturn(string cene)
    {
        SceneManager.LoadScene(cene);
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
