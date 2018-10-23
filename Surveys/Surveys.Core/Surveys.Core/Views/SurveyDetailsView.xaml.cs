

namespace Surveys.Core.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Surveys.Core.Models;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveyDetailsView : ContentPage
	{
        private readonly string[] teams =
        {
            "Alianza Lima",
            "América",
            "Boca junior",
            "Caracas FC",
            "Colo-Colo",
            "Peñarol",
            "Real Madrid",
            "Saprissa"

        };

		public SurveyDetailsView ()
		{
			InitializeComponent ();
		}

        private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
        {
            var favoriteTeam = await
                DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, teams);

            if (!String.IsNullOrWhiteSpace(favoriteTeam))
            {
                FAvoriteTeamLabel.Text = favoriteTeam;    
            }
        }

        private void OKButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}