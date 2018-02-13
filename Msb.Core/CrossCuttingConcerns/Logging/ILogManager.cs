namespace Msb.Core.CrossCuttingConcerns.Logging
{
    public interface ILogManager
    {
        //Adaptör Tasarım Desenini uygulayacağız. Log4Net de aşağıdakilerden biri olmayabilir.

        void Debug(string message);

        void Info(string message);

        void Warning(string message);

        void Error(string message);

        void Fatal(string message);
    }
}
