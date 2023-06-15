using Unisannino.Mole.Runtime.Model;
using Unisannino.Mole.Runtime.Presenter;
using Unisannino.Mole.Runtime.View;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace Unisannino.Mole.Runtime.LifetimeScopes
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField] private MoleContainer moleContainer;
        [FormerlySerializedAs("uiPanel")] [SerializeField] private GameUIPanel gameUIPanel;
        
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            RegisterModels(builder);
            RegisterViews(builder);
            builder.RegisterEntryPoint<MainPresenter>();
        }
        
        private void RegisterModels(IContainerBuilder builder)
        {
            builder.Register<TimerUseCase>(Lifetime.Scoped);
            builder.Register<MoleUseCase>(Lifetime.Scoped);
        }
        
        private void RegisterViews(IContainerBuilder builder)
        {
            builder.RegisterComponent(moleContainer);
            builder.RegisterComponent(gameUIPanel);
        }
    }
}