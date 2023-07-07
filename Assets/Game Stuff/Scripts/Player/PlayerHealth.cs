using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHp, currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void FixedUpdate()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            TakeDmg(1);
        }
    }

    void TakeDmg(int dmg)
    {
        currentHp -= dmg;
    }

    void Heal(int heal)
    {
        currentHp += heal;
    }

    void RaiseMaxHp(int increase)
    {
        maxHp += increase;
        currentHp += increase;
    }

    void LowerMaxHp(int decrease)
    {
        maxHp += decrease;
        currentHp += decrease;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
