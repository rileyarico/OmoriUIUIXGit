using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class UIButtonTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Transform button;

    [Header("Settings")]
    public float hoverScale = 1.2f;
    public float duration = 0.2f;
    public Ease ease = Ease.OutBack;

    private Vector3 originalScale;
    private Tween hoverTween;


    void Awake()
    {
        originalScale = button.localScale;

        // Create tween but DO NOT play it yet
        hoverTween = button.DOScale(hoverScale, duration)
            .SetEase(ease)
            .SetAutoKill(false)
            .Pause();
    }


    public void HoverIn()
    {
        hoverTween.Kill(); // safety reset

        hoverTween = button.DOScale(hoverScale, duration)
            .SetEase(ease);

        hoverTween.Play();
    }


    public void HoverOut()
    {
        hoverTween?.Kill();

       hoverTween = button.DOScale(originalScale, duration)
            .SetEase(Ease.OutQuad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        HoverIn();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
        HoverOut();
    }
}