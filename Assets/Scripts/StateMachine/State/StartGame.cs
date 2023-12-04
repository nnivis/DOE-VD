using UnityEngine;

public class StartGame : IUIState
{
    private GameObject _uiStateObject;

    public void Enter(GameObject uiObject)
    {
        _uiStateObject = uiObject;
        _uiStateObject.SetActive(true);


        UIStartGameState _uistartGameState = _uiStateObject.GetComponent<UIStartGameState>();

        _uistartGameState.Setup();
        _uistartGameState.StartAnimation();

    }

    public void Update()
    {

    }

    public void Exit()
    {
        _uiStateObject.SetActive(false);
    }
}
