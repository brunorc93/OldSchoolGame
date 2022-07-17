using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyBox;

namespace Character.Health
{
    public class CharacterHealth : MonoBehaviour
    {
        public bool Damageable { get { return _damageable; } }
        private bool _damageable = false;

        public int MaxHealth = 50;
        [ReadOnly] public int currentHealth; // change this to a property later!

        public float invincibleDuration;

        private void Start()
        {
            currentHealth = MaxHealth;
            _damageable = true;
        }

        private void Update()
        {
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void TakeDamage(int amount)
        {
            if (_damageable)
            {
                currentHealth -= amount;

                _damageable = false;
                StartCoroutine("Invincibility");
            }
        }

        void Die()
        {
            Destroy(this.gameObject);
        }

        IEnumerator Invincibility()
        {
            yield return new WaitForSeconds(invincibleDuration);
            _damageable = true;
        }

    }
}
