
namespace Interfaces
{
    public interface IKillable
    {
        float Health { get; }

        bool IsDead { get; }

        void Heal(float amount);
        void Hit(float damage);
        void Kill();
    }
}
