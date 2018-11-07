
namespace Surveys.Core.Views
{
    using System;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveysViews : ContentPage
	{
		public SurveysViews ()
		{
			InitializeComponent ();


            //version 1
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
            //version 2
            MessagingCenter.Subscribe<SurveyViewModel>(this,
                Messages.NewSurvey, async (sender) =>
                 {
                     await Navigation.PushAsync(new
                         SurveyDetailsView());

                 });
    }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new SurveyDetailsView());
        //}
    }
}