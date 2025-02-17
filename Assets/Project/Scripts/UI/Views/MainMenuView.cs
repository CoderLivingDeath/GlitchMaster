using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuView : MonoBehaviour
{
    private const float SETTINGSMENU_ANIMATION_HIDE_POSITION_X = 600f;
    private const float SETTINGSMENU_ANIMATION_HIDE_POSITION_Y = 0f;

    private const float SETTINGSMENU_ANIMATION_SHOW_POSITION_X = 0f;
    private const float SETTINGSMENU_ANIMATION_SHOW_POSITION_Y = 0f;

    private const int SCENE_GAMEPLAY_ID = 1;

    #region Views
    [SerializeField] private SettingsMenuView _settingsMenu;

    #endregion

    #region Buttons
    [SerializeField] private Button _playButton;

    [SerializeField] private Button _showSettingsMenuButton;
    [SerializeField] private Button _hideSettingsMenuButton;
    #endregion

    [Inject] ISceneLoader _sceneLoader;

    [SerializeField] private float _settingMenuAnimation_duration = 1f;

    private void StartGame()
    {
        _sceneLoader.LoadScene(SCENE_GAMEPLAY_ID);
    }

    private Vector2 GetPositionShowSettingsMenu()
    {
        return new Vector2(SETTINGSMENU_ANIMATION_SHOW_POSITION_X, SETTINGSMENU_ANIMATION_SHOW_POSITION_Y);
    }

    private Vector2 GetPositionHideSettingsMenu()
    {
        return new Vector2(SETTINGSMENU_ANIMATION_HIDE_POSITION_X, SETTINGSMENU_ANIMATION_HIDE_POSITION_Y);
    }

    private void ShowSettingsMenu()
    {
        _settingsMenu.gameObject.SetActive(true);
        _settingsMenu.gameObject.transform.DOLocalMove(GetPositionShowSettingsMenu(), _settingMenuAnimation_duration);
    }

    private void HideSettingsMenu()
    {
        _settingsMenu.gameObject.transform.DOLocalMove(GetPositionHideSettingsMenu(), _settingMenuAnimation_duration)
            .OnComplete(() => _settingsMenu.gameObject.SetActive(false));
    }

    #region Events
    public void OnPlayButton_Click()
    {
        StartGame();
    }

    public void OnShowSettingsMenuButton_click()
    {
        ShowSettingsMenu();
    }

    public void OnHideSettingsMenuButton_click()
    {
        HideSettingsMenu();
    }

    #endregion

    #region Unity Methods
    private void Start()
    {

    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayButton_Click);

        _showSettingsMenuButton.onClick.AddListener(OnShowSettingsMenuButton_click);
        _hideSettingsMenuButton.onClick.AddListener(OnHideSettingsMenuButton_click);
    }

    private void OnDisable()
    {
        _showSettingsMenuButton.onClick.RemoveAllListeners();
    }

    #endregion
}
