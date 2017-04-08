using System;

namespace WAMWayStyles.Infrastructure
{
    public static class SerilogExtensions
    {
        public static string ToExceptionDetailString(this Exception ex)
        {
            return getStringForException(ex);
        }

        private static string getStringForException(Exception ex)
        {
            if (ex.InnerException != null)
            {
                return ex.ToString() + "\r\n\r\n#####################\r\n\r\n" + getStringForException(ex.InnerException);
            }
            return ex.ToString();
        }
    }
}
