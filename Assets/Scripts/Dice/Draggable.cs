using UnityEngine;
namespace DiceBehavior
{
    public class Draggable : MonoBehaviour
    {
        Camera mainCamera;
        [SerializeField] GameObjectArray selectedDice;
        [SerializeField] Vector3 offset;
        Rigidbody _rigidbody;
        [SerializeField] float holdingHeight;
        // Vector3 startPos;
        [SerializeField] float zCoor;

        private void Awake() {
            mainCamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody>();
            zCoor = mainCamera.WorldToScreenPoint(transform.position).z;
        }

        private void OnMouseDown()
        {
            selectedDice.gameObjects.Add(gameObject);
            //Pick up a dice from the floor, making the dice hover above floor.
            _rigidbody.useGravity = false; //disable gravity, just in case.
            transform.position = Vector3.Lerp(transform.position, YAxisModified(transform.position, holdingHeight), 0.2f); //Make the GO float.
            offset = transform.position - GetMouseWorldPos(zCoor);
        }
        

        private void OnMouseDrag()
        {
            _rigidbody.velocity = 5f * (YAxisModified(GetMouseWorldPos(zCoor) + offset, holdingHeight) - transform.position);
        }
        private void OnMouseUp() {
            selectedDice.gameObjects.Remove(gameObject);
            _rigidbody.useGravity = true;
        }

        private Vector3 GetMouseWorldPos(float z)
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = z; // to compensate for the fact that mousePoint returns (x,y,0).
            return mainCamera.ScreenToWorldPoint(mousePoint);
        }

        private Vector3 YAxisModified(Vector3 v, float y)
        {
            v.y = y;
            return v;
        }
    }
}
