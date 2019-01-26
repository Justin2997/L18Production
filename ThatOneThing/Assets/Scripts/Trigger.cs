using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour
{
    Collider2D collider;
    PointOfInterest poi;

    [SerializeField]
    protected float cooldown;

    private float timer;

    [SerializeField]
    protected Text interactPrompt;

    private bool insideTrigger;
    private bool activePoint;



    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        poi = GetComponent<PointOfInterest>();
        insideTrigger = false;
        activePoint = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //timer activepoint
        if (timer > cooldown)
        {
            activePoint = true;
            timer = 0;
        }

        if (insideTrigger && activePoint)
        {
            // show button prompt pour interact
            interactPrompt.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space)) // temp
            {
                WellBeingManager.GetInstance().UpdateWellBeing(poi);
                activePoint = false;
            }
        }
        else
        {
            interactPrompt.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            insideTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            insideTrigger = false;
    }
}
