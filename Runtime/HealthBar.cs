using DG.Tweening;
using Packages.com.dehagge.progressbar.Runtime;
using UnityEngine;
using Zenject;

namespace Packages.com.dehagge.healthsystem.Runtime
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private SliderProgressBar _healthBarDisplay;
        [SerializeField] private SliderProgressBar _healthBarPreviewDisplay;

        private IDamageable _damageable;

        [Inject]
        public void Construct(IDamageable damageable)
        {
            _damageable = damageable;

            _healthBarDisplay.MinFillAmount = damageable.MinHealth;
            _healthBarDisplay.MaxFillAmount = damageable.MaxHealth;
            _healthBarDisplay.CurrentFillAmount = damageable.CurrentHealth;

            _healthBarPreviewDisplay.MinFillAmount = damageable.MinHealth;
            _healthBarPreviewDisplay.MaxFillAmount = damageable.MaxHealth;
            _healthBarPreviewDisplay.CurrentFillAmount = damageable.CurrentHealth;

            _damageable.HealthChanged += (sender, args) => UpdateHealthDisplay();
        }

        private void UpdateHealthDisplay()
        {
            //healing
            if (_damageable.CurrentHealthNormalized > _healthBarDisplay.GetCurrentFillPercentage() / 100f)
            {
                _healthBarPreviewDisplay.SetFillAmountImmediate(_damageable.CurrentHealth);
                _healthBarDisplay.SetFillAmountTween(_damageable.CurrentHealth, 1, Ease.InOutCubic);
            }
            else
            {
                //taking damage
                _healthBarDisplay.SetFillAmountImmediate(_damageable.CurrentHealth);
                _healthBarPreviewDisplay.SetFillAmountTween(_damageable.CurrentHealth, 1, Ease.InOutCubic);
            }
        }
    }
}