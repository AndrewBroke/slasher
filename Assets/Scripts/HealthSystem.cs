using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    // Переменная для событий
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
            print("Ты умер");
        }
        print($"Здоровье {gameObject.name} изменено на {health}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
