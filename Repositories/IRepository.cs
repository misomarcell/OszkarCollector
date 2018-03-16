using Domain.Pages;
using System.Collections.Generic;

namespace Repositories
{
    public interface IRepository
    {
        List<RidePage> GetRides(int page);
        RidePage GetRide(string id);
        int AddRide(RidePage page);
    }
}