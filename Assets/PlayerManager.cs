using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Powers
{
    NONE,
    SHOOT,
}
public class PlayerManager : MonoBehaviour
{
    public Text HP,Coins;
    public GameObject FrogUI;

    public Powers currentPower;
    public int CoinsCollected = 0;
    public float health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (health >= 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            health = 0;
        }
        HP.text = health.ToString();
        Coins.text = CoinsCollected.ToString();

        if(currentPower == Powers.SHOOT)
        {
            FrogUI.SetActive(true);
        }
        else
        {
            FrogUI.SetActive(false);
        }
    }
}
