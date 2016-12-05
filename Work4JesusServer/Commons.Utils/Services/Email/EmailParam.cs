namespace Commons.Utils.Services.Email
{
    public class EmailParam
    {
        public string ToEmail { get; private set; }
        public string Subject { get; private set; }
        public string Message { get; private set; }

        public EmailParam(string toEmail, string subject, string message)
        {
            ToEmail = toEmail;
            Subject = subject;
            Message = message;
        }
    }
}