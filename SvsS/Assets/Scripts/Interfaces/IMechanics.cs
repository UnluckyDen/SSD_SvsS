using Players;

namespace Interfaces
{
    public interface IMechanic<T>
    {
        void DoMechanic(T mechanic, Player player);
        T GetValue();
        int GetTarget();
    }
}