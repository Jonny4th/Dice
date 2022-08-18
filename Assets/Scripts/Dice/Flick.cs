using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceBehavior
{
    public class Flick : MonoBehaviour
   {
        [SerializeField] float velMultiplier;
        private void OnMouseUp()
        {
            Rigidbody _rigidbody = GetComponent<Rigidbody>(); // cache game object rigidbody.
            Vector3 vel = _rigidbody.velocity;
            float mod = Random.Range(0,1f);
            _rigidbody.AddTorque(Vector3.right * vel.magnitude * mod * velMultiplier);
            _rigidbody.AddTorque(Vector3.forward * vel.magnitude * (1f-mod) * velMultiplier);
        }
    }
}
