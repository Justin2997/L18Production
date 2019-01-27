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
    protected string promptText;

    protected Text interactPrompt;

    private bool insideTrigger;
    private bool activePoint;

    static List<Trigger> activePoints = new List<Trigger>();

    // Start is called before the first frame update
    void Start()
    {
        interactPrompt = GameObject.Find("/Canvas_HUD/InteractPrompt").GetComponent<Text>();
        collider = GetComponent<Collider2D>();
        poi = GetComponent<PointOfInterest>();
        insideTrigger = false;
        activePoint = true;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //timer activepoint
        if (timer > cooldown)
        {
            activePoint = true;
            timer = 0;
        }

        if (insideTrigger && activePoint && !move.blockMovement)
        {
            // show button prompt pour interact
            interactPrompt.gameObject.SetActive(true);
            interactPrompt.text = promptText;

            if(!activePoints.Find(x => x == this))
                activePoints.Add(this);

            if (Input.GetKeyDown(KeyCode.E)) 
            {
                /// TODO
                //transition
                WellBeingManager.GetInstance().UpdateWellBeing(poi);
                activePoint = false;
                timer = 0;
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (activePoints.Find(x => x == this))
                activePoints.Remove(this);

            if (activePoints.Count == 0)
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
