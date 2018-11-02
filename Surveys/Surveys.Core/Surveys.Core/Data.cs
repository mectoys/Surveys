

namespace Surveys.Core
{

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xamarin.Forms;
   
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public  class Data :NotificationObject
    {
        private ObservableCollection<Survey> surveys;

        public ObservableCollection<Survey> Surveys
        {

            get
            {
                return surveys;
            }

            set
            {
                if (surveys == value)
                {
                    return;
                }
                surveys = value;
                OnPropertyChanged();

            }
        }
        private Survey selectedSurvey;

        public Survey SelectedSurvey
        {
            get
            {
                return selectedSurvey;
            }

            set
            {
                if (selectedSurvey==value)
                {
                    return;
                }
                selectedSurvey = value;
                OnPropertyChanged();
            }            
        }
        public ICommand NewSurveyCommand { get; set; }

        public Data()
        {
            //
                Surveys = new 
               ObservableCollection<Survey>();
                MessagingCenter.Subscribe<ContentPage,
                    Survey>(this, Messages.NewSurveyComplete,
                                    (sender, args) =>
                                    {
                                        Surveys.Add(args);
                                    });

            NewSurveyCommand = new 
                Command(NewSurveyCommandExecute);
        }
        private void NewSurveyCommandExecute()
        {



        }
    }
}
