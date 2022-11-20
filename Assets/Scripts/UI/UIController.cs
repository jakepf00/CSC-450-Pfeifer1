using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    #region Singleton Pattern
    public static UIController Instance { get; private set; }
    #endregion
    #region UI Data
    public TextMeshProUGUI _healthText;
    public Slider _healthSlider;
    public TextMeshProUGUI _ammoText;
    #endregion
    #region Fade Data
    Image _fadeScreen;
    public enum FadeState { IDLE, FROM_DARK, TO_DARK }
    public FadeState Fading { get; set; }
    [SerializeField] float _fadeTime = 3.0f;
    #endregion
    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this); // Already exists
        }
        else {
            Instance = this; // First one
        }
    }
    void Start() {
        _fadeScreen = GameObject.Find("Fade Screen").GetComponent<Image>();
        Fading = FadeState.FROM_DARK;
    }
    void Update() {
        switch(Fading) {
            case FadeState.FROM_DARK:
                _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b,
                    Mathf.MoveTowards(_fadeScreen.color.a, 0.0f, _fadeTime * Time.deltaTime));
                if (_fadeScreen.color.a.Equals(0.0f)) {
                    Fading = FadeState.IDLE;
                }
                break;
            case FadeState.TO_DARK:
                _fadeScreen.color = new Color(_fadeScreen.color.r, _fadeScreen.color.g, _fadeScreen.color.b,
                    Mathf.MoveTowards(_fadeScreen.color.a, 1.0f, _fadeTime * Time.deltaTime));
                if (_fadeScreen.color.a.Equals(1.0f)) {
                    Fading = FadeState.IDLE;
                }
                break;
        }
    }
}