using UnityEngine;
using UnityEngine.EventSystems;

public class ClearGameObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    GameObjectArray heldDice;
    [SerializeField] private string _tag;
    private bool isPointerOver;

    private void Update()
    {
    }

    public void ClearObject()
    {
        Destroy(heldDice);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }
}
