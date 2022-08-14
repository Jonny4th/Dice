using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), (typeof(Collider)))]
public class ApplyForce : MonoBehaviour
{
    [SerializeField] private Button rollButton;
    [SerializeField] private float forceMagnitude;
    [SerializeField] private float torqueMagnitude;

    private void Awake() {
        rollButton = GameObject.Find("Roll Button").GetComponent<Button>();
    }
    void Start()
    {
        rollButton.GetComponent<Button>().onClick.AddListener(_ApplyForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            _ApplyForce();
        }
    }

    public void _ApplyForce()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(RandomVector3(-1f,1f,0.8f,1f,-1f,1f) * forceMagnitude, ForceMode.Acceleration);
            rigidbody.AddTorque(transform.forward * torqueMagnitude);
            rigidbody.AddTorque(transform.right * torqueMagnitude);
        }
    }

    private Vector3 RandomVector3(float xm = -1f, float xM = 1f,
                                  float ym = -1f, float yM = 1f,
                                  float zm = -1f, float zM = 1f)
    {
        float x = Random.Range(xm,xM);
        float y = Random.Range(ym,yM);
        float z = Random.Range(zm,zM);

        Vector3 vector = new Vector3(x,y,z).normalized;
        return vector;
    }
}
