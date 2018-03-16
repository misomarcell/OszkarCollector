using Models.Objects;
using Models.Pages;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository
    {
        List<RidePage> GetAllRides();
        RidePage GetRide(string id);
        int AddRide(RidePage page);
    }
}