using TMPro;
using UnityEngine;

namespace Unisannino.Mole.Runtime.View
{
    public class ScoreArea : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreValueLabel;
        
        public void UpdateScore(int score)
        {
            scoreValueLabel.text = $"{score:D5}";
        }
    }
}