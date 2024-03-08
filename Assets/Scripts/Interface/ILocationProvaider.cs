
namespace VD
{
    public interface ILocationProvaider
    {
        public RollDiceConfig rollDiceConfig { get; }
        public EnemyFactory enemyFactory { get; }
        public DiceFactory diceFactory { get; }
    }
}
