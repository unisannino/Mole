using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UniRx;
using Unisannino.Mole.Runtime.Model;
using Unisannino.Mole.Runtime.View;
using VContainer.Unity;

namespace Unisannino.Mole.Runtime.Presenter
{
    public class MainPresenter : IInitializable, IStartable, ITickable, IDisposable
    {
        private TimerUseCase _timerUseCase;
        private MoleUseCase _moleUseCase;
        private MoleContainer _moleContainer;
        private GameUIPanel _gameUIPanel;

        private CompositeDisposable _compositeDisposable = new();
        private readonly CancellationTokenSource _cancellationTokenSource = new();

        public MainPresenter(
            TimerUseCase timerUseCase,
            MoleUseCase moleUseCase,
            MoleContainer moleContainer,
            GameUIPanel gameUIPanel)
        {
            _timerUseCase = timerUseCase;
            _moleUseCase = moleUseCase;
            _moleContainer = moleContainer;
            _gameUIPanel = gameUIPanel;
        }

        public void Initialize()
        {
            _moleContainer.Initialize();
            _moleContainer.OnWhackMoleAsObservable
                .Where(_moleUseCase.CanWhack)
                .Subscribe(id =>
                {
                    _moleUseCase.ChangeCanWhack(id, false);
                })
                .AddTo(_compositeDisposable);
        }

        public void Start()
        {
            StartAsync().Forget();
        }

        public void Tick()
        {
            var currentTime = _timerUseCase.CurrentTime;
            _moleUseCase.CheckSpeedUp(currentTime);
            if (_moleUseCase.CanSpawnMole(currentTime))
            {
                var id = _moleUseCase.SpawnMole();
                _moleContainer.PresentMole(id, _moleUseCase.CurrentSpeedScale);
                _moleUseCase.ChangeCanWhack(id, true);
            }
        }

        private async UniTaskVoid StartAsync()
        {
            await _gameUIPanel.PlayStartGameAsync(_cancellationTokenSource.Token);
            _timerUseCase.StartAsync(_cancellationTokenSource.Token).Forget();
            await _timerUseCase.WaitTimerCompletedAsync(_cancellationTokenSource.Token);
            await _gameUIPanel.PlayEndGameAsync(_cancellationTokenSource.Token);
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Dispose();
            _compositeDisposable?.Dispose();
        }
    }
}