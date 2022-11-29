using UnityEngine;

public class HealthModifier : MonoBehaviour {
    #region Health Data
    [SerializeField] int _healthValue = 0;
    [SerializeField] float _destroyTime = 0.0f;
    #endregion
    #region Audio Data
    [SerializeField] int _sfxToPlay = -1;
    #endregion
    void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) { return; }
        if (other.TryGetComponent<Health>(out Health health)) {
            health.HealthUpdate(_healthValue);
        }
        if (_sfxToPlay >= 0) AudioController.Instance.PlaySFX(_sfxToPlay);
        if (!gameObject.CompareTag("Pickup")) { return; }

        Destroy(gameObject, _destroyTime);
    }
}