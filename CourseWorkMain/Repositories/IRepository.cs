using CourseWorkMain.Models;
using CourseWorkMain.Models.ViewModels;
using MathNet.Numerics.Statistics;

namespace CourseWorkMain.Repositories
{
    public interface IRepository
    {
        List<BusinessTrip> GetBusinessTrips();
        Stats GetLStatisticBudgets(double[]? budgets);
        bool DeleteBusinessTrip(int id);
        bool UpdateBusinessTrip(BusinessTrip loc);
        bool CreateBusinessTrip(BusinessTrip loc);
        List<BusinessTrip> GetBusinessTripsByEmployee(string Employee);
        BusinessTrip GetBusinessTripById(int Id);
    }
}
