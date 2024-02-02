
namespace VD
{
    public interface IDiceConfigProvider
    {
        DiceConfig GetConfig(DiceType type);
        DiceType GetRandomType(DiceType currentType);
    }
}
