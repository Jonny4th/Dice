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
            float speed = _rigidbody.velocity.sqrMagnitude;
            float mod = Random.Range(0,1f);
            _rigidbody.AddTorque(Vector3.right * speed * mod * velMultiplier);
            _rigidbody.AddTorque(Vector3.forward * speed * (1f-mod) * velMultiplier);
        }
    }
}
