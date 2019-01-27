using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WellBeingManager : MonoBehaviour
{
    [SerializeField]
    protected float wellBeing;

    [SerializeField]
    protected float wellBeingRate;

    [SerializeField]
    protected float totalTime;

    [SerializeField]
    protected float WBRateDecay;

    // UI
    protected Text UI_timeText;
    
    protected Slider UI_wellBeing;

    static private WellBeingManager instance;

    List<PointOfInterest> PoiList = new List<PointOfInterest>();
    public ConclusionTransition conclusion;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UI_timeText = GameObject.Find("/Canvas_HUD/Time").GetComponent<Text>();
        UI_wellBeing = GameObject.Find("/Canvas_HUD/Slider").GetComponent<Slider>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        
        // UI
        UI_timeText.text = ((int)totalTime).ToString();
        UI_wellBeing.value = wellBeing / 100.0f;

        if (wellBeing >= 100f || totalTime <= 0f)
        {
            conclusion.FadeToConclusion();
        }
    }

    private void FixedUpdate()
    {
        wellBeing += wellBeingRate * Time.fixedDeltaTime;

        wellBeingRate *= 1 - (Time.fixedDeltaTime * WBRateDecay / 1000.0f);
    }

    public void UpdateWellBeing(PointOfInterest poi) // called whenever on fait une activité qui demande du temps
    {
        poi.Interact();
        //on diminue l'importance du précédent poi
        wellBeingRate *= 0.5f;
        
        // log le data du rate?
        wellBeingRate += poi.getDeltaWBRate();

        float dWB = poi.getDeltaWB() * Mathf.Pow(poi.getRepeatMultiplier(), PointOfInterest.uses[poi.getCategory()]);

        wellBeing += wellBeing > poi.getOptimumWB() ? dWB * poi.getOptimumWB() / wellBeing : dWB;

        wellBeing += poi.getDeltaWBRate() * poi.getTimeCost();

        totalTime -= poi.getTimeCost();
    }

    static public WellBeingManager GetInstance()
    {
        return instance;
    }
}
