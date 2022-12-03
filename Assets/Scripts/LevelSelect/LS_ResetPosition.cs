using UnityEngine;

public class LS_ResetPosition : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            GameController.Instance.gameObject.SetActive(false);
            GameController.Instance.transform.position = Vector3.zero;
            GameController.Instance.gameObject.SetActive(true);
        }
    }
}
