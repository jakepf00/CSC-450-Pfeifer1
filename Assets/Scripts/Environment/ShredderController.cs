using UnityEngine;

public class ShredderController : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameController.Instance.Respawn();
        }
    }
}