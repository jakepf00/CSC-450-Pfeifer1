using UnityEngine;

public class AmmoModifier : MonoBehaviour {
    #region Ammo Data
    [SerializeField] int _ammoValue = 0;
    [SerializeField] float _destroyTime = 0.0f;
    #endregion
    #region Audio Data
    [SerializeField] int _sfxToPlay = -1;
    #endregion
    void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("Player")) { return; }
        if (other.TryGetComponent<Ammo>(out Ammo ammo)) {
            ammo.AmmoUpdate(_ammoValue);
        }
        if (_sfxToPlay >= 0) AudioController.Instance.PlaySFX(_sfxToPlay);
        if (!gameObject.CompareTag("Pickup")) { return; }
        Destroy(gameObject, _destroyTime);
    }
}