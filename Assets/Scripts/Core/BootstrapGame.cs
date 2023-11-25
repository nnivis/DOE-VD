using UnityEngine;

public class BootstrapGame : MonoBehaviour
{
    [SerializeField] private UIStateMachineManager _uiManager;

    private void Start()
    {
        InitializeUIManager();
    }

    private void InitializeUIManager()
    {
        _uiManager.SetupUIManager();
        _uiManager.StartUIManager();
    }

}
