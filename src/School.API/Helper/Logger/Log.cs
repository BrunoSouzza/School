using System.Text;

namespace School.API.Helper.Logger
{
    public class Log : ILog
    {
        private static readonly Lazy<Log> _instance =new Lazy<Log>(() => new Log());

        public static Log GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void LogInfo(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
