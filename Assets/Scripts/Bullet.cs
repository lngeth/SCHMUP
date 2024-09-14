using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private float damage;
    private Vector2 speed;
    private Vector2 position;
    [SerializeField] private BulletType bulletType;

    public float Damage {
        get { return damage; }
        set { damage = value; }
    }
    public Vector2 Speed {
        get{ return speed; }
        set{ speed = value; }
    }
    public Vector2 Position {
        get{ return position; }
        set{ transform.position = value; }
    }
    public BulletType BulletType {
        get { return bulletType; }
        set { bulletType = value; }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("background"))
            BulletFactory.Instance.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Avatar")) { // Bullet vs Avatar
            BaseAvatar opposition = null;

            if (bulletType == BulletType.PlayerBullet) {
                opposition = collision.GetComponent<EnemyAvatar>();
            } else {
                opposition = collision.GetComponent<PlayerAvatar>();
            }

            if (opposition != null) {
                opposition.TakeDamage(Damage);
                BulletFactory.Instance.Release(this);
            }
        }
    }

    protected virtual void Init() {}

    protected virtual void UpdatePosition() {}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }
}

public enum BulletType {
    PlayerBullet,
    EnemyBullet
}