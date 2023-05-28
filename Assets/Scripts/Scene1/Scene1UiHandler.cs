using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1UiHandler : MonoBehaviour
{
    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(GameConstants.mainMenuScene);
    }
}
