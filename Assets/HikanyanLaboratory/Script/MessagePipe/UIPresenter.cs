using MessagePipe;
using R3;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.MessagePipe
{
    public class UIPresenter : IInitializable
    {
        [Inject] 
        private UIView _view;

        [Inject] 
        private UIModel _model;

        [Inject] 
        private readonly ISubscriber<Unit> _unitSubscriber;

        [Inject] 
        private readonly ISubscriber<int> _intSubscriber;

        public UIPresenter(ISubscriber<Unit> unitSubscriber, ISubscriber<int> intSubscriber)
        {
            _unitSubscriber = unitSubscriber;
            _intSubscriber = intSubscriber;
        }

        public void Initialize()
        {
            _unitSubscriber.Subscribe((_) =>
            {
                _model.CountNumber();
            });

            _intSubscriber.Subscribe(num =>
            {
                _view.ChangeText(num);
            });
        }
    }

}