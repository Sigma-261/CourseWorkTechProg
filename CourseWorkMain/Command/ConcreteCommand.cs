using CourseWorkMain.DB;

namespace CourseWorkMain.Command
{
    public class GetBusinessTripsCommand : ICommand
    {
        ReceiverGetBusinessTrips receiver;
        public GetBusinessTripsCommand(ReceiverGetBusinessTrips r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.GetBusinessTrips(ctx);
        }
    }

    public class GetBusinessTripsByEmployeeCommand : ICommand
    {
        ReceiverGetBusinessTripsByEmployee receiver;
        public GetBusinessTripsByEmployeeCommand(ReceiverGetBusinessTripsByEmployee r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.GetBusinessTripsByEmployee(ctx);
        }
    }

    public class GetBusinessTripsByIdCommand : ICommand
    {
        ReceiverGetBusinessTripsById receiver;
        public GetBusinessTripsByIdCommand(ReceiverGetBusinessTripsById r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.GetBusinessTripsById(ctx);
        }
    }

    public class CreateBusinessTripCommand : ICommand
    {
        ReceiverCreateBusinessTrip receiver;
        public CreateBusinessTripCommand(ReceiverCreateBusinessTrip r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.CreateBusinessTrip(ctx);
        }
    }

    public class UpdateBusinessTripCommand : ICommand
    {
        ReceiverUpdateBusinessTrip receiver;
        public UpdateBusinessTripCommand(ReceiverUpdateBusinessTrip r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.UpdateBusinessTrip(ctx);
        }
    }

    public class DeleteBusinessTripCommand : ICommand
    {
        ReceiverDeleteBusinessTrip receiver;
        public DeleteBusinessTripCommand(ReceiverDeleteBusinessTrip r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.DeleteLocality(ctx);
        }
    }

    public class GetLStatisticBudgetsCommand : ICommand
    {
        ReceiverGetLStatisticBudgets receiver;
        public GetLStatisticBudgetsCommand(ReceiverGetLStatisticBudgets r)
        {
            receiver = r;
        }
        public object Execute(ApplicationContext ctx)
        {
            return receiver.GetLStatisticBudgets();
        }
    }
}
