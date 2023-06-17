using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Unisannino.Mole.Runtime.View
{
    public class GameUIPanel : MonoBehaviour
    {
        [SerializeField] GameMessagePanel gameMessagePanel;

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