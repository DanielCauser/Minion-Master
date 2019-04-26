using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MinionMaster.Root
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "Main Page";

            GoToMaster = ReactiveCommand.CreateFromTask(async () => await navigationService.NavigateAsync("MasterPage"));

            GoToMinion = ReactiveCommand.CreateFromTask(async () => await navigationService.NavigateAsync("MinionPage"));
        }

        public ICommand GoToMaster { get; }
        public ICommand GoToMinion { get; }
    }
}
