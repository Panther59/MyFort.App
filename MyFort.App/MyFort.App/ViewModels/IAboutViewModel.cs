using System.Windows.Input;

namespace MyFort.App.ViewModels
{
	public interface IAboutViewModel
	{
		ICommand OpenWebCommand { get; }
	}
}