using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyBasicEngine : MonoBehaviour
{
    [SerializeField] private Engines engine;


    // Start is called before the first frame update
    void Start()
    {
        engine.Speed = new Vector2(-1, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
