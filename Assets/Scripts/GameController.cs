using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {
    #region Singleton Pattern
    public static GameController Instance { get; private set; }
    #endregion
    #region Restart Data
    [SerializeField] Vector3 _startPosition;
    Health _health;
    Ammo _ammo;
    #endregion
    #region Respawn Data
    public GameObject Player{ get; private set; }
    public Vector3 RespawnPosition { get; set; } = Vector3.zero;
    [SerializeField] Vector3 _respawnOffset;
    [SerializeField] float _respawnTime = 2.0f;
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player = GameObject.FindGameObjectWithTag("Player");
        _startPosition = Player.transform.position;
        RespawnPosition = _startPosition;
        _health = Player.GetComponent<Health>();
        _ammo = Player.GetComponent<Ammo>();
    }
    public void Restart() {
        StartCoroutine(RestartCoroutine());
    }
    IEnumerator RestartCoroutine() {
        Player.SetActive(false);
        UIController.Instance.Fading = UIController.FadeState.TO_DARK;
        yield return new WaitForSeconds(_respawnTime);
        Player.transform.position = _startPosition;
        _health.HealthReset();
        _health.UIUpdate();
        _ammo.AmmoReset();
        _ammo.UIUpdate();
        Player.SetActive(true);
        UIController.Instance.Fading = UIController.FadeState.FROM_DARK;
    }
    public void Respawn() {
        StartCoroutine(RespawnCoroutine());
    }
    IEnumerator RespawnCoroutine() {
        Player.SetActive(false);
        UIController.Instance.Fading = UIController.FadeState.TO_DARK;
        yield return new WaitForSeconds(_respawnTime);
        if (RespawnPosition == _startPosition) {
            Player.transform.position = RespawnPosition;
        }
        else {
            Player.transform.position = RespawnPosition + _respawnOffset;
        }
        Player.SetActive(true);
        UIController.Instance.Fading = UIController.FadeState.FROM_DARK;

    }
    public void PauseGame() {
        if (UIController.Instance.pauseScreen.activeInHierarchy) {
            UIController.Instance.pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else {
            UIController.Instance.pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}