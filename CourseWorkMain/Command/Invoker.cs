using CourseWorkMain.DB;
using System.Windows.Input;

namespace CourseWorkMain.Command
{
    public class Invoker
    {
        private ApplicationContext _ctx;
        private ICommand command;

        public void SetCommand(ICommand c)
        {
            command = c;
        }

        public void SetCtx(ApplicationContext ctx)
        {
            _ctx = ctx;
        }

        public object Run()
        {
            return command.Execute(_ctx);
        }
    }
}
