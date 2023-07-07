using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] float jumpForce;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.up * jumpForce;
            rb.angularVelocity = new Vector3 (Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f));
        }
    }
}
