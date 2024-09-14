using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : Bullet
{
    protected override void Init() {
        // Damage = 10;
        // Speed = new Vector2(5, 0);
        // Position = transform.position;
    }

    protected override void UpdatePosition() {
        Vector2 newPos = Speed * Time.deltaTime;
        transform.position += new Vector3(newPos.x, newPos.y, 0f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Init();
    }
}
