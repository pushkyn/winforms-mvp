using WinformsMVP.View;

namespace WinformsMVP.Presenter
{
    public class CustomerPresenter
    {
        private readonly ICustomerView _view;

        public CustomerPresenter(ICustomerView view)
        {
            _view = view;
        }
    }
}
