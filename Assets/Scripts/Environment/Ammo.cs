using UnityEngine;

public class Ammo : MonoBehaviour {
    #region Ammo Data
    [SerializeField] int _ammoStarting = 0;
    int _ammoCurrent = 0;
    #endregion
    public bool IsBroke => _ammoCurrent == 0;
    void Start() {
        AmmoReset();
        UIUpdate();
    }
    public void AmmoUpdate(int update) {
        _ammoCurrent = Mathf.Max(_ammoCurrent + update, 0);
        UIUpdate();
    }
    public void AmmoReset() {
        _ammoCurrent = _ammoStarting;
    }
    public void UIUpdate() {
        UIController.Instance._ammoText.text = _ammoCurrent.ToString();
    }
}