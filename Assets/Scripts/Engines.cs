using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engines : MonoBehaviour
{
    [SerializeField]
    private BaseAvatar baseAvatar;

    private Vector2 speed;



    public Vector2 Speed {
        get { return speed; }
        set { speed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Calcul à chaque frame la nouvelle position en fonction de la MaxSpeed de l'avatar
        Vector2 newPos = this.speed * baseAvatar.MaxSpeed * Time.deltaTime;

        transform.position += new Vector3(newPos.x, newPos.y, 0f);
    }
}
