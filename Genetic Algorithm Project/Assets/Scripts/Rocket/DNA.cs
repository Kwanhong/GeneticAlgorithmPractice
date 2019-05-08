using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFittestMover
{
    public class DNA : MonoBehaviour
    {
        public Vector2[] genes;
        public float maxForce = 0.1f;
        public float fitness;

        public DNA(int num)
        {
            genes = new Vector2[num];
            for (int i = 0; i < genes.Length; i++) {
                Vector2 rndVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                rndVector = rndVector.normalized;
                rndVector *= Random.Range(0, maxForce);
                genes[i] = rndVector;
            }
        }

        public void SetFitness()
        {
            //float distance = Vector2.Distance(location, target);
            //fitness = Mathf.Pow(1 / distance, 2);
        }
    }
}