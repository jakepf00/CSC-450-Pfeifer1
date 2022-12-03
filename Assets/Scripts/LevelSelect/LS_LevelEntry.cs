using UnityEngine;
using UnityEngine.SceneManagement;

public class LS_LevelEntry : MonoBehaviour {
    #region Level Entry Data
    [SerializeField] string _levelName;
    bool _canLoadLevel = false;
    [SerializeField] GameObject _player;
    #endregion

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _canLoadLevel = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _canLoadLevel = false;
        }
    }
    void OnEnable() {
        _player.GetComponent<PlayerStateMachine>().InputReader.JumpEvent += OnJump;
    }
    void OnDisable() {
        _player.GetComponent<PlayerStateMachine>().InputReader.JumpEvent -= OnJump;
    }
    void OnJump() {
        if (_canLoadLevel) {
            SceneManager.LoadScene(_levelName);
        }
    }
}
