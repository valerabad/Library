using System.Configuration;
using System.Web.Configuration;
using System.Data.Linq;

namespace Library.Models
{
    // class for provide data
    public class DBContext
    {
        private static ConnectionStringSettings connString;                           
        public DataContext db { get; }

        public DBContext()
        {
            connString = WebConfigurationManager.ConnectionStrings["DefaultConnection"];
            db = new DataContext(connString.ConnectionString);
        }
    }
}