using System;
using UnityEngine;
[Serializable]

public class Attack {
    #region Animation Data
    [field: SerializeField] public string AnimationName { get; private set; }
    [field: SerializeField] public float TransitionTime { get; private set; } = 0.1f;
    #endregion
    #region Combo Attack Data
    [field: SerializeField] public int ComboIndex { get; private set; } = -1;
    [field: SerializeField] public float ComboTime { get; private set; } = 0.0f;
    #endregion
    #region Force Data
    [field: SerializeField] public float Force { get; private set; } = 15.0f;
    [field: SerializeField] public float ForceTime {get; private set; } = 0.35f;
    #endregion
    #region Attack Data
    [field: SerializeField] public int Damage { get; private set; } = -10;
    #endregion
}
