namespace FastBot.Exceptions;

public class TelegramException : Exception
{
    public TelegramException(string message) : base(message) {}
}