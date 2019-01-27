using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    [SerializeField]
    protected float deltaWB; // delta du bien-être instantané

    [SerializeField]
    protected float usesMultiplier = 1;
    public float getRepeatMultiplier()
    {
        return usesMultiplier;
    }

    [SerializeField]
    string category;
    public string getCategory()
    {
        return category;
    }

    static public Dictionary<string, int> uses = new Dictionary<string, int>();

    public float getDeltaWB()
    {
        return deltaWB;
    }

    [SerializeField]
    protected float optimumWB;  // point auquel le gain de WB est maximum; dépassé ce point, le gain diminue
    public float getOptimumWB()
    {
        return optimumWB;
    }

    [SerializeField]
    protected float deltaWBRate;  // delta de la dérivée du bien-être
    public float getDeltaWBRate()
    {
        return deltaWBRate;
    }

    [SerializeField]
    protected float timeCost;
    public float getTimeCost()
    {
        return timeCost;
    }

    [SerializeField]
    protected Impact impact;

    [SerializeField]
    protected Dialogue dialogue;
    

    // Start is called before the first frame update
    void Start()
    {
        if (!uses.ContainsKey(category))
            uses[category] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        DialogueSystem.GetInstance().AddDialogue(dialogue);
        uses[category]++;
        if(impact)
            impact.Activate();
    }
}
