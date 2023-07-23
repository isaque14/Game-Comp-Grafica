using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private const int TimeLevel = 120;

    public void LoadScenes(string cene)
    {
        SceneManager.LoadScene(cene);
        GameController.GCInstance.TimeCount = TimeLevel;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
