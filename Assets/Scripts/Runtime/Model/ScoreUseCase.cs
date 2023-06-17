using UnityEngine;

namespace Unisannino.Mole.Runtime.Model
{
    public class ScoreUseCase
    {
        public int Score { get; private set; }
        
        public void AddScore(int score)
        {
            Score = Mathf.Clamp(Score + score, 0, MasterData.Instance.MoleParameter.MaxScore);
        }
    }
}