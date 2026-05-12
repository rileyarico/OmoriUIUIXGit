using UnityEngine;
using DG.Tweening;

public class PlayAnimations : MonoBehaviour
{
    //public DOTweenAnimation anim;

    /*public void PlayAnim(DOTweenAnimation animation)
    {
        if(animation.gameObject.activeSelf == false) animation.gameObject.SetActive(true);
        animation.DOPlay();
    }*/
    
    public void ToggleActivity(GameObject gameObject)
    {
        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
            return;
        }

        if(gameObject.activeSelf) gameObject.SetActive(false);
        return;
    }
}
