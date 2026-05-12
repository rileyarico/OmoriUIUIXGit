using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIPanelTween : MonoBehaviour
{
    [Header("References")]
    public RectTransform panel;
    public CanvasGroup canvasGroup;

    [Header("Animation Settings")]
    public float duration = 0.3f;
    public Vector2 hiddenOffset = new Vector2(0, -200);
    public float scaleFrom = 0.9f;
    public Ease ease = Ease.OutCubic;

    private Sequence openSequence;
    private Sequence closeSequence;
    private Tween tween1;

    private Vector2 shownPosition;

    public bool startAwake = false;
    void Awake()
    {
        if (panel == null) panel = GetComponent<RectTransform>();
        if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();

        shownPosition = panel.anchoredPosition;

        SetupSequences();
        if (!startAwake)
        {
            SetHiddenInstant();
        }
    }

    void SetupSequences()
    {
        // Opening sequence
        openSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .Pause();

        tween1 = panel.DOAnchorPos(shownPosition, duration).SetEase(ease);

        openSequence.Append(tween1); //this line is the equivalent of the commented out line below! We can store tweens in variables as type Tween.

       // openSequence.Append(panel.DOAnchorPos(shownPosition, duration).SetEase(ease)); 

        openSequence.Join(canvasGroup.DOFade(1, duration));
        openSequence.Join(panel.DOScale(1f, duration));

        // CLOSE SEQUENCE
        closeSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .Pause();

        closeSequence.Append(panel.DOAnchorPos(shownPosition + hiddenOffset, duration).SetEase(Ease.InCubic));
        closeSequence.Join(canvasGroup.DOFade(0, duration));
        closeSequence.Join(panel.DOScale(scaleFrom, duration));

        closeSequence.AppendCallback(() =>
        {
            gameObject.SetActive(false);
        });
    }

    public void Open()
    {
        gameObject.SetActive(true); 

        // Reset state before playing again
        panel.anchoredPosition = shownPosition + hiddenOffset;
        canvasGroup.alpha = 0;
        panel.localScale = Vector3.one * scaleFrom;

        closeSequence.Pause();
        openSequence.Restart();
    }

    public void Close()
    {
        openSequence.Pause();
        closeSequence.Restart();
    }

    public void Toggle()
    {
        if (gameObject.activeSelf)
            Close();
        else
            Open();
    }

    void SetHiddenInstant()
    {
        panel.anchoredPosition = shownPosition + hiddenOffset;
        canvasGroup.alpha = 0;
        panel.localScale = Vector3.one * scaleFrom;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        // Safety: stop any running tweens when pooled/disabled
        DOTween.Kill(panel);
    }
}



