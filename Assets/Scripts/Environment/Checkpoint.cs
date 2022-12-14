using UnityEngine;

public class Checkpoint : MonoBehaviour {
    #region Checkpoint Data
    [SerializeField] GameObject _checkpointOFF;
    [SerializeField] GameObject _checkpointON;
    [SerializeField] Vector3 _position = Vector3.zero;
    #endregion
    #region Audio Data
    [SerializeField] int _sfxToPlay = 3;
    #endregion
    void Start() {
        _checkpointOFF.SetActive(true);
        _checkpointON.SetActive(false);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
            foreach (var checkpoint in checkpoints) {
                checkpoint._checkpointOFF.SetActive(true);
                checkpoint._checkpointON.SetActive(false);
            }
            _checkpointOFF.SetActive(false);
            _checkpointON.SetActive(true);
            AudioController.Instance.PlaySFX(_sfxToPlay);

            GameController.Instance.RespawnPosition = gameObject.transform.position;
        }
    }
}