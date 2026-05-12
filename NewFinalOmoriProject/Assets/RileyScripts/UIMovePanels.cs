using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class UIMovePanels : MonoBehaviour
{
    public void OnButtonPressMoveThis(UIPanelTween one)
    {
        one.Toggle();
        Debug.Log("Set " + one.name + " innactive/innactive.");
    }
    public void OnButtonPressMoveThese(UIPanelTween one, UIPanelTween two)
    {
        one.Toggle();
        two.Toggle();
    }


    /*public void AnimateThis(DOTweenAnimation anim)
    {
        anim.DOPlay;
    }*/
}
