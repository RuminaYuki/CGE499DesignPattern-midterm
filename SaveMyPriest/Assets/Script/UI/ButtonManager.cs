using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameManager gameManager;
    public void ReloadScene()
    {
        EventBus.Clear();
        Destroy(gameManager);
        
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
