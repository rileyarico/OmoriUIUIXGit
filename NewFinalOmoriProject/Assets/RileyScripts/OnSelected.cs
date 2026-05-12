using UnityEngine;
using UnityEngine.EventSystems;

public class OnSelected : MonoBehaviour
{
    public GameObject toMakeActive;
    private GameObject currentHighlight;

    private void Update()
    {
        /*currentHighlight = EventSystem.current.currentSelectedGameObject;
        if(this == currentHighlight)
        {
            Debug.Log(gameObject.name + " is highlighted.");
            toMakeActive.SetActive(true);
        }
        else
        {
            toMakeActive.SetActive(false);
        }*/
    }
}
