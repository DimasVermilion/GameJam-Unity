using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPanel, logo, settingPanel, aboutPanel;
    [SerializeField] Button firstButton, loadButton;
    [SerializeField] string firstScene = "Stage1";

    void Start()
    {
        ShowMenu();
        loadButton.interactable = PlayerPrefs.HasKey("stage");
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteKey("stage");
        SceneManager.LoadScene(firstScene);
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("stage"))
            SceneManager.LoadScene(PlayerPrefs.GetString("stage"));
    }

    public void OpenSetting() => ShowPopup(settingPanel);
    public void OpenAbout()   => ShowPopup(aboutPanel);
    public void CloseAll()    => ShowMenu();

    void ShowPopup(GameObject popup)
    {
        menuPanel.SetActive(false);
        logo.SetActive(false);
        settingPanel.SetActive(popup == settingPanel);
        aboutPanel.SetActive(popup == aboutPanel);
    }

    void ShowMenu()
    {
        settingPanel.SetActive(false);
        aboutPanel.SetActive(false);
        menuPanel.SetActive(true);
        logo.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButton.gameObject);
    }
}