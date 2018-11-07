using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Surveys.Core.ServicesInterfaces
{
   public interface IGeolocationService
    {

        Task<Tuple<double, double>> GetCurrentLocationAsync();


    }
}
