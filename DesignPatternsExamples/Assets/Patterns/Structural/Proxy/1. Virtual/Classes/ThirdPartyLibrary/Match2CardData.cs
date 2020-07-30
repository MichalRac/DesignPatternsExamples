using System.Collections.Generic;
using UnityEngine;

namespace ThirdPartyLibrary
{
    public class Match2CardData : IMatchable
    {
        private int id;
        public int Id { get => id; set => id = value; }
        public Color Color { get; set; }
        public string Text { get; set; }

        public List<int> memoryEater = new List<int>();

        // Hypothetically costly constructor generating all sorts of values based of id
        public Match2CardData(int id)
        {
            Id = id;

            // Reprezenting randomizing image based off id
            float seed = (float)(id / GridManager.ID_MODIFIER) / GridManager.numberOfCards;
            float setR = Mathf.Clamp(0.2f + seed, 0.2f, 0.8f);
            float setG = Mathf.Clamp(0.8f - seed, 0.2f, 0.8f);
            float setB = Mathf.Clamp(seed, 0f, 1f);
            Color = new Color(setR, setG, setB);

            // Representing randomizing text based off id
            Text = id.ToString();

            // Memory eater
            for(int i = 0; i < 10000000; i++)
            {
                memoryEater.Add(i);
            }
        }
    }
}


