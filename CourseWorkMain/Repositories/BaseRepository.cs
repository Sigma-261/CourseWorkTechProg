using CourseWorkMain.Command;
using CourseWorkMain.DB;
using CourseWorkMain.Models;
using CourseWorkMain.Models.ViewModels;
using MathNet.Numerics.Statistics;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkMain.Repositories
{
    public class BaseRepository: IRepository
    {
        public ApplicationContext _ctx;
        private Dictionary<string, ICommand> _commands;
        private readonly ILogger<BaseRepository> _logger;

        public BaseRepository(ApplicationContext ctx, ILogger<BaseRepository> logger = null)
        {
            _ctx = ctx;
            _logger = logger;
            FillCommands();
        }

        /// <summary>
        /// Получить всю информаци по всем локациям
        /// </summary>
        /// <returns>Лист локаций</returns>
        public List<BusinessTrip> GetBusinessTrips()
        {
            try
            {
                return ExcuteCommand("GetBusinessTrips") as List<BusinessTrip>;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Получить локацию по айди
        /// </summary>
        /// <returns>Локация</returns>
        public BusinessTrip GetBusinessTripById(int Id)
        {
            try
            {
                _commands["GetBusinessTripById"] = new GetBusinessTripsByIdCommand(new ReceiverGetBusinessTripsById(Id));
                return ExcuteCommand("GetBusinessTripById") as BusinessTrip;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Получить всю информаци по всем локациям
        /// </summary>
        /// <returns>Лист локаций</returns>
        public List<BusinessTrip> GetBusinessTripsByEmployee(string Mayor)
        {
            _commands["GetBusinessTripsByEmployee"] = new GetBusinessTripsByEmployeeCommand(new ReceiverGetBusinessTripsByEmployee(Mayor));
            return ExcuteCommand("GetBusinessTripsByEmployee") as List<BusinessTrip>;
        }

        /// <summary>
        /// Создать локацию
        /// </summary>
        public bool CreateBusinessTrip(BusinessTrip loc)
        {
            _commands["CreateBusinessTrip"] = new CreateBusinessTripCommand(new ReceiverCreateBusinessTrip(loc));
            return (bool)ExcuteCommand("CreateBusinessTrip");
        }

        /// <summary>
        /// Редактировать локацию
        /// </summary>
        public bool UpdateBusinessTrip(BusinessTrip loc)
        {
            _commands["UpdateBusinessTrip"] = new UpdateBusinessTripCommand(new ReceiverUpdateBusinessTrip(loc));
            return (bool)ExcuteCommand("UpdateBusinessTrip");
        }

        /// <summary>
        /// Редактировать локацию
        /// </summary>
        public bool DeleteBusinessTrip(int id)
        {
            _commands["DeleteBusinessTrip"] = new DeleteBusinessTripCommand(new ReceiverDeleteBusinessTrip(id));
            return (bool)ExcuteCommand("DeleteBusinessTrip");
        }

        /// <summary>
        /// Получить статистические показатели бюджета
        /// </summary>
        public Stats GetLStatisticBudgets(double[]? budgets)
        {
            _commands["GetLStatisticBudgets"] = new GetLStatisticBudgetsCommand(new ReceiverGetLStatisticBudgets(budgets));
            return ExcuteCommand("GetLStatisticBudgets") as Stats;
        }

        /// <summary>
        /// Получть бюджеты
        /// </summary>
        /// <returns>Массив бюджетов</returns>


        private void FillCommands()
        {
            _commands = new Dictionary<string, ICommand>();

            _commands.Add("GetBusinessTrips", new GetBusinessTripsCommand(new ReceiverGetBusinessTrips()));
            _commands.Add("GetLocalitiesByMajor", new GetBusinessTripsByEmployeeCommand(new ReceiverGetBusinessTripsByEmployee("")));
            _commands.Add("GetLocalityById", new GetBusinessTripsByIdCommand(new ReceiverGetBusinessTripsById(0)));
            _commands.Add("CreateBusinessTrip", new CreateBusinessTripCommand(new ReceiverCreateBusinessTrip()));
            _commands.Add("UpdateBusinessTrip", new UpdateBusinessTripCommand(new ReceiverUpdateBusinessTrip()));
            _commands.Add("DeleteBusinessTrip", new DeleteBusinessTripCommand(new ReceiverDeleteBusinessTrip()));
            _commands.Add("GetLStatisticBudgets", new GetLStatisticBudgetsCommand(new ReceiverGetLStatisticBudgets()));
        }

        private object ExcuteCommand(string command)
        {
            Invoker invoker = new Invoker();

            invoker.SetCtx(_ctx);
            invoker.SetCommand(_commands[command]);
            return invoker.Run();
        }
    }
}