using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Playables;

namespace Unisannino.Mole.Runtime.Extensions
{
    public static class PlayableDirectorExtension
    {
        public static async UniTask PlayAsync(this PlayableDirector self, CancellationToken token = default)
        {
            self.Play();
            await UniTask.WaitUntil(() => IsFinished(self), cancellationToken: token);
        }

        private static bool IsFinished(PlayableDirector playableDirector)
        {
            return playableDirector.extrapolationMode switch
            {
                // Holdは最後のフレームを維持し続けているのでdurationと現在時間が等しい
                DirectorWrapMode.Hold => playableDirector.duration - playableDirector.time <= double.Epsilon,
                DirectorWrapMode.Loop => false,
                // Noneは再生後最初のフレームに戻るので停止している状態で再生時間が0に等しい
                DirectorWrapMode.None => playableDirector.state is PlayState.Paused &&
                                         playableDirector.time <= double.Epsilon,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}