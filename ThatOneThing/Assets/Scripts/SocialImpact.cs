using UnityEngine;
using System.Collections;

public class SocialImpact : Impact
{
    [SerializeField]
    string opinion;

    [SerializeField]
    Social relation;

    [SerializeField]
    float deltaOpinion, deltaRelation;

    private Social socialComponent;

    public override void Activate()
    {
        socialComponent.opinions[opinion] += deltaOpinion;
    }
    
}
