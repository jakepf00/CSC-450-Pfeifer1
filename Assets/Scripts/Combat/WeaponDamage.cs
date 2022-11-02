using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour {
    [SerializeField] Collider _myCollider;
    List<Collider> _alreadyCollidedWith = new List<Collider>();
    int _damage = -10;
    void OnEnable() {
        _alreadyCollidedWith.Clear();
    }
    void OnTriggerEnter(Collider other) {
        if (other == _myCollider) { return; }
        if (_alreadyCollidedWith.Contains(other)) { return; }
        _alreadyCollidedWith.Add(other);
        if (other.TryGetComponent<Health>(out Health health)) {
            health.HealthUpdate(_damage);
        }
    }
    public void SetAttackData(int damage) {
        _damage = damage;
    }
}
