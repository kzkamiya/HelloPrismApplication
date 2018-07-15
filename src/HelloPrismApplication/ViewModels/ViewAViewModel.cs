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

using DebugLogger = HelloPrismApplication.Services.DebugLogger;

namespace HelloPrismApplication.ViewModels
{
    public class ViewAViewModel : ViewModelBase
    {

        public DelegateCommand NextPage { get; set; }


        private string _name;
        public string Name { get => _name; set => _name = value; }

        private TodoItem _todoItem;
        public TodoItem TodoItem { get => _todoItem; set => _todoItem = value; }

        public ViewAViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
                                 IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
            Title = AppResources.MainPageTitle;
            NextPage = new DelegateCommand(NextPageNavigate);
            _name = "TEST NAME";
            _todoItem = new TodoItem();
            _todoItem.Name = "No Data";
        }

        private void NextPageNavigate()
        {
            base._navigationService.NavigateAsync(AppResources.SplashScreenPageKey);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters != null)
            {
                if (parameters.ContainsKey(AppResources.TodoItemKey) ){
                    // OK. 画面表示可能。
                     TodoItem = parameters.GetValue<TodoItem>(AppResources.TodoItemKey);
                    // NG.. これだと画面表示できない。
                    //_todoItem = parameters.GetValue<TodoItem>(AppResources.TodoItemKey);
                    base.LOG.Debug("_todoItem.Name = " + _todoItem.Name);

                }
            }
             
        }

        public override void OnNavigatedFrom(NavigationParameters parameters)
        {
            
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