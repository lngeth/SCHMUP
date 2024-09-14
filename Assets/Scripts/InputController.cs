using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Engines engines;
    [SerializeField] private BulletGun bulletGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");

        if (Input.GetKey("space")) {
            bulletGun.Fire();
        }

        engines.Speed = new Vector2(xSpeed, ySpeed);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameManager.Instance.PauseGame();
        }
    }
}
