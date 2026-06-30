using System;
using System.Collections.Generic;
using System.Text;

namespace claseLogica
{
    public class Users
    {
        public int User_id { get; set; }

        public string Office { get; set; }
        
        public int Office_ID { get; set; }
        public int Role_id { get; set; }
        public string Role { get; set; }

        public string Email { get; set; }

        public int password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthdate { get; set; }

        public bool Active { get; set; }

        public int Edad
        {
            get
            {
                int edad = DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now < Birthdate.AddYears(edad))
                {
                    edad--;
                }
                return edad;
            }
        }

    }
}
