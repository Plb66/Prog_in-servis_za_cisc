

using System.Configuration;

namespace SZC_API.Services
{
    public class DlApplicationData
    {
        public static string ConnectionString;

        static DlApplicationData()
        {

        }

        public static void SetConnectionString(string pConnectionString)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
    }
}