

namespace Surveys.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public  class Survey
    {
        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public string FavoriteTeam { get; set; }

        public override string ToString()
        {
            //reemplazamos el metodo tostring() para devolver una cadena contatenada
            return $"{Name}| {Birthdate} | {FavoriteTeam}";
        }
    }
}
