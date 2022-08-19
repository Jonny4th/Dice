using UnityEngine;
using UnityEngine.EventSystems;

public class ClearButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObjectArray selectedDice;
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var item in selectedDice.gameObjects)
        {
            item.GetComponent<Destroy>().triggerOn = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var item in selectedDice.gameObjects)
        {
            item.GetComponent<Destroy>().triggerOn = false;
        }
    }
}
