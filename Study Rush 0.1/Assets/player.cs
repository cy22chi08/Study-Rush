using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;


    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void FixedUpdate()
    {

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movementWS = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        Vector3 movementAD = transform.right * moveHorizontal * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movementWS + movementAD);

    }


}