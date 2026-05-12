using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationBtn : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public CanvasGroup highLight;
    private IPointerEnterHandler _pointerEnterHandlerImplementation;
    private IPointerExitHandler _pointerExitHandlerImplementation;

    public bool IsAnimation
    {
        get;
        set;
    }
    private void Awake()
    {
        OnPointerExit();
        IsAnimation = true;
    }
    public void OnPointerEnter(Transform btn)
    {
        
    }
    public void OnPointerExit()
    {
        if (!IsAnimation) return;
        highLight.alpha = 0;
        transform.DOLocalMove(new Vector3(0, 0, 0), 0.2f);
        transform.DORotate(new Vector3(0, 0, 0), 0.2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // _pointerEnterHandlerImplementation.OnPointerEnter(eventData);
        if (!IsAnimation) return;
        highLight.alpha = 1;
        transform.DOLocalMove(new Vector3(20, 20, 0), 0.3f);
        transform.DORotate(new Vector3(0, 0, -3), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // _pointerExitHandlerImplementation.OnPointerExit(eventData);
        if (!IsAnimation) return;
        highLight.alpha = 0;
        transform.DOLocalMove(new Vector3(0, 0, 0), 0.2f);
        transform.DORotate(new Vector3(0, 0, 0), 0.2f);
    }
}
