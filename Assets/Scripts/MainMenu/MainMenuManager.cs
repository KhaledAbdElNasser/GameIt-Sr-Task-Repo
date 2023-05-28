using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void Scene1()
    {
        SceneManager.LoadScene(GameConstants.Scene1Scene);
    }
    
    public void Scene2()
    {
        SceneManager.LoadScene(GameConstants.Scene2Scene);
    }
}
