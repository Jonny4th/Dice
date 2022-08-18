using UnityEngine;
namespace DiceBehavior
{
    public class Draggable : MonoBehaviour
    {
        Camera mainCamera;
        [SerializeField] Vector3 offset;
        Rigidbody _rigidbody;
        [SerializeField] float holdingHeight;
        // Vector3 startPos;
        [SerializeField] float zCoor;

        private void Awake() {
            mainCamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
        }
        private void OnMouseDown()
        {
            Vector3 startPos = transform.position;
            startPos.y = holdingHeight;
            transform.position = startPos;
            Vector3 objectPoint = mainCamera.WorldToScreenPoint(transform.position);
            zCoor = objectPoint.z;
            _rigidbody.useGravity = false;
            offset = transform.position - GetMouseWorldPos(zCoor);
        }
        

        private void OnMouseDrag()
        {
            Vector3 position = GetMouseWorldPos(zCoor) + offset;
            position.y = holdingHeight;
            // transform.position = position;
            _rigidbody.velocity = 5f * (position - transform.position);
        }
        private void OnMouseUp() {
            _rigidbody.useGravity = true;
        }

        private Vector3 GetMouseWorldPos(float z)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = z; // to compensate for the fact that mousePoint returns (x,y,0).
            return mainCamera.ScreenToWorldPoint(mousePoint);
        }
    }
}
