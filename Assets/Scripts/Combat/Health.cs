using UnityEngine;

public class Health : MonoBehaviour {
    #region Health Data
    [SerializeField] int _healthMaximum = 100;
    int _healthCurrent = 0;
    #endregion
    public bool IsDead() => _healthCurrent == 0;
    void Start() {
        HealthReset();
    }
    public void HealthUpdate(int update) {
        if (_healthCurrent == 0) { return; }
        if (update > 0) {
            _healthCurrent = Mathf.Min(_healthCurrent + update, _healthMaximum);
        }
        else if (update < 0) {
            _healthCurrent = Mathf.Max(_healthCurrent + update, 0);
        }
    }
    public void HealthReset() {
        _healthCurrent = _healthMaximum;
    }
}
