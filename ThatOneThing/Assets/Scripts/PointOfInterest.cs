using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    [SerializeField]
    public float deltaWB { get; protected set; } // delta du bien-être instantané

    [SerializeField]
    public float optimumWB { get; protected set; }  // point auquel le gain de WB est maximum; dépassé ce point, le gain diminue

    [SerializeField]
    public float deltaWBRate { get; protected set; }  // delta de la dérivée du bien-être

    [SerializeField]
    public int timeCost { get; protected set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
