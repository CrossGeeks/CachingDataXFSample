using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CachingDataSample.Models;
using CachingDataSample.Services;
using Xamarin.Forms;

namespace CachingDataSample.ViewModels
{
    public class MakeUpPageViewModel: INotifyPropertyChanged
    {
        protected IApiManager ApiManager = new ApiManager();

        public ICommand GetMakeUpsCommand { get; set; }
        public ObservableCollection<MakeUp> MakeUps { get; set; }
        public bool IsRunning { get; set; }

        public MakeUpPageViewModel()
        {
            GetMakeUpsCommand = new Command(async () => await GetMakeUps());
            GetMakeUpsCommand.Execute(null);
        }

        async Task GetMakeUps()
        {
            IsRunning = true;

            var result = await ApiManager.GetMakeUpsAsync();
            if (result != null)
                 MakeUps = new ObservableCollection<MakeUp>(result);

            IsRunning = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
