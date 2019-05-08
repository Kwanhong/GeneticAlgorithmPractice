using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFittestMonkey
{
    public class Main : MonoBehaviour
    {
        public static int totalPopulation = 1000;
        public static float mutationRate = 0.02f;
        public static string target = "to be or not to be";

        DNA[] population;

        public void Run()
        {
            InitializePopulation();
            StartCoroutine(UpdateGeneration());
        }

        void InitializePopulation()
        {
            population = new DNA[totalPopulation];
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new DNA();
            }
        }

        IEnumerator UpdateGeneration()
        {
            while (true)
            {
                CalculateFitness();
                ReproduceGeneration();
                if (!Display()) yield break;
            }
        }

        void CalculateFitness()
        {
            for (int i = 0; i < population.Length; i++)
            {
                population[i].SetFitness();
            }
        }

        void ReproduceGeneration()
        {
            List<DNA> matingPool = new List<DNA>();

            for (int i = 0; i < population.Length; i++)
            {
                int n = (int)(population[i].Fitness * 100);

                for (int j = 0; j < n; j++)
                {
                    matingPool.Add(population[i]);
                }

            }

            for (int i = 0; i < population.Length; i++)
            {
                int fatherGeneIndex = Random.Range(0, matingPool.Count);
                int motherGeneIndex = Random.Range(0, matingPool.Count);

                DNA fatherDNA = matingPool[fatherGeneIndex];
                DNA motherDNA = matingPool[motherGeneIndex];
                DNA childDNA = fatherDNA.CrossOver(motherDNA);
                childDNA.Mutate();

                population[i] = childDNA;
            }
        }

        bool Display()
        {
            CalculateFitness();
            float max = -1f;
            DNA theFittestOne = new DNA();
            for (int i = 0; i < population.Length; i++)
            {
                if (population[i].Fitness > max)
                {
                    max = population[i].Fitness;
                    theFittestOne = population[i];
                }
            }
            Debug.Log(CharSetToString(theFittestOne.Genes) + ", " + max * 100f);

            return max < 0.99f;
        }

        string CharSetToString(char[] charSet)
        {
            string phrase = "";
            foreach (char element in charSet)
            {
                phrase += element;
            }
            return phrase;
        }
    }
}