using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    private void Update()
    {
        if(Keyboard.current.pKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("BetweenScenes");
        }
    }
}
