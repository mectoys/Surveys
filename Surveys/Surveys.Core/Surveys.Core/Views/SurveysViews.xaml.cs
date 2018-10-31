
namespace Surveys.Core.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Surveys.Core.Views;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveysViews : ContentPage
	{
		public SurveysViews ()
		{
			InitializeComponent ();

            

        // MessagingCenter.Subscribe<ContentPage,
        //   Survey>(this,Messages.NewSurveyComplete,(sender,arg))

        /*MessagingCenter.Subscribe<ContentPage, Survey>
           (this, Messages.NewSurveyComplete, (sender, args) =>
           {
               SurveysPanel.Children.Add(new Label()
               {
                   Text = args.ToString()

               });

            });
            */
    }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SurveyDetailsView());
        }
    }
}