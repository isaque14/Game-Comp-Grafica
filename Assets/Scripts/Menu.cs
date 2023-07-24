using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const int TimeLevel = 120;
    private const int InitialLives = 3;

    public void LoadScenes(string cene)
    {
        SceneManager.LoadScene(cene);
        GameController.GCInstance.TimeCount = TimeLevel;
        GameController.GCInstance.Lives = InitialLives;
        GameController.GCInstance.Coins = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
