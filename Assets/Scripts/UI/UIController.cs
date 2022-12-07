using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour {
    #region Singleton Pattern
    public static UIController Instance { get; private set; }
    #endregion
    #region UI Screen Data
    Image _fadeScreen;
    public GameObject pauseScreen;
    public GameObject optionsScreen;
    public Slider musicSlider;
    public Slider sfxSlider;
    #endregion
    #region UI Data
    public TextMeshProUGUI _healthText;
    public Slider _healthSlider;
    public TextMeshProUGUI _ammoText;
    #endregion
    #region Fade Data
    public enum FadeState { IDLE, FROM_DARK, TO_DARK }
    public FadeState Fading { get; set; }
    [SerializeField] float _fadeTime = 3.0f;
    #endregion
    #region Scene Data
    [SerializeField] string _mainMenu;
    [SerializeField] string _levelSelect;
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
        pauseScreen = GameObject.Find("Pause Screen");
        _fadeScreen = GameObject.Find("Fade Screen").GetComponent<Image>();
        Fading = FadeState.FROM_DARK;
        CloseOptions();
        Resume();
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
    public void Resume() {
        GameController.Instance.PauseGame();
    }

    public void OpenOptions() {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions() {
        optionsScreen.SetActive(false);
    }
    public void LevelSelect() {
        SceneManager.LoadScene(_levelSelect);
        Time.timeScale = 1.0f;
    }
    public void MainMenu() {
        SceneManager.LoadScene(_mainMenu);
        Time.timeScale = 1.0f;
    }
    public void SetMusicLevel() {
        AudioController.Instance.SetMusicLevel();
    }
    public void SetSFXLevel() {
        AudioController.Instance.SetSFXLevel();
    }
}