using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnMonsterDelay;
    [SerializeField] private UIManager uIManager;
    public LevelDescription Data;
    public Level CurrentLevel;

    [SerializeField] private TextAsset[] levels;
    private LevelDescription[] level_descriptions;
    private bool isGamePaused = false;

    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();

                if (_instance == null) {
                    GameObject gameManager = new GameObject("GameManager");
                    _instance = gameManager.AddComponent<GameManager>();

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

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3(-7, 0, 0), Quaternion.identity);
        InvokeRepeating("SpawnMonster", 2.0f, 2.0f);

        uIManager.InitPlayer(player.GetComponent<PlayerAvatar>());
        uIManager.setPauseCanvasVisibility(false);

        for (int i = 0; i < levels.Length; i++)
        {
            level_descriptions[i] = XmlHelpers.DeserializeFromXML<LevelDescription>(levels[i]);
        }

        CurrentLevel = new Level();
        CurrentLevel.Load(this.level_descriptions[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster() {
        float randomY = Random.Range(-4.5f, 4.5f);
        GameObject go = Instantiate(enemyPrefab, new Vector3(8, randomY, 0), Quaternion.identity);
    }

    public void PauseGame() {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;
            uIManager.setPauseCanvasVisibility(true);
        } else {
            Time.timeScale = 1f;
            uIManager.setPauseCanvasVisibility(false);
        }
    }
}
