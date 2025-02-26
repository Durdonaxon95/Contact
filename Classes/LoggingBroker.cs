namespace Consol.Classes
{
    public static class LoggingBroker
    {
        public static void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[XATO] {DateTime.Now}: Siz noto'g'ri qiymat kiritdingiz!");
            Console.ResetColor();
        }

        public static void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
            Console.ResetColor();
        }
    }
    public static class TryCatch
    {
        public static void Handle(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LoggingBroker.LogError(ex.Message);
            }
        }
    }
}    