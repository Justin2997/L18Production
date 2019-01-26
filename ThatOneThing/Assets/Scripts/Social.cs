using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Social : MonoBehaviour
{
    public Dictionary<Social, float> relations; // -1 à 1
    public Dictionary<string, float> opinions; // -1 à 1

    // Use this for initialization
    void Start()
    {
        relations = new Dictionary<Social, float>();
        opinions = new Dictionary<string, float>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateRelations()
    {
        // l ö ö p sur toutes les relations
        // update opinion selon force de la relation + rnd 
        float totalRelationForces = 0;
        foreach (KeyValuePair<Social, float> relation in relations)
        {
            totalRelationForces += relation.Value;
        }

        foreach (KeyValuePair<string, float> opinion in opinions)
        {
            foreach(KeyValuePair<Social, float> relation in relations)
            {
                opinions[opinion.Key] += relation.Value * relation.Key.opinions[opinion.Key] / totalRelationForces;
            }
        }
    }
}
