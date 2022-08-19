using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Button clearButton;
    public bool triggerOn;

    private void Awake() {
        clearButton = GameObject.Find("Clear").GetComponent<Button>();
    }
    private void OnEnable() {
        clearButton.GetComponent<Button>().onClick.AddListener(DestroyThis);
    }
    private void OnDisable() {
        clearButton.GetComponent<Button>().onClick.RemoveListener(DestroyThis);
    }

    private void OnMouseUp() {
        Debug.Log("Release.");
        if(triggerOn) DestroyThis();
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }
}
