using UnityEngine;

public class ChangeScene : MonoBehaviour {

    private const string MAINGAME = "MainGame";
    private const string STARTMENU = "StartMenu";
    private const string COMPLETE = "LevelComplete";
    
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MAINGAME);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(STARTMENU);
    }

    public void CompleteGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(COMPLETE);
    }
}
