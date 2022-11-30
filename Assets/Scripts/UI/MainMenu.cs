using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    #region Scene Data
    [SerializeField] string _levelSelect;
    [SerializeField] string _firstLevel;
    #endregion

    public void ContinueGame() {
        SceneManager.LoadScene(_levelSelect);
    }
    public void NewGame() {
        SceneManager.LoadScene(_firstLevel);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
