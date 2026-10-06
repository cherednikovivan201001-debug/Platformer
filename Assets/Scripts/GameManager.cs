using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private EventBoost _inet;

    [SerializeField] private PlayerInputManager _inputmen;

    private GameState _gameState = GameState.Systems;

    public GameState CurrentGameState => _gameState;

    public EventBoost Inet => _inet;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;

        DontDestroyOnLoad(this);

        _inputmen.Init(_inet);

        _inet._OnButtonClick += OnUiButton;

        OnStateRequest(GameState.MainMenu);
    }

    private void OnUiButton(ButtonType type)
    {
        switch (type)
        {
            case ButtonType.Start:
                OnStateRequest(GameState.Playing);
                break;

            case ButtonType.Info:
                break;

            case ButtonType.Settings:
                break;

            case ButtonType.Exit:
                Application.Quit();
                break;

            case ButtonType.MainMenu:
                OnStateRequest(GameState.MainMenu);
                break;

        }
    }

    private void OnDestroy()
    {

    }

    private void OnStateRequest(GameState newState)
    {
        if (_gameState == newState)
        {
            return;
        }

        switch (newState)
        {
            case GameState.Playing:
                LoadtoScene(SceneList._playingSceneName);
                break;

            case GameState.MainMenu:
                LoadtoScene(SceneList._mainSceneName);
                Time.timeScale = 1;
                break;

            case GameState.Paused:
                if (_gameState == GameState.GameOver || _gameState == GameState.MainMenu)
                {
                    Time.timeScale = 0;
                }
                break;

            case GameState.GameOver:
                break;

        }

        _gameState = newState;
    }

    private void LoadtoScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        MainMenu,
        Systems,
    }

