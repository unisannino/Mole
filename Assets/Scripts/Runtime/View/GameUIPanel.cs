using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unisannino.Mole.Runtime.View
{
    public class GameUIPanel : MonoBehaviour
    {
        [SerializeField] GameMessagePanel gameMessagePanel;
        [SerializeField] ScoreArea scoreArea;
        [SerializeField] TimeGauge timeGauge;

        public void UpdateScore(int score)
        {
            scoreArea.UpdateScore(score);
        }
        
        public void UpdateTimeGauge(float currentTime)
        {
            timeGauge.UpdateGauge(currentTime);
        }
        
        public async UniTask PlayStartGameAsync(CancellationToken cancellationToken)
        {
            await gameMessagePanel.PlayStartGameAsync(cancellationToken);
        }

        public async UniTask PlayEndGameAsync(CancellationToken cancellationToken)
        {
            await gameMessagePanel.PlayEndGameAsync(cancellationToken);
        }
    }
}