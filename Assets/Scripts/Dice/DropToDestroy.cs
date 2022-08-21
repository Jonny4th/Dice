using UnityEngine;
using UnityEngine.EventSystems;

public class DropToDestroy : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObjectArray selectedDice;
    public void OnPointerEnter(PointerEventData eventData)
    {
        selectedDice.gameObjects.RemoveAll(isNull);
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
    private void OnApplicationQuit() {
        selectedDice.gameObjects.Clear();
    }

    private static bool isNull(GameObject g)
    {
        return (g == null);
    }
}
