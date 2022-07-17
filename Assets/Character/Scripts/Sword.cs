using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.Health;


namespace Character
{
    public class Sword : MonoBehaviour
    {
        public int Damage { get { return damageAmount; } set { damageAmount = value; } }
        private int damageAmount;

        [HideInInspector] public GameObject holder;
        Collider trigger;
        AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();

            trigger = GetComponent<Collider>();
            trigger.enabled = false;
            
        }

        public void UseAttackTrigger(float delayStart, float duration)
        {
            StartCoroutine(SetTriggerDelayed(delayStart, duration));
        }
        IEnumerator SetTriggerDelayed(float delayStart, float time)
        {
            yield return new WaitForSeconds(delayStart);
            trigger.enabled = true;
            audioSource.Play();
            yield return new WaitForSeconds(time);
            trigger.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject != holder)
            {
                Debug.Log("hit");
                CharacterHealth targetHealth = other.gameObject.GetComponent<CharacterHealth>();
                if (targetHealth != null)
                {
                    targetHealth.TakeDamage(damageAmount);
                }
            }
        }
    }
}
