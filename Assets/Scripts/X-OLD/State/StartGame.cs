using System.Collections;
using UnityEngine;

public class StartGame : IUIState
{
    private GameObject _uiStateObject;
    private const float _timeForDelay = 3.5f;
    public void Enter(GameObject uiObject)
    {

        _uiStateObject = uiObject;
        _uiStateObject.SetActive(true);

        UIStartGameAnimationState _uistartGameState = _uiStateObject.GetComponent<UIStartGameAnimationState>();
        
        _uistartGameState.Setup();
        _uistartGameState.StartAnimation();

    }

    public void Update()
    {

    }

    public void Exit()
    {
        UIStartGameAnimationState _uistartGameState = _uiStateObject.GetComponent<UIStartGameAnimationState>();

        _uistartGameState.Setup();
        _uistartGameState.StopAnimation();

        _uiStateObject.SetActive(false);
    }

}
