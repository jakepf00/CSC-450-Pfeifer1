using UnityEngine;

public class LevelEnd : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            StartCoroutine(GameController.Instance.LevelEndCoroutine());
        }
    }
}
