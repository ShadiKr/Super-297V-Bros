using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Powers
{
    NONE,
    SHOOT,
}
public class PlayerManager : MonoBehaviour
{
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
    }
}
