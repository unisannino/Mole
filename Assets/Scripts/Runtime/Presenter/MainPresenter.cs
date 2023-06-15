using Unisannino.Mole.Runtime.Model;
using Unisannino.Mole.Runtime.View;
using VContainer.Unity;

namespace Unisannino.Mole.Runtime.Presenter
{
    public class MainPresenter : IInitializable, IStartable, ITickable
    {
        private GameTimerUseCase _gameTimerUseCase;
        private WhackAMoleUseCase _whackAMoleUseCase;
        private MoleContainer _moleContainer;
        private UIPanel _uiPanel;

        public MainPresenter(
            GameTimerUseCase gameTimerUseCase,
            WhackAMoleUseCase whackAMoleUseCase,
            MoleContainer moleContainer,
            UIPanel uiPanel)
        {
            _gameTimerUseCase = gameTimerUseCase;
            _whackAMoleUseCase = whackAMoleUseCase;
            _moleContainer = moleContainer;
            _uiPanel = uiPanel;
        }

        public void Initialize()
        {
            
        }

        public void Start()
        {
        }

        public void Tick()
        {
            
        }
    }
}
