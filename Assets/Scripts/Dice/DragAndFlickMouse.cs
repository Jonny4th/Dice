using UnityEngine;
public class DragAndFlickMouse : MonoBehaviour
{
    private bool isHolding = false;
    private GameObject toDrag;
    [SerializeField] private float holdingDist;
    private Vector3 currentPos;
    private Vector3 offset;
    [SerializeField] private LayerMask layerMask;
    private Vector3 pos0;
    private void Start()
    {
        pos0 = Input.mousePosition;
    }
    void Update()
    {
        Vector3 pos = Input.mousePosition; //get touch position.
        Vector3 vel = (pos - pos0)/Time.deltaTime;
        pos0 = pos; //update the variable.

        //Drag object
        if (isHolding && Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
            {
                currentPos = hit.point;
                currentPos.y = holdingDist;
                toDrag.GetComponent<Rigidbody>().velocity = 5 * (currentPos - toDrag.transform.position);
            }
        }

        //Release object
        if (isHolding && Input.GetMouseButtonUp(0))
        {
            Rigidbody _rigidbody = toDrag.GetComponent<Rigidbody>(); // cache game object rigidbody.
            float mod = Random.Range(0,1f);
            _rigidbody.AddTorque(Vector3.right * vel.magnitude * mod);
            _rigidbody.AddTorque(Vector3.forward * vel.magnitude * (1f-mod));
            _rigidbody.useGravity = true;
            isHolding = false;
            toDrag = null;
        }

        //Hold object
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(pos); //create ray from touch position.
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.tag == "dice")
                {
                    if (hit.collider.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0)
                    {
                        isHolding = true; // dragging is successful.
                        toDrag = hit.collider.gameObject; // cache gameObjrct data.
                        toDrag.GetComponent<Rigidbody>().useGravity = false; // disable gravity so the object stay on hold above ground.
                        Vector3 startPos = toDrag.transform.position; // get starting world position.
                        currentPos = new Vector3(startPos.x, holdingDist, startPos.z);
                        toDrag.transform.position = Vector3.Lerp(startPos, currentPos, 0.5f);
                    }
                }
            }
        }
    }
}
