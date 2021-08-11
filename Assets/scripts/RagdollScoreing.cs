using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollScoreing : MonoBehaviour
{
    private Joint[] joints;
    public float Currentscore = 0;
    [SerializeField] private float minForce;
    
    private void OnEnable()
    {
        joints = GetComponentsInChildren<Joint>();
    }
    private void FixedUpdate()
    {
        Currentscore += ScoreRagdoll();

        GameManger.Totalscore += ScoreRagdoll();
    }

    float ScoreRagdoll()
    {
        float totalforce = 0;
        float scoreAdd = 0;
        foreach(Joint joint in joints)
        {
            if (joint.currentForce.magnitude > minForce)
            {
                totalforce += joint.currentForce.magnitude;
            }
        }

        if (!MouseDrag.hasItem)
        {
            if (totalforce > 1000)
            {
                scoreAdd++;
            }
        }

        return scoreAdd;
    }
}
