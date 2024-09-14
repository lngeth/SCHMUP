using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerAvatar playerAvatar;
    private BulletGun playerBulletGun;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider energySlider;
    [SerializeField] private Canvas pauseCanvas;

    public PlayerAvatar PlayerAvatar {
        get { return playerAvatar; }
        set { playerAvatar = value; }
    }
    public Canvas PauseCanvas {
        get { return pauseCanvas; }
        set { pauseCanvas = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerAvatar.Health;
        energySlider.value = playerBulletGun.Energy;
    }

    public void InitPlayer(PlayerAvatar player) {
        PlayerAvatar = player;
        playerBulletGun = player.GetComponentInChildren<BulletGun>();
        healthSlider.maxValue = playerAvatar.MaxHealth;
        energySlider.maxValue = playerBulletGun.EnergyMax;
    }

    public void setPauseCanvasVisibility(bool val) {
        pauseCanvas.gameObject.SetActive(val);
    }
}
