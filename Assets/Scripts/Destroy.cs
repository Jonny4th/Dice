using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Button clearButton;
    // Start is called before the first frame update
    private void Awake() {
        clearButton = GameObject.Find("Clear").GetComponent<Button>();
    }
    void Start()
    {
        clearButton.GetComponent<Button>().onClick.AddListener(clear);
    }

    void Update()
    {
        
    }
    private void clear()
    {
        Destroy(gameObject);
    }
}
