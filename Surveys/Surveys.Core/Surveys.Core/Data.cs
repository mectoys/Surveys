using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Surveys.Core
{
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

        public Data()
        {

                Surveys = new 
            ObservableCollection<Survey>();
            MessagingCenter.Subscribe<ContentPage,
                Survey>(this, Messages.NewSurveyComplete,
                                    (sender, args) =>
                                    {
                                        Surveys.Add(args);
                                    });

        }
    }
}
