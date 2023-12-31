using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    // ���������� ��� �������
    [SerializeField] UnityEvent deathEvents;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if(health > maxHealth) health = maxHealth;
        if(health <= 0)
        {
            health = 0;
            print("�� ����");
        }
        print($"�������� {gameObject.name} �������� �� {health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
