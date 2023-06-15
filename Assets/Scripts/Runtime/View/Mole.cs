using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Unisannino.Mole.Runtime.View
{
    [RequireComponent(typeof(Animator), typeof(Collider2D))]
    public class Mole : MonoBehaviour, IPointerDownHandler
    {
        private static readonly int PresentTriggerID = Animator.StringToHash("Present");
        private static readonly int DismissTriggerID = Animator.StringToHash("Dismiss");
        
        [SerializeField] private SpriteRenderer moleRenderer;
        [SerializeField] private SpriteRenderer holeRenderer;
        
        private Animator _animator;
        private ISubject<Unit> _onPointerDownSubject = new Subject<Unit>();

        public IObservable<Unit> OnPointerDownAsObservable => _onPointerDownSubject;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Present()
        {
            _animator.SetTrigger(PresentTriggerID);
        }

        public void Dismiss()
        {
            _animator.SetTrigger(DismissTriggerID);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _onPointerDownSubject.OnNext(Unit.Default);
        }
    }
}