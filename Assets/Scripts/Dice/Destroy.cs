using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Button clearButton;

    private void Awake() {
        clearButton = GameObject.Find("Clear").GetComponent<Button>();
    }
    private void OnEnable() {
        clearButton.GetComponent<Button>().onClick.AddListener(clear);
    }
    private void OnDisable() {
        clearButton.GetComponent<Button>().onClick.RemoveListener(clear);
    }
    void Start()
    {
    }

    private void OnMouseUp()
    {
        //if mouse over "clear" button
        //clear()
    }

    void Update()
    {
        
    }

    private void clear()
    {
        Destroy(gameObject);
    }
}
