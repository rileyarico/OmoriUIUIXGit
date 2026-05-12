using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameController : MonoBehaviour
{
    
    [Tooltip("返回按钮")] public Button backBtn;
    [Tooltip("Omori按钮")] public Button profileOmoriBtn;

    [Tooltip("Info面板遮罩（Mask）")] public RectTransform profileInfoMask;
    [Tooltip("人物选中")] public CanvasGroup profileSelect;
    [Tooltip("OtherProfile")] public CanvasGroup otherProfile;
    [Tooltip("列表")] public CanvasGroup itemList;
    [Tooltip("详情")] public CanvasGroup itemDetail;

    public Toggle appleToggle;
    public Toggle watchToggle;
    public Toggle glassesToggle;
    
    public GameObject appleObj;
    public GameObject watchObj;
    public GameObject glassesObj;

    private bool _isInfo;
    private float _currentHeight;
    private float _originalHeight;
    private float _targetHeight;

    private AnimationBtn _profileOmoriAniBtn;
    private CanvasGroup _profileInfoMaskGroup;
    // Start is called before the first frame update
    void Start()
    {
        backBtn.onClick.AddListener(OnBackBtnClick);
        profileOmoriBtn.onClick.AddListener(OnProfileOmoriBtnClick);
        
        appleToggle.onValueChanged.AddListener(OnAppleToggleValueChange);
        watchToggle.onValueChanged.AddListener(OnWatchToggleValueChange);
        glassesToggle.onValueChanged.AddListener(OnGlassesToggleToggleValueChange);

        _currentHeight = profileInfoMask.sizeDelta.y;
        _originalHeight = _currentHeight;
        _targetHeight = profileInfoMask.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
        _profileOmoriAniBtn = profileOmoriBtn.GetComponent<AnimationBtn>();
        _profileInfoMaskGroup = profileInfoMask.GetComponent<CanvasGroup>();
    }
    private void OnBackBtnClick()
    {
        if (!_isInfo) return;
        _isInfo = false;
        StartCoroutine(EnterProfileList());
        _profileOmoriAniBtn.IsAnimation = true;
    }
    private void OnProfileOmoriBtnClick()
    {
        if (_isInfo) return;
        _isInfo = true;
        _profileOmoriAniBtn.IsAnimation = false;
        StartCoroutine(EnterProfileInfo());
    }
    private void OnAppleToggleValueChange(bool isOn)
    {
        appleObj.SetActive(isOn);
    }
    private void OnWatchToggleValueChange(bool isOn)
    {
        watchObj.SetActive(isOn);
    }
    private void OnGlassesToggleToggleValueChange(bool isOn)
    {
        glassesObj.SetActive(isOn);
    }

    
    private IEnumerator EnterProfileInfo()
    {
        // Debug.Log($"移动卡片，调整旋转、位置，隐藏其他卡片");
        otherProfile.DOFade(0, 0.3f);
        profileOmoriBtn.transform.DOLocalMove(new Vector3(0, 130, 0), 0.3f);
        profileOmoriBtn.transform.DORotate(new Vector3(0, 0, 0), 0.3f);
        yield return new WaitForSeconds(0.3f);
        // Debug.Log($"隐藏卡片选中效果，显示Mask拉大Mask高度");
        profileSelect.DOFade(0, 0.3f);
        _profileInfoMaskGroup.alpha = 1;
        // 使用 DOTween.To 进行 float 插值
        DOTween.To(() => _currentHeight,    // getter：返回当前float值
                x => _currentHeight = x, // setter：接收float值并赋值给临时变量
                _targetHeight,           // 目标值（float）
                0.3f)               // 时长（float）
            .OnUpdate(() => {
                // 每帧更新UI的实际高度
                // Debug.Log($"每帧更新UI的实际高度{currentHeight}");
                Vector2 size = profileInfoMask.sizeDelta;
                size.y = _currentHeight;
                profileInfoMask.sizeDelta = size;
            });
        yield return new WaitForSeconds(0.2f);
        // Debug.Log($"显示列表");
        itemList.DOFade(1, 0.3f);
        yield return new WaitForSeconds(0.2f);
        // Debug.Log($"显示详情");
        itemDetail.DOFade(1, 0.3f);
    }
    private IEnumerator EnterProfileList()
    {
        itemDetail.DOFade(0, 0.3f);
        itemList.DOFade(0, 0.3f);
        yield return new WaitForSeconds(0.2f);
        DOTween.To(() => _currentHeight,    // getter：返回当前float值
                x => _currentHeight = x, // setter：接收float值并赋值给临时变量
                _originalHeight,           // 目标值（float）
                0.3f)               // 时长（float）
            .OnUpdate(() => {
                // 每帧更新UI的实际高度
                // Debug.Log($"每帧更新UI的实际高度{_currentHeight}");
                Vector2 size = profileInfoMask.sizeDelta;
                size.y = _currentHeight;
                profileInfoMask.sizeDelta = size;
            });
        yield return new WaitForSeconds(0.3f);
        _profileInfoMaskGroup.alpha = 0;
        otherProfile.DOFade(1, 0.3f);
        profileOmoriBtn.transform.DOLocalMove(new Vector3(0, 0, 0), 0.3f);
        profileOmoriBtn.transform.DORotate(new Vector3(0, 0, 0), 0.3f);
    }
}
