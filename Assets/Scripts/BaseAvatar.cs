using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public float MaxSpeed {
        get {
            return this.maxSpeed;
        }
        private set {
            this.maxSpeed = value;
        }
    }

    public float Health {
        get { return health; }
        set { health = value; }
    }

    public float MaxHealth {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public void TakeDamage(float damage) {
        Health -= damage;
        if (Health <= 0)
            Die();
    }

    public void Die() {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
