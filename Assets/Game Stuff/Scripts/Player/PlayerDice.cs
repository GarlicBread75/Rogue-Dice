using System.Collections;
using UnityEngine;

public class PlayerDice : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float attackCooldown;
    [SerializeField] LayerMask ground;
    [SerializeField] Vector2 spinSpeed;
    Vector3 initialPosition;
    float atkCd;

    // Misc
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        atkCd = attackCooldown;
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (!Grounded() && rb.velocity.y <= 0)
        {
            rb.angularVelocity = Vector3.zero;
        }

        if (atkCd < attackCooldown)
        {
            atkCd += Time.deltaTime;
        }
    }

    IEnumerator Jumping()
    {
        if (atkCd >= attackCooldown)
        {
            rb.velocity = Vector3.up * jumpForce;
            yield return new WaitForSeconds(0.05f);
            rb.angularVelocity = new Vector3(Random.Range(spinSpeed.x, spinSpeed.y), Random.Range(spinSpeed.x, spinSpeed.y), Random.Range(spinSpeed.x, spinSpeed.y));
            atkCd = 0;
            StartCoroutine(SetPos(3));
        }
    }

    IEnumerator SetPos(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = initialPosition;
    }

    public void Roll()
    {
        StartCoroutine(Jumping());
    }

    bool Grounded()
    {
        return Physics.CheckSphere(transform.position, 1.5f, ground);
    }
}
