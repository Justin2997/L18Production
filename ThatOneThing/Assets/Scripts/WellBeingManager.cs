using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellBeingManager : MonoBehaviour
{
    [SerializeField]
    protected float wellBeing;

    [SerializeField]
    protected float wellBeingRate;

    [SerializeField]
    protected int totalTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void FixedUpdate()
    {
        wellBeing += wellBeingRate * Time.fixedDeltaTime;
    }

    public void UpdateWellBeing(PointOfInterest poi) // called whenever on fait une activité qui demande du temps
    {
        //on diminue l'importance du précédent poi
        wellBeingRate *= 0.5f;
        
        wellBeingRate += poi.deltaWBRate;

        wellBeing += wellBeing > poi.optimumWB ? poi.deltaWB * poi.optimumWB / wellBeing : poi.deltaWB;

        wellBeing += wellBeingRate * poi.timeCost;

        totalTime -= poi.timeCost;
    }
}
