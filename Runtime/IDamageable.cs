using System;

namespace Packages.com.dehagge.healthsystem.Runtime
{
    public interface IDamageable
    {
        float MaxHealth { get; set; }
        float MinHealth { get; set; }
        float CurrentHealth { get; set; }

        float CurrentHealthNormalized { get; }

        event EventHandler HealthChanged;

        void ReduceHealthPoints(float amount);
        void RestoreHealthPoints(float amount);
    }
}