using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour
{
    public void ClickToNext(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
