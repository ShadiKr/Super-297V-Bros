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

    Animator characterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        frogBar.value = 0;
        frogBar.maxValue = frogTime;
        characterAnimator = GetComponent<Animator>();
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
        Points.text = PointsCollected.ToString();

        if (currentPower == Powers.SHOOT)
        {
            if (frogBar.value > 0)
            {
                frogBar.value -= Time.deltaTime;
            }
            else
            {
                characterAnimator.SetTrigger("Revert");
                currentPower = Powers.NONE;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            characterAnimator.SetTrigger("Shoot");
        }
    }
}
