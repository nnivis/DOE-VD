
namespace VD
{
	public class MainSceneMode : StateModeBehavior
	{
		public void GotoStartGame()
		{
			ChangeState<StartGameState>();
		}

		public void GotoGame()
		{
			ChangeState<GameState>();
		}

		public void GotoMainGameFight()
		{
			ChangeState<GameFightState>();
		}

		public void GotoEndGame()
		{
			ChangeState<EndGameState>();
		}
	}
}
