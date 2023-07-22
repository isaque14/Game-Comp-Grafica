using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScenes(string cene)
    {
        SceneManager.LoadScene(cene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
