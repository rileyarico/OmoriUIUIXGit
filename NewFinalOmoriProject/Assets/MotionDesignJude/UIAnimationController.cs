using UnityEngine;

public class UIAnimationController : MonoBehaviour
{
    public UIPanelTween leftPanel;
    public UIPanelTween rightPanel;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            leftPanel.Toggle();
            rightPanel.Toggle();
        }
    }
}
