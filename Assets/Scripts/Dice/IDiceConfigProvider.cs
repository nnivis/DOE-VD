
namespace VD
{
    public interface IDiceConfigProvider
    {
        DiceConfig GetConfig(DiceType type);
        DiceType GetNextType(DiceType currentType);
    }
}
