
namespace VD
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IPlayerState;
    }
}
