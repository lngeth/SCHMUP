using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class LevelDescription : MonoBehaviour
{
    [XmlAttribute] public string Name;
    [XmlAttribute] public EnemyDescription[] Enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
