using UnityEngine;

public class DragAndFlick : MonoBehaviour
{
    public bool isHolding = false;
    public GameObject toDrag;
    [SerializeField] protected float holdingDist;
    protected Vector3 currentPos;
    protected Vector3 offset;
    [SerializeField] protected LayerMask layerMask;
    protected Vector3 pos0;
    protected Vector3 pos;
    protected Vector3 vel;

}
