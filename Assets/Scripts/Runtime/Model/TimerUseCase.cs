using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using UnityEngine;

namespace Unisannino.Mole.Runtime.Model
{
    public class TimerUseCase
    {
        private bool _isRunning;
        private bool _isCompleted;
        private float _currentTime;
        private float _completeTime;

        public bool IsRunning => _isRunning;
        public float CurrentTime => _currentTime;

        public TimerUseCase(float completeTime)
        {
            Initialize(completeTime);
        }

        public void Initialize(float completeTime)
        {
            _completeTime = completeTime;
            Reset();
        }

        public void Continue()
        {
            _isRunning = true;
        }

        public void Pause()
        {
            _isRunning = false;
        }
        
        public UniTask WaitTimerCompletedAsync(CancellationToken token)
        {
            return UniTask.WaitWhile(() => !_isRunning && _isCompleted, cancellationToken: token);
        }

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            _currentTime = 0;
            _isRunning = true;
            _isCompleted = false;
            await UniTaskAsyncEnumerable.EveryUpdate()
                .TakeWhile(_ => _currentTime < _completeTime)
                .Where(_ => _isRunning)
                .ForEachAsync(_ => _currentTime += Time.deltaTime, cancellationToken);

            _isRunning = false;
            _isCompleted = true;
        }
        
        private void Reset()
        {
            _currentTime = 0;
        }
    }
}