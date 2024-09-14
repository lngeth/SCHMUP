using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAvatar : BaseAvatar
{
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("background"))
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
