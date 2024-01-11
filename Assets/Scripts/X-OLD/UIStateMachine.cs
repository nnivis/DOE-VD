using UnityEngine;

public class UIStateMachine
{
    private IUIState currentState;

    public void ChangeState(IUIState newState, GameObject uiObject)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter(uiObject);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
    }
}
