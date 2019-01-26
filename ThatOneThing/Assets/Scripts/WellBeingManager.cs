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

    // UI
    [SerializeField]
    Text UI_timeText;

    [SerializeField]
    Slider UI_wellBeing;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        
        // UI
        UI_timeText.text = ((int)totalTime).ToString();
        UI_wellBeing.value = wellBeing / 100.0f;
    }

    private void FixedUpdate()
    {
        wellBeing += wellBeingRate * Time.fixedDeltaTime;
    }

    public void UpdateWellBeing(PointOfInterest poi) // called whenever on fait une activité qui demande du temps
    {
        //on diminue l'importance du précédent poi
        wellBeingRate *= 0.5f;
        
        // log le data du rate?
        wellBeingRate += poi.deltaWBRate;

        wellBeing += wellBeing > poi.optimumWB ? poi.deltaWB * poi.optimumWB / wellBeing : poi.deltaWB;

        wellBeing += wellBeingRate * poi.timeCost;

        totalTime -= poi.timeCost;
    }
}
