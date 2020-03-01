using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    public int level;
    public void LoadLeve()
    {
        // load new scene of int value
        SceneManager.LoadScene(level);
    }
    public void RestartLevel()
    {
        //restart
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
