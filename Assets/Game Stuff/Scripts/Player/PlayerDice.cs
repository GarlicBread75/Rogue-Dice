using System.Collections;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] float jumpForce, rollCooldown, cdAcceleration, rollCd;
    bool jumpPressed;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector2 spinSpeed;

    // Misc
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rollCd = rollCooldown;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            jumpPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (!Grounded() && rb.velocity.y <= 0)
        {
            rb.angularVelocity = Vector3.zero;
        }

        if (jumpPressed)
        {
            StartCoroutine(Jumping());
        }

        if (rollCd < rollCooldown)
        {
            rollCd += Time.fixedDeltaTime * cdAcceleration;
        }
    }

    IEnumerator Jumping()
    {
        rb.velocity = Vector3.up * jumpForce;
        yield return new WaitForSeconds(0.05f);

        if (rollCd >= rollCooldown)
        {
            rb.angularVelocity = new Vector3(Random.Range(spinSpeed.x, spinSpeed.y), Random.Range(spinSpeed.x, spinSpeed.y), Random.Range(spinSpeed.x, spinSpeed.y));
            rollCd = 0;
        }

        jumpPressed = false;
    }

    bool Grounded()
    {
        return Physics.CheckSphere(transform.position, 1.5f, ground);
    }
}
