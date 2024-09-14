using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory _instance;
    [SerializeField] private GameObject playerBulletPrefab;
    [SerializeField] private GameObject enemyBulletPrefab;
    private Queue<Bullet> playerBulletPool;
    private Queue<Bullet> enemyBulletPool;

    public static BulletFactory Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<BulletFactory>();

                if (_instance == null) {
                    GameObject bulletFactory = new GameObject("BulletFactory");
                    _instance = bulletFactory.AddComponent<BulletFactory>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Bullet GetBullet(BulletType bulletType){
        Bullet bullet = null;
        switch (bulletType) {
            case BulletType.PlayerBullet:
                if (playerBulletPool.Count == 0) {
                    AddPlayerBulletPoolInList();
                }
                bullet = playerBulletPool.Dequeue();
                bullet.gameObject.SetActive(true);
                break;
            case BulletType.EnemyBullet:
                if (enemyBulletPool.Count == 0)
                {
                    AddEnemyBulletPoolInList();
                }
                bullet = enemyBulletPool.Dequeue();
                bullet.gameObject.SetActive(true);
                break;
            default:
                break;
        }
        return bullet;
    }

    public void Release(Bullet bullet) {
        bullet.gameObject.SetActive(false); 
        if (bullet.BulletType == BulletType.PlayerBullet)
            playerBulletPool.Enqueue(bullet);
        else
            enemyBulletPool.Enqueue(bullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerBulletPool = new Queue<Bullet>();
        enemyBulletPool = new Queue<Bullet>();
        for (int i = 0; i < 100; i++) {
            AddPlayerBulletPoolInList();
            AddEnemyBulletPoolInList();
        }
    }

    private void AddPlayerBulletPoolInList() {
        GameObject go = Instantiate(playerBulletPrefab);
        go.SetActive(false);

        playerBulletPool.Enqueue(go.GetComponent<Bullet>());
    }
    private void AddEnemyBulletPoolInList()
    {
        GameObject go = Instantiate(enemyBulletPrefab);
        go.SetActive(false);

        enemyBulletPool.Enqueue(go.GetComponent<Bullet>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
