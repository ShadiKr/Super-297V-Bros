using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum Powers
{
    NONE,
    SHOOT,
}
public class PlayerManager : MonoBehaviour
{
    public Powers currentPower;
    public int PointsCollected = 0;
    public float health = 100f;
    public TMP_Text HP, Points;
    public Slider frogBar;
    public float frogTime = 20;
    public GameObject spit;

    Animator characterAnimator;
    //Assign values and private variables
    void Start()
    {
        frogBar.value = 0;
        frogBar.maxValue = frogTime;
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Keep health from exceeding the limit and going below 0
        if (health >= 100)
        {
            health = 100;
        }
        else if (health <= 0)
        {
            health = 0;
            GameObject.Find("GameOver").GetComponent<GameOverScreen>().Setup(PointsCollected);
        }

        //Convert points to strings for UI elements
        HP.text = health.ToString();
        Points.text = PointsCollected.ToString();

        //Check if the player is currently in the Shoot Powerup then do what is in the if statement
        if (currentPower == Powers.SHOOT)
        {
            //Decrease from the timer value
            if (frogBar.value > 0)
            {
                frogBar.value -= Time.deltaTime;
            }
            //If the timer is up, update the FSM and return the player to a power-up-less state
            else
            {
                characterAnimator.SetTrigger("Revert");
                currentPower = Powers.NONE;
            }
            //If the left mouse click is pressed, shoot
            if (Input.GetMouseButtonDown(0))
            {
                GameObject shooter = GameObject.Instantiate(spit);
                shooter.transform.position = transform.position;
                shooter.GetComponent<SpitShoot>().Setup(new Vector3(transform.localScale.x, 0, 0));
                Destroy(shooter, 0.5f);
                characterAnimator.SetTrigger("Shoot");
            }
        }
    }
}
