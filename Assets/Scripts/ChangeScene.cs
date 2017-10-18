using UnityEngine;

public class ChangeScene : MonoBehaviour {

    public string MainGame;
    
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainGame);
    }
}
