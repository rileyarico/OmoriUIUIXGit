using UnityEngine;

public class Offscreen : MonoBehaviour
{
    private Renderer objectRenderer;
    private bool ignore = false;

    void Awake()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // If the object is not visible to any camera, currently active, and we have the go ahead to do it, set innactive
        if (!objectRenderer.isVisible && ignore == false && gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }
        else if (gameObject.activeInHierarchy == false && ignore == true)
        {
            gameObject.SetActive(true);
        }
    }

    public void SetActive(Offscreen obj)
    {
        obj.ignore = true;
    }

    public void SetInvisible(Offscreen obj)
    {
        obj.ignore = false;
    }
}
