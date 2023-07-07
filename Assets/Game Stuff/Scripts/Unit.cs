using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField] int maxHp, currentHp, dmg;
    [SerializeField] string Name;
    [SerializeField] Slider slider;
    [SerializeField] bool dontDestroy;

    void Start()
    {
        currentHp = maxHp;
        slider.maxValue = maxHp;
        slider.value = currentHp;
    }

    void FixedUpdate()
    {
        slider.value = currentHp;

        if (currentHp <= 0)
        {
            Die();
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
        if (dontDestroy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
