using UnityEngine;

public interface IUIState
{
    void Enter(GameObject uiObject);
    void Update();
    void Exit();
}

public enum UIStateType
{
    StartGame,
    Setting,
    MainMenu,
    Level,
    Game,
    EndGame,
    WinGame
}
