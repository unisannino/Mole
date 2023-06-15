using Unisannino.Mole.Runtime.Model;
using Unisannino.Mole.Runtime.View;
using VContainer.Unity;

namespace Unisannino.Mole.Runtime.Presenter
{
    public class MainPresenter : IInitializable, IStartable, ITickable
    {
        private GameTimerUseCase _gameTimerUseCase;
        private MoleContainer _moleContainer;
        private UIPanel _uiPanel;

        public MainPresenter(
            GameTimerUseCase gameTimerUseCase,
            MoleContainer moleContainer,
            UIPanel uiPanel)
        {
            _gameTimerUseCase = gameTimerUseCase;
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
