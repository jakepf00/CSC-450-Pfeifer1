using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
    #region Singleton Pattern
    public static AudioController Instance { get; private set; }
    #endregion
    #region Audio Data
    [SerializeField] AudioSource[] _musicList;
    [SerializeField] AudioSource[] _sfxList;
    [SerializeField] int _levelMusicToPlay = 0;
    [SerializeField] AudioMixerGroup _musicMixer;
    [SerializeField] AudioMixerGroup _sfxMixer;
    #endregion

    void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    void Start() {
        PlayMusic(_levelMusicToPlay);
    }
    public void PlayMusic(int musicToPlay) {
        foreach (var music in _musicList) {
            music.Stop();
        }
        _musicList[musicToPlay].Play();
    }
    public void PlaySFX(int sfxToPlay) {
        _sfxList[sfxToPlay].Play();
    }
    public void SetMusicLevel() {
        _musicMixer.audioMixer.SetFloat("MusicLevel", UIController.Instance.musicSlider.value);
    }
    public void SetSFXLevel() {
        _musicMixer.audioMixer.SetFloat("SFXLevel", UIController.Instance.sfxSlider.value);
    }
}