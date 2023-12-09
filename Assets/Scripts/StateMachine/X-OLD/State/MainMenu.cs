using UnityEngine;

public class MainMenu : IUIState
{
    private GameObject _uiObject;

    public void Enter(GameObject uiObject)
    {
        _uiObject = uiObject;
        _uiObject.SetActive(true);
    }

    public void Update()
    {

    }

    public void Exit()
    {
        _uiObject.SetActive(false);
    }
}
