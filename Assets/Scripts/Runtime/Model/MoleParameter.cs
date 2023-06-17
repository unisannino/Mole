using System;
using UnityEngine;

namespace Unisannino.Mole.Runtime.Model
{
    [Serializable]
    public class MoleParameter
    {
        [SerializeField] private int moleScore = 50;
        [SerializeField] private float gameTime = 60f;
        [SerializeField] private float defaultMoleSpawnInterval = 3f;
        [SerializeField] private float speedUpSpawnTimingInterval = 15f;
        [SerializeField] private float speedUpValue = 0.125f;
        [SerializeField] private int maxScore = 99999;
        
        public int MoleScore => moleScore;
        public float GameTime => gameTime;
        public float DefaultMoleSpawnInterval => defaultMoleSpawnInterval;
        public float SpeedUpSpawnTimingInterval => speedUpSpawnTimingInterval;
        public float SpeedUpValue => speedUpValue;
        public int MaxScore => maxScore;
    }
}