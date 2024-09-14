using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasicBulletEngine : MonoBehaviour
{
    [SerializeField] private BulletGun bulletGun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletGun.Fire();
    }
}
