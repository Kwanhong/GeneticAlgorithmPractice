using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFittestMover
{
    public class Rocket : MonoBehaviour
    {
        DNA dna;

        Vector2 location;
        Vector2 velocity;
        Vector2 acceleration;

        void ApplyForce(Vector2 force)
        {
            acceleration += force;
        }

        private void Update()
        {
            velocity += acceleration;
            location += velocity;
            acceleration = Vector2.zero;
        }
    }
}