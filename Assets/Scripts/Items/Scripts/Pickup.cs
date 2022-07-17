using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class Pickup : MonoBehaviour
    {
        public bool IsGrabbed;

        Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            // Display prompt to player
        }

        public void SetGrabbed(bool grabbed)
        {
            IsGrabbed = grabbed;
            rb.useGravity = !grabbed;
           // rb.isKinematic = grabbed;

            if(!grabbed)
            {
                transform.parent = null;
            }
        }
    }
}