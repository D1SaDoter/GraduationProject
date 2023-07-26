using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALINweb.Domain.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Role { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? FName { get; set; }
        public string? SName { get; set; }
        public string? OName { get; set; }
        public string? Gender { get; set; }
        public string? Department { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAccept { get; set; }
        public DateTime DateOfKick { get; set; }
        public int WorkingTime { get; set; }
        public int Salary { get; set; }
        public string? Inn { get; set; }
        public string? Snils { get; set; }
        public int SerialNumberOfPassport { get; set; }
        public int NumberOfPassport { get; set; }
        public string? IssuedBy { get; set; }
        public DateTime DateOfIssued { get; set; }
        public string? Citizenship { get; set; }
        public string? Registration { get; set; }
        public string? Addres { get; set; }
        public string? Mail { get; set; }
        public string? FirstPhoneNumber { get; set; }
        public string? SecondPhoneNumber { get; set; }
        public int BikOfBank { get; set; }
        public int CheckingNumber { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}
