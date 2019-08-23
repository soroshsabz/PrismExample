using Prism.Commands;
using Prism.Mvvm;

namespace PrismWpfExample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
		public MainWindowViewModel()
        {
			ShowDateStringCommand = new DelegateCommand(ShowDateString);
			DateString = "خالی";
        }

		void ShowDateString()
		{
			DateString = "سلام علیکم";
		}

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }


		public string DateString
		{
			get => _dateString;
			set => SetProperty(ref _dateString, value);
		}

		public DelegateCommand ShowDateStringCommand { get; private set; }

		private string _dateString;
        private string _title = "Prism Application";
    }
}
