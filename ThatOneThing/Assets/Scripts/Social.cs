using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public struct Relation
{
    public Social social;
    public float str;
}

[Serializable]
public struct Opinion
{
    public string opinion;
    public float str;
}

public class Social : MonoBehaviour
{
    [SerializeField]
    protected List<Relation> baseRelations;

    [SerializeField]
    protected List<Opinion> baseOpinions;

    public Dictionary<Social, float> relations; // -1 à 1
    public Dictionary<string, float> opinions; // -1 à 1
    
    float relUpdateTimer = 0;
    // Use this for initialization
    void Start()
    {
        relations = new Dictionary<Social, float>();
        opinions = new Dictionary<string, float>();

        foreach(Relation r in baseRelations)
        {
            relations[r.social] = r.str;
        }

        foreach (Opinion o in baseOpinions)
        {
            opinions[o.opinion] = o.str;
        }
    }

    // Update is called once per frame
    void Update()
    {
        relUpdateTimer += Time.deltaTime;
        float cd = 1;
        if (relUpdateTimer > cd)
        {
            relUpdateTimer = 0;
            UpdateRelations();
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Player"))
        {
            opinions["x"] = transform.position.x;
            opinions["y"] = transform.position.y;
        }

        // follow selon opinion ?
        Vector2 vec = new Vector2(transform.position.x, transform.position.y);
        vec.x = opinions["x"];
        vec.y = opinions["y"];
        
        transform.position = Vector2.MoveTowards(transform.position, vec, Time.fixedDeltaTime);
    }

    void UpdateRelations()
    {
        // l ö ö p sur toutes les relations
        // update opinion selon force de la relation + rnd 
        float totalRelationForces = 0;
        float mostRespectedStr = 0;
        foreach (KeyValuePair<Social, float> relation in relations)
        {
            totalRelationForces += relation.Value;
            if(relation.Value > mostRespectedStr)
            {
                mostRespectedStr = relation.Value;
            }
        }

        List<string> opinionKeys = new List<string>(opinions.Keys);

        foreach (string key in opinionKeys)
        {
            foreach(KeyValuePair<Social, float> relation in relations)
            {
                opinions[key] += (relation.Key.opinions[key] - opinions[key]) * relation.Value * relation.Key.opinions[key] / totalRelationForces;
            }
        }
    }
}
