using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Button clearButton;

    private void Awake() {
        clearButton = GameObject.Find("Clear").GetComponent<Button>();
    }

    void Start()
    {
        clearButton.GetComponent<Button>().onClick.AddListener(clear);
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
