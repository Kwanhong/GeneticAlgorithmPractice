using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFittestMonkey
{
    public class DNA : MonoBehaviour
    {
        public char[] Genes { get; set; }
        public float Fitness { get; set; }

        public DNA()
        {
            Genes = new char[Main.target.Length];
            for (int i = 0; i < Genes.Length; i++)
            {
                Genes[i] = (char)Random.Range(32, 128);
            }
        }

        public void SetFitness()
        {
            int score = 0;
            for (int i = 0; i < Genes.Length; i++)
            {
                if (Genes[i] == Main.target[i])
                {
                    score++;
                }
            }

            Fitness = (float)score / Main.target.Length;
        }

        public DNA CrossOver(DNA partner)
        {
            DNA child = new DNA();

            int midpoint = Random.Range(0, Genes.Length);

            for (int i = 0; i < Genes.Length; i++)
            {
                if (i > midpoint) child.Genes[i] = Genes[i];
                else child.Genes[i] = partner.Genes[i];
            }

            return child;
        }

        public void Mutate()
        {
            for (int i = 0; i < Genes.Length; i++)
            {
                if (Random.Range(0f, 1f) < Main.mutationRate)
                {
                    Genes[i] = (char)Random.Range(32, 128);
                }
            }

        }

    }
}