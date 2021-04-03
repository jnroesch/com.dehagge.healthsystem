using UnityEngine;

namespace Packages.com.dehagge.healthsystem.Runtime
{
    public class HealthData
    {
        public float MaxHealth { get; set; }
        public float MinHealth { get; set; }
        
        private float _initialHealth;
        public float InitialHealth
        {
            get => _initialHealth;
            set => _initialHealth = Mathf.Clamp(value, MinHealth, MaxHealth);
        }

        public HealthData(float max, float min, float initial)
        {
            MaxHealth = max;
            MinHealth = min;
            InitialHealth = initial;
        }

        public HealthData()
        {
            //NOP
        }
    }
}
