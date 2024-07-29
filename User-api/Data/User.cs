using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace User_api.Data
{
    public class User
    {
        public string user_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string user_status { get; set; }

        public String department {  get; set; }

    }
}
