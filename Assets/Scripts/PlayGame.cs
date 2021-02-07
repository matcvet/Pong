using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("MainGame");
    }
}
