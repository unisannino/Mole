using System.Threading;
using Cysharp.Threading.Tasks;
using Unisannino.Mole.Runtime.Extensions;
using UnityEngine;
using UnityEngine.Playables;

namespace Unisannino.Mole.Runtime.View
{
    public class GameUIPanel : MonoBehaviour
    {
        [SerializeField] private PlayableDirector startGamePlayableDirector;
        [SerializeField] private PlayableDirector endGamePlayableDirector;

        public async UniTask PlayStartGameAsync(CancellationToken cancellationToken)
        {
            await startGamePlayableDirector.PlayAsync(token: cancellationToken);
        }

        public async UniTask PlayEndGameAsync(CancellationToken cancellationToken)
        {
            await endGamePlayableDirector.PlayAsync(token: cancellationToken);
        }
    }
}