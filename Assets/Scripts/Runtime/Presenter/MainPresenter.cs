using Unisannino.Mole.Runtime.Model;
using Unisannino.Mole.Runtime.View;
using VContainer.Unity;

namespace Unisannino.Mole.Runtime.Presenter
{
    public class MainPresenter : IInitializable, IStartable, ITickable
    {
        private GameTimerUseCase _gameTimerUseCase;
        private MoleUseCase _moleUseCase;
        private MoleContainer _moleContainer;
        private UIPanel _uiPanel;

        public MainPresenter(
            GameTimerUseCase gameTimerUseCase,
            MoleUseCase moleUseCase,
            MoleContainer moleContainer,
            UIPanel uiPanel)
        {
            _gameTimerUseCase = gameTimerUseCase;
            _moleUseCase = moleUseCase;
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
