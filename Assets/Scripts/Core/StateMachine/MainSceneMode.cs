
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
		public void GotoLevelBuild()
		{
			ChangeState<LevelBuildState>();
		}

		public void GotoMainGameFight()
		{
			ChangeState<GameFightState>();
		}
		public void GotoWinGame()
		{
			ChangeState<WinGameState>();
		}
		public void GotoEndGame()
		{
			ChangeState<EndGameState>();
		}
	}
}
