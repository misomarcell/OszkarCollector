using Domain.Models;
using Domain.Pages;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository
    {
        List<RidePage> GetVehicleRides(int page, Vehicle vehicle);
        RidePage GetRide(string id);
        Dictionary<Vehicle, int> GetVehicles(int page);
        int AddRide(RidePage page);
        void Clean();
    }
}