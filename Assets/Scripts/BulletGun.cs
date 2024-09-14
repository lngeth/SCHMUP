using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Vector2 speed;
    [SerializeField] private float cooldown;
    private float nextShot;
    [SerializeField] private float bulletEnergyCost;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private float energy;
    [SerializeField] private float energyMax;
    private bool isShootDisabled = false;
    [SerializeField] private BulletType bulletType;

    public float Damage {
        get { return damage; }
        set { damage = value; }
    }
    public Vector2 Speed {
        get { return speed; }
        set { speed = value; }
    }
    public float Cooldown {
        get { return cooldown; }
        set { cooldown = value; }
    }
    public float BulletEnergyCost {
        get { return bulletEnergyCost; }
        set { bulletEnergyCost = value; }
    }
    public float ReloadSpeed {
        get { return reloadSpeed; }
        set { reloadSpeed = value; }
    }
    public float Energy {
        get { return energy; }
        set { energy = value; }
    }
    public float EnergyMax {
        get { return energyMax; }
        set { energyMax = value; }
    }

    public void Fire() {
        if (Time.time > nextShot && Energy > 0 && !isShootDisabled) {
            Bullet bullet = BulletFactory.Instance.GetBullet(bulletType);
            bullet.Damage = Damage;
            bullet.Speed = Speed;
            bullet.Position = transform.position;
            Energy -= BulletEnergyCost;
            if (Energy < 0) {
                Energy = 0;
                isShootDisabled = true;
            }
            nextShot = Time.time + Cooldown;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nextShot = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Energy += ReloadSpeed * Time.deltaTime;
        if (Energy > EnergyMax) {
            Energy = EnergyMax;
            isShootDisabled = false;
        }
    }
}