public class UIStateFactory : IUIStateFactory
{
    public IUIState Create(UIStateType stateType)
    {
        switch (stateType)
        {
            case UIStateType.StartGame:
                return new StartGame();
            case UIStateType.Setting:
                return new Setting();
            case UIStateType.MainMenu:
                return new MainMenu();
            case UIStateType.DiceMenu:
                return new DiceMenu();
            case UIStateType.Level:
                return new Level();
            case UIStateType.Game:
                return new Game();
            case UIStateType.EndGame:
                return new EndGame();
            case UIStateType.WinGame:
                return new WinGame();
            default:
                return null;
        }
    }
}