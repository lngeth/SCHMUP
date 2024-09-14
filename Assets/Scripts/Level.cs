using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelDescription Definition;
    private float startTime;
    private List<EnemyDescription> enemiesToSpawn = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize(LevelDescription description)
    {
        Definition = description;
    }

    public void Load(LevelDescription levelDescription)
    {
        this.startTime = Time.time;
        this.enemiesToSpawn.AddRange(levelDescription.Enemies);
    }

    public void Execute()
    {
        float timeSinceLevelStart = Time.time - startTime;
        foreach (EnemyDescription enemy in enemiesToSpawn) {
            if (enemy.SpawnDate > timeSinceLevelStart) continue;
            else if ()
                
        //   else if (enemy.NeedToBeSpawned(levelStartTime))
        //     Spawn(enemy);
        // }
    }
}
