using UnityEngine;

public class DragAndFlickTouch : MonoBehaviour
{
    private Touch touch01;
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
        if (Input.touchCount == 1)
        {
            touch01 = Input.GetTouch(0); //register single-point touch.
            Vector3 pos = Input.mousePosition; //get touch position.
            Vector3 vel = (pos - pos0)/Time.deltaTime;
            Debug.Log(vel.magnitude);
            pos0 = pos;

            if (isHolding && touch01.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(pos);
                if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layerMask))
                {
                    currentPos = hit.point;
                    currentPos.y = holdingDist;
                    toDrag.GetComponent<Rigidbody>().velocity = 5 * (currentPos - toDrag.transform.position);
                }
            }

            if (isHolding && (touch01.phase == TouchPhase.Ended || touch01.phase == TouchPhase.Canceled))
            {
                Rigidbody _rigidbody = toDrag.GetComponent<Rigidbody>(); // cache game object rigidbody.
                float mod = Random.Range(0,1f);
                _rigidbody.AddTorque(Vector3.right * vel.magnitude * mod);
                _rigidbody.AddTorque(Vector3.forward * vel.magnitude * (1f-mod));
                _rigidbody.useGravity = true;
                isHolding = false;
                toDrag = null;
            }

            if (touch01.phase == TouchPhase.Stationary)
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
}
