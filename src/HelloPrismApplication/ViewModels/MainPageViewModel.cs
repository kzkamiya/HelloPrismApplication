using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.AppModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using HelloPrismApplication.Resources;
using HelloPrismApplication.Models;

namespace HelloPrismApplication.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private TodoItem _todoItem;
        public TodoItem TodoItem { get => _todoItem; set => _todoItem = value; }

        public DelegateCommand NextPage { get; set; }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
            NextPage = new DelegateCommand(NextPageNavigate);
            _todoItem = new TodoItem();
        }

        private void NextPageNavigate()
        {
            var navigationParameter = new NavigationParameters();
            navigationParameter.Add(AppResources.TodoItemKey, _todoItem);

            base._navigationService.NavigateAsync(AppResources.ViewAKey,navigationParameter);                
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            // TODO: Implement your initialization logic
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            // TODO: Handle any final tasks before you navigate away
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            switch (parameters.GetNavigationMode())
            {
                case NavigationMode.Back:
                    // TODO: Handle any tasks that should occur only when navigated back to
                    break;
                case NavigationMode.New:
                    // TODO: Handle any tasks that should occur only when navigated to for the first time
                    break;
            }

            // TODO: Handle any tasks that should be done every time OnNavigatedTo is triggered
        }

    }
}