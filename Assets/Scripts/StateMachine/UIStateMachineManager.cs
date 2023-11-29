using UnityEngine;

public class UIStateMachineManager : MonoBehaviour
{
    private UIStateMachine _stateMachine;
    private IUIStateFactory _stateFactory;

    [SerializeField] private GameObject _startGameUIObject;
    [SerializeField] private GameObject _settingUIObject;
    [SerializeField] private GameObject _mainMenuUIObject;
    [SerializeField] private GameObject _diceMenuObject;
    [SerializeField] private GameObject _levelgUIObject;
    [SerializeField] private GameObject _gameUIObject;
    [SerializeField] private GameObject _engGameUIObject;
    [SerializeField] private GameObject _winGameUIObject;

    public void SetupUIManager()
    {
        _stateMachine = new UIStateMachine();
        _stateFactory = new UIStateFactory();
    }

    public void StartUIManager()
    {
        CloseAllUI();
        
        SetState(UIStateType.StartGame);
    }

    public void SetState(UIStateType stateType)
    {
        GameObject uiObject = GetUIObjectForState(stateType);
        IUIState newState = CreateUIState(stateType);
        _stateMachine.ChangeState(newState, uiObject);
    }

    private GameObject GetUIObjectForState(UIStateType stateType)
    {
        switch (stateType)
        {
            case UIStateType.StartGame:
                return _startGameUIObject;
            case UIStateType.Setting:
                return _settingUIObject;
            case UIStateType.MainMenu:
                return _mainMenuUIObject;
            case UIStateType.DiceMenu:
                return _diceMenuObject;
            case UIStateType.Level:
                return _levelgUIObject;
            case UIStateType.Game:
                return _gameUIObject;
            case UIStateType.EndGame:
                return _engGameUIObject;
            case UIStateType.WinGame:
                return _winGameUIObject;
            default:
                return null;
        }
    }

    public void CloseAllUI()
    {
        _startGameUIObject.SetActive(false);
        _settingUIObject.SetActive(false);
        _mainMenuUIObject.SetActive(false);
        _diceMenuObject.SetActive(false);
        _levelgUIObject.SetActive(false);
        _gameUIObject.SetActive(false);
        _engGameUIObject.SetActive(false);
        _winGameUIObject.SetActive(false);
    }
    private IUIState CreateUIState(UIStateType stateType)
    {
        return _stateFactory.Create(stateType);
    }

    public void StartGame()
    {
        SetState(UIStateType.StartGame);
    }

    public void OpenSettings()
    {
        SetState(UIStateType.Setting);
    }

    public void MainMenu()
    {
        SetState(UIStateType.MainMenu);
    }

    public void DiceMenu()
    {
        SetState(UIStateType.DiceMenu);
    }


    public void Level()
    {
        SetState(UIStateType.Level);
    }

    public void Game()
    {
        SetState(UIStateType.Game);
    }

    public void WinGame()
    {
        SetState(UIStateType.WinGame);
    }

    public void EndGame()
    {
        SetState(UIStateType.EndGame);
    }
}
