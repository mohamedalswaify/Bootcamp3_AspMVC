using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp3_AspMVC.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [DisplayName("pass")]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }


        public int TypeUser { get; set; } = 2; // 1->admin  2->user

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }



        [ForeignKey("Job")]
        public int? JobId { get; set; }

        public Job? Job { get; set; }



    }
}
