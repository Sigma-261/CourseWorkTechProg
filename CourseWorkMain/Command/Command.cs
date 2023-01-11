using CourseWorkMain.DB;

namespace CourseWorkMain.Command
{
    public interface ICommand
    {
        object Execute(ApplicationContext ctx);
    }
}
