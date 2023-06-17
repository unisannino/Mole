using System;
using UniRx;
using Unisannino.Mole.Runtime.Extensions;
using UnityEngine;

namespace Unisannino.Mole.Runtime.View
{
    public class MoleContainer : MonoBehaviour
    {
        [SerializeField] private Mole[] moles;
        
        private readonly ISubject<int> _onWhackMoleSubject = new Subject<int>();

        public IObservable<int> OnWhackMoleAsObservable => _onWhackMoleSubject;

        public void Initialize()
        {
            foreach (var (mole, index) in moles.WithIndex())
            {
                mole.OnPointerDownAsObservable
                    .Subscribe(_ => _onWhackMoleSubject.OnNext(index))
                    .AddTo(this);
            }
        }
        
        public void PresentMole(int index, float speedScale)
        {
            moles[index].Present(speedScale);
        }

        public void DismissMole(int index, bool isWhacked)
        {
            
        }
    }
}