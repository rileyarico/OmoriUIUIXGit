using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoManager : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    private GameObject currentlyHighlighted;
    private ButtonInfoHolder highlightedInfo;

    private void Update()
    {
        //grab currently highlighted selectable from eventSystems
        currentlyHighlighted = EventSystem.current.currentSelectedGameObject;
        highlightedInfo = currentlyHighlighted.GetComponent<ButtonInfoHolder>();
        if (highlightedInfo != null)
        {
            textBox.text = highlightedInfo.textboxMessage;
        }
        else
        {
            textBox.text = "...";
        }
    }
}
