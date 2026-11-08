using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, settingPanel, aboutPanel;
    [SerializeField] Button firstButton, loadButton;
    [SerializeField] string firstScene = "Stage1";

    void Start()
    {
        Show(menuPanel);
        loadButton.interactable = PlayerPrefs.HasKey("stage");
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("stage");
        SceneManager.LoadScene(firstScene);
    }

    public void LoadGame() => SceneManager.LoadScene(PlayerPrefs.GetString("stage"));
    public void OpenSetting() => Show(settingPanel);
    public void OpenAbout() => Show(aboutPanel);
    public void Back() => Show(menuPanel);

    void Show(GameObject p)
    {
        menuPanel.SetActive(p == menuPanel);
        settingPanel.SetActive(p == settingPanel);
        aboutPanel.SetActive(p == aboutPanel);
    }
}