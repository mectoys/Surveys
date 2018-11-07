

namespace Surveys.Core.Views
{
    using Surveys.Core.Models;
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Surveys.Core.ViewModels;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveyDetailsView : ContentPage
	{
        //private readonly string[] teams =
        //{
        //    "Alianza Lima",
        //    "América",
        //    "Boca junior",
        //    "Caracas FC",
        //    "Colo-Colo",
        //    "Peñarol",
        //    "Real Madrid",
        //    "Saprissa"
        //};

		public SurveyDetailsView ()
		{
			InitializeComponent ();

            MessagingCenter.Subscribe<SurveyDetailsViewModel,
                String[]>(this, Messages.SelectTeam, 
                                async (sender, args) =>
                            {
                                 var favoriteTeam = await
                                 DisplayActionSheet(Literals.FavoriteTeamTitle, null,
                                 null, args);

                                 if (!string.IsNullOrWhiteSpace(favoriteTeam))
                                 {
                                     MessagingCenter.Send((ContentPage)this,
                                         Messages.TeamSelected, favoriteTeam);
                                 }
                             });

            MessagingCenter.Subscribe<SurveyDetailsViewModel,
                Survey>(this, Messages.NewSurveyComplete, async (sender,
                  args) =>
                  {
                      await Navigation.PopAsync();

                  });
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<SurveyDetailsViewModel, string[]>
                (this, Messages.SelectTeam);
            MessagingCenter.Unsubscribe<SurveyDetailsViewModel, Survey>
                (this, Messages.NewSurveyComplete);
        }

        //private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
        //{
        //    var favoriteTeam = await
        //        DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, teams);

        //    if (!string.IsNullOrWhiteSpace(favoriteTeam))
        //    {
        //        FAvoriteTeamLabel.Text = favoriteTeam;    
        //    }
        //}

        //private async  void OKButton_Clicked(object sender, EventArgs e)
        //{
        //    //evaluamos si los datos estan completos
        //    if (string.IsNullOrWhiteSpace(NameEntry.Text)||
        //        string.IsNullOrWhiteSpace(FAvoriteTeamLabel.Text))
        //    {
        //        return;
        //    }

        //    //creamos el nuevo objeto de tipo survey
        //    var newSurvey = new Survey()
        //    {

        //        Name = NameEntry.Text,
        //        Birthdate = BirthdatePicker.Date,
        //        FavoriteTeam = FAvoriteTeamLabel.Text

        //    };

        ////publicacmos el mensaje con el objeto de encuesta como argumento
        //MessagingCenter.Send((ContentPage)this,
        //    Messages.NewSurveyComplete, newSurvey);

        ////removemos la pagina de la pila de navegacion para regresar inmediatamente
        //await Navigation.PopAsync();
        //}
    }
}