using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightManager : MonoBehaviour
{
    public GameObject active;
    private GameObject currentlyHighlighted;
    private OnSelected selected;

    private void Update()
    {
        //grab currently highlighted selectable from eventSystems
        currentlyHighlighted = EventSystem.current.currentSelectedGameObject;
        selected = currentlyHighlighted.GetComponent<OnSelected>();
        if (selected != null)
        {
            //Debug.Log("Found something at highlightManager");
            if (active != null && active != selected.toMakeActive)
            {
                Debug.Log("Set active to false");
                active.SetActive(false);
                active = null;
            }
            active = selected.toMakeActive;
            active.SetActive(true);
            selected.toMakeActive.SetActive(true);
            Debug.Log("This object is set to " + active.activeSelf);
        }
        else
        {
            if (active != null)
            {
                active.SetActive(false);
                active = null;
            }
        }
    }
    
}
