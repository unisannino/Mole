using System;
using UniRx;

namespace Unisannino.Mole.Runtime.Model
{
    public class GameTimerUseCase
    {
        private bool _isRunning;
        private FloatReactiveProperty _currentTimeReactiveProperty;
        private float _maxTime;

        public float CurrentTime => _currentTimeReactiveProperty.Value;

        public GameTimerUseCase(float maxTime)
        {
            Initialize(maxTime);
        }

        public void Initialize(float maxTime)
        {
            _maxTime = maxTime;
            _currentTimeReactiveProperty = new FloatReactiveProperty();
            Reset();
        }

        public void Reset()
        {
            _currentTimeReactiveProperty.Value = 0;
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Update(float deltaTime)
        {
            if (!_isRunning)
            {
                return;
            }

            _currentTimeReactiveProperty.Value += deltaTime;
        }

        public void Pause()
        {
            _isRunning = false;
        }
        
        public void Stop()
        {
            _isRunning = false;
            Reset();
        }
        
        public IObservable<float> OnFinishCountingAsObservable()
        {
            return _currentTimeReactiveProperty
                .Where(x => x >= _maxTime);
        }
    }
}