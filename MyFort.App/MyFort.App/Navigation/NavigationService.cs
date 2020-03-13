using MyFort.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
namespace MyFort.App.Navigation
{
	public class NavigationService : INavigationService
	{
		private readonly IMainPage _presentationRoot;
		private readonly IViewLocator _viewLocator;

		public NavigationService(IMainPage presentationRoot, IViewLocator viewLocator)
		{
			_presentationRoot = presentationRoot;
			_viewLocator = viewLocator;
		}

		private Xamarin.Forms.INavigation Navigator
		{
			get
			{
				if (_presentationRoot.MainRootPage is MasterDetailPage && (_presentationRoot.MainRootPage as MasterDetailPage).Detail is NavigationPage)
				{
					return ((_presentationRoot.MainRootPage as MasterDetailPage).Detail as NavigationPage).Navigation;
				}
				else
				{
					return _presentationRoot.MainRootPage.Navigation;
				}
			}
		}

		public void PresentAsMainPage(BaseViewModel viewModel)
		{
			var page = _viewLocator.CreateAndBindPageFor(viewModel);

			IEnumerable<BaseViewModel> viewModelsToDismiss = FindViewModelsToDismiss(_presentationRoot.MainRootPage);

			if (_presentationRoot.MainRootPage is NavigationPage navPage)
			{
				// If we're replacing a navigation page, unsub from events
				navPage.PopRequested -= NavPagePopRequested;
			}

			viewModel.BeforeFirstShown();

			_presentationRoot.MainRootPage = page;

			foreach (BaseViewModel toDismiss in viewModelsToDismiss)
			{
				toDismiss.AfterDismissed();
			}
		}

		public Page PresentAsNavigatableMainPage<TViewModel>(ref TViewModel viewModel) where TViewModel : BaseViewModel
		{
			viewModel = _viewLocator.GetViewModel<TViewModel>();
			var page = _viewLocator.CreateAndBindPageFor(viewModel);

			NavigationPage newNavigationPage = new NavigationPage(page);

			IEnumerable<BaseViewModel> viewModelsToDismiss = FindViewModelsToDismiss(_presentationRoot.MainRootPage);

			if (_presentationRoot.MainRootPage is NavigationPage navPage)
			{
				navPage.PopRequested -= NavPagePopRequested;
			}

			viewModel.BeforeFirstShown();

			// Listen for back button presses on the new navigation bar
			newNavigationPage.PopRequested += NavPagePopRequested;
			_presentationRoot.MainRootPage = newNavigationPage;

			foreach (BaseViewModel toDismiss in viewModelsToDismiss)
			{
				toDismiss.AfterDismissed();
			}

			return newNavigationPage;
		}

		private IEnumerable<BaseViewModel> FindViewModelsToDismiss(Page dismissingPage)
		{
			var viewmodels = new List<BaseViewModel>();

			if (dismissingPage is NavigationPage)
			{
				viewmodels.AddRange(
					Navigator
						.NavigationStack
						.Select(p => p.BindingContext)
						.OfType<BaseViewModel>()
				);
			}
			else
			{
				var viewmodel = dismissingPage?.BindingContext as BaseViewModel;
				if (viewmodel != null) viewmodels.Add(viewmodel);
			}

			return viewmodels;
		}

		private void NavPagePopRequested(object sender, NavigationRequestedEventArgs e)
		{
			if (Navigator.NavigationStack.LastOrDefault()?.BindingContext is BaseViewModel poppingPage)
			{
				poppingPage.AfterDismissed();
			}
		}

		public async Task NavigateTo(BaseViewModel viewModel)
		{
			var page = _viewLocator.CreateAndBindPageFor(viewModel);

			await viewModel.BeforeFirstShown();

			if (Xamarin.Forms.Application.Current.MainPage is MasterDetailPage masterDetailPage)
			{
				masterDetailPage.IsPresented = false;
			}
			else if (Xamarin.Forms.Application.Current.MainPage is NavigationPage navigationPage && navigationPage.CurrentPage is MasterDetailPage nestedMasterDetail)
			{
				nestedMasterDetail.IsPresented = false;
			}

			await Navigator.PushAsync(page);
		}

		public async Task NavigateBack()
		{
			var dismissing = Navigator.NavigationStack.Last().BindingContext as BaseViewModel;

			await Navigator.PopAsync();

			dismissing?.AfterDismissed();
		}

		public async Task NavigateBackToRoot()
		{
			var toDismiss = Navigator
				.NavigationStack
				.Skip(1)
				.Select(vw => vw.BindingContext)
				.OfType<BaseViewModel>()
				.ToArray();

			await Navigator.PopToRootAsync();

			foreach (BaseViewModel viewModel in toDismiss)
			{
				viewModel.AfterDismissed().FireAndForget();
			}
		}

		public void MasterDetailPage<TViewModel, TMasterViewModel, TDetailViewModel>()
			where TViewModel : BaseViewModel
			where TMasterViewModel : BaseViewModel
			where TDetailViewModel : BaseViewModel
		{
			var viewModel = _viewLocator.GetViewModel<TViewModel>();
			var page = _viewLocator.CreateAndBindPageFor(viewModel) as MasterDetailPage;

			var detailViewModel = _viewLocator.GetViewModel<TDetailViewModel>();
			var detailPage = _viewLocator.CreateAndBindPageFor(detailViewModel);
			NavigationPage newNavigationPage = new NavigationPage(detailPage);
			page.Detail = newNavigationPage;
			
			var masterViewModel = _viewLocator.GetViewModel<TMasterViewModel>();
			page.Master.BindingContext = masterViewModel;

			IEnumerable<BaseViewModel> viewModelsToDismiss = FindViewModelsToDismiss(_presentationRoot.MainRootPage);

			if (_presentationRoot.MainRootPage is NavigationPage navPage)
			{
				navPage.PopRequested -= NavPagePopRequested;
			}

			viewModel.BeforeFirstShown();
			masterViewModel.BeforeFirstShown();
			detailViewModel.BeforeFirstShown();

			// Listen for back button presses on the new navigation bar
			newNavigationPage.PopRequested += NavPagePopRequested;
			_presentationRoot.MainRootPage = page;

			foreach (BaseViewModel toDismiss in viewModelsToDismiss)
			{
				toDismiss.AfterDismissed();
			}
		}
	}
}
