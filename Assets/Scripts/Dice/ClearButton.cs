using UnityEngine;
using UnityEngine.EventSystems;

public class ClearButton : MonoBehaviour, IDropHandler, IPointerUpHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop!!!");;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up!!!");
    }
}
