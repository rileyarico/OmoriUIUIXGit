using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationHandler : MonoBehaviour
{
    public void PlayAnim(DOTweenAnimation animation)
    {
        Debug.Log("This is set active: " + animation.isActive);
       
        animation.DOPlay();
        animation.gameObject.SetActive(true);
    }

    public void StopAnim(DOTweenAnimation animation)
    {
        

        Tween tween = animation.tween;
        Debug.Log("tween is " + tween);
        //if (tween != null)
        //{
            tween.OnRewind(() =>
            {
                Debug.Log("Tween has been rewound. Setting innactive");
                animation.gameObject.SetActive(false);
                animation.DOPause();
            });
        // }
        animation.DORewind();
        tween.OnRewind(() =>
        {
            Debug.Log("I hope this resets man");
            //OMFG it does bless up
        });
    }


    public void HighlightNext(GameObject gameObj)
    {
        //clear what is currently highlighted
        EventSystem.current.SetSelectedGameObject(null);
        //set to next given button
        EventSystem.current.SetSelectedGameObject(gameObj);
    }
}
