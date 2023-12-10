
namespace VD
{
    public class MainSceneMode : StateModeBehavior
    {
        public void GotoStartGame()
		{
			ChangeState<StartGameState>();
		}
		
		public void GotoSettings()
		{
			ChangeState<SettingsState>();
		}
		
		public void GotoMainMenuScene()
		{
			ChangeState<MainMenuState>();
		}
    }
}
