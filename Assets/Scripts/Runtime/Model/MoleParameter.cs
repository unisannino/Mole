using System;
using UnityEngine;

namespace Unisannino.Mole.Runtime.Model
{
    [Serializable]
    public class MoleParameter
    {
        [SerializeField] private int moleScore = 50;
        [SerializeField] private float gameTime = 60f;
        
        public int MoleScore => moleScore;
        public float GameTime => gameTime;
    }
}