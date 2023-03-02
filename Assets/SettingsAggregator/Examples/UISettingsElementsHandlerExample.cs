using SettingsAggregator.UI;

namespace SettingsAggregator.Examples
{
    public class UISettingsElementsHandlerExample : UISettingsElementsHandlerBase
    {
        private GameInput _input;

        protected override void GetInputSystem()
        {
            _input = new GameInput();
            _input.Enable();
        }

        protected override void SubscribeInput()
        {
            _input.Menu.Right.performed += NextPerformed;
            _input.Menu.Left.performed += PrevPerformed;
        }

        protected override void UnsubscribeInput()
        {
            _input.Menu.Right.performed -= NextPerformed;
            _input.Menu.Left.performed -= PrevPerformed;
        }
    }
}
