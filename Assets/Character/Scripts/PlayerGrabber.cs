using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Controller
{
    public class PlayerGrabber : MonoBehaviour
    {
        public GameObject ObjectToGrab;
        List<GameObject> objectsInTrigger = new List<GameObject>();

        Transform playerTransform;

        private void Start() {
            playerTransform = transform.parent.transform;
        }

        private void Update()
        {
            if (objectsInTrigger.Count > 0)
            {
                ObjectToGrab = GetNearestObject();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                if(!objectsInTrigger.Contains(other.gameObject))
                {
                    objectsInTrigger.Add(other.gameObject);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Pickup"))
            {
                objectsInTrigger.Remove(other.gameObject);
                if(ObjectToGrab == other.gameObject)
                {
                    ObjectToGrab = null;
                }
            }
        }

        GameObject GetNearestObject()
        {
            GameObject nearestObject = null;
            Vector3 nearestObjectPosition = Vector3.zero;
            foreach (GameObject go in objectsInTrigger)
            {
                Vector3 dist = go.transform.position - playerTransform.position;

                if (nearestObjectPosition == Vector3.zero)
                {
                    nearestObjectPosition = dist;
                    nearestObject = go;
                }
                else if (dist.magnitude < nearestObjectPosition.magnitude)
                {
                    nearestObjectPosition = dist;
                    nearestObject = go;
                }
            }
            return nearestObject;
        }
    }
}
