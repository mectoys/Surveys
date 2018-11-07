

namespace Surveys.Core.ViewModels
{
    using Surveys.Core.ServicesInterfaces;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class SurveyDetailsViewModel : NotificationObject
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged();
            }
        }

        private DateTime birthdate;

        public DateTime Birthdate
        {
            get
            {
                return birthdate;
            }

            set
            {
                if (birthdate == value)
                {
                    return;
                }
                birthdate = value;
                OnPropertyChanged();
            }
        }

        private string favoriteTeam;

        public string FavoriteTeam
        {
            get
            {
                return favoriteTeam;
            }

            set
            {
                if (favoriteTeam == value)
                {
                    return;
                }
                favoriteTeam = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> teams;

        public ObservableCollection<string> Teams
        {
            get
            {
                return teams;
            }

            set
            {
                if (teams == value)
                {
                    return;
                }
                teams = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectTeamCommand { get; set; }
        public ICommand EndSurveyCommand { get; set; }
        public SurveyDetailsViewModel()
        {
            Teams =
                new ObservableCollection<string>(new[]
                {
                      "Alianza Lima", "América",  "Boca junior",
                "Caracas FC", "Colo-Colo", "Peñarol",  "Real Madrid", "Saprissa"
                });

            SelectTeamCommand = new
                Command(SelectTeamCommandExecute);

            EndSurveyCommand = new 
                Command(EndSurveyCommandExecute, EndSurveyCommandCanExecute);

            //Suscripcion al mensaje teamselected
            MessagingCenter.Subscribe<ContentPage, string>(this,
                Messages.TeamSelected, (sender, args) => { FavoriteTeam = args; });

            PropertyChanged += SurveyDetailsViewModel_PropertyChanged;

    }
        private void SurveyDetailsViewModel_PropertyChanged(object sender,
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Name)||
                e.PropertyName== nameof(FavoriteTeam))
            {
                (EndSurveyCommand as Command)?.ChangeCanExecute();
            }
        }

        private async void EndSurveyCommandExecute()
        {
            var newSurvey = new Survey()
            {
                Name = name
            ,
                Birthdate = Birthdate
            ,
                FavoriteTeam = FavoriteTeam
            };

            var geolocationService =
                DependencyService.Get<IGeolocationService>();
            if (geolocationService != null)
            {
                try
                {
                    var currentLocation = await
                        geolocationService.GetCurrentLocationAsync();
                    newSurvey.Lat = currentLocation.Item1;
                    newSurvey.Lon = currentLocation.Item2;
                }
                catch (Exception)
                {
                    newSurvey.Lat = 0;
                    newSurvey.Lon = 0;
                }
            }

            MessagingCenter.Send(this,
                Messages.NewSurveyComplete, newSurvey);
        }


        private bool EndSurveyCommandCanExecute()
        {

            return !string.IsNullOrWhiteSpace(Name) &&
                !string.IsNullOrWhiteSpace(FavoriteTeam);

        }

        private void SelectTeamCommandExecute()
        {
            MessagingCenter.Send(this, Messages.SelectTeam,
                Teams.ToArray());
        }

     
    }
}
