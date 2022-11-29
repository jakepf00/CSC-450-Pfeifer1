using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
    [SerializeField] Collider _myCollider;
    List<Collider> _alreadyCollidedWith = new List<Collider>();
    int _damage = -10;
    float _knockback = 10.0f;
    #region Audio Data
    [SerializeField] int _sfxToPlay = 1;
    #endregion
    void OnEnable() {
        _alreadyCollidedWith.Clear();
    }
    void OnTriggerEnter(Collider other) {
        if (other == _myCollider) {
            return;
        }
        if (_alreadyCollidedWith.Contains(other)) {
            return;
        }
        _alreadyCollidedWith.Add(other);
        if (other.TryGetComponent<Health>(out Health health)) {
            health.HealthUpdate(_damage);
            AudioController.Instance.PlaySFX(_sfxToPlay);
        }
        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver)) {
            Vector3 direction = (other.transform.position - _myCollider.transform.position).normalized;
            forceReceiver.AddForce(direction * _knockback);
        }
    }
    public void SetAttackData(int damage, float knockback) {
        _damage = damage;
        _knockback = knockback;
    }
}