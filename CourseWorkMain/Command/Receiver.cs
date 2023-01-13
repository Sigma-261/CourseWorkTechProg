using CourseWorkMain.DB;
using CourseWorkMain.Models;
using CourseWorkMain.Models.ViewModels;
using MathNet.Numerics.Statistics;
using Microsoft.EntityFrameworkCore;

using CourseWorkMain.GoFIterator;

namespace CourseWorkMain.Command
{
    public class ReceiverGetBusinessTrips
    {
        public object GetBusinessTrips(ApplicationContext ctx)
        {
            return ctx.BusinessTrips.ToList();
        }
    }

    public class ReceiverGetBudgets
    {
        public object GetBudgets(ApplicationContext ctx)
        {
            List<double> Temp = new List<double>();

            BudgetsAggregate la = new BudgetsAggregate();

            var selectedBudgets = (from b in ctx.BusinessTrips
                                   select Convert.ToDouble(b.Wage)).ToList();

            la.FillItems(selectedBudgets);

            Iterator i = la.CreateIterator();

            object item = i.First();

            while (item != null)
            {
                Temp.Add(Convert.ToDouble(item));
                item = i.Next();
            }

            return Temp.ToArray();
        }
    }

    public class ReceiverGetLStatisticBudgets
    {
        public double[]? Budgets;

        public ReceiverGetLStatisticBudgets(double[]? budgets = null)
        {
            Budgets = budgets;
        }

        public object GetLStatisticBudgets()
        {
            Stats res = new Stats();

            res.Median = Statistics.Median(Budgets);
            res.Mean = Statistics.Mean(Budgets);
            res.Max = Statistics.Maximum(Budgets);
            res.Min = Statistics.Minimum(Budgets);

            return res;
        }
    }

    public class ReceiverGetBusinessTripsByEmployee
    {
        public string Employee;

        public ReceiverGetBusinessTripsByEmployee(string employee)
        {
            Employee = employee;
        }

        public object GetBusinessTripsByEmployee(ApplicationContext ctx)
        {
            var businessTrips = ctx.BusinessTrips.Where(l => l.Employee == Employee).ToList();
            return businessTrips;
        }
    }

    
    public class ReceiverGetBusinessTripsById
    {
        public int Id;

        public ReceiverGetBusinessTripsById(int id)
        {
            Id = id;
        }

        public object GetBusinessTripsById(ApplicationContext ctx)
        {
            var businessTrips = ctx.BusinessTrips.Find(Id);
            return businessTrips;
        }
    }

    public class ReceiverCreateBusinessTrip
    {
        public BusinessTrip BusinessTrip;

        public ReceiverCreateBusinessTrip(BusinessTrip loc = null)
        {
            BusinessTrip = loc;
        }

        public bool CreateBusinessTrip(ApplicationContext ctx)
        {
            if (BusinessTrip != null)
            {
                ctx.BusinessTrips.Add(BusinessTrip);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }

    public class ReceiverUpdateBusinessTrip
    {
        public BusinessTrip Loc;

        public ReceiverUpdateBusinessTrip(BusinessTrip loc = null)
        {
            Loc = loc;
        }

        public bool UpdateBusinessTrip(ApplicationContext ctx)
        {
            if (Loc != null)
            {
                ctx.Entry(Loc).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }

    public class ReceiverDeleteBusinessTrip
    {
        public int Id;

        public ReceiverDeleteBusinessTrip(int id = 0)
        {
            Id = id;
        }

        public bool DeleteLocality(ApplicationContext ctx)
        {
            BusinessTrip loc = ctx.BusinessTrips.Find(Id);

            if (Id != null)
            {
                ctx.BusinessTrips.Remove(loc);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
