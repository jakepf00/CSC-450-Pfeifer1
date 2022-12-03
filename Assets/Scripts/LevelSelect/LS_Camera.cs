using UnityEngine;

public class LS_Camera : MonoBehaviour {
    #region Camera Data
    [SerializeField] Transform _target;
    [SerializeField] Vector3 _offset = Vector3.zero;
    #endregion

    void Start() {
        // _offset = transform.position - _target.position;
    }
    void Update() {
        transform.position = _target.position + _offset;
    }
}
