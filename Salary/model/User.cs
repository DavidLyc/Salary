using System;

namespace Salary.model
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Education { get; set; }
        public string JobTitle { get; set; }  //职称
        public string HireDate { get; set; }
        public string PostName { get; set; }   //岗位编号
        public string Salary { get; set; }
        public string Password { get; set; }
        public string DepartmentName { get; set; }   //部门编号

        public User(string id, string name, string sex, string education, string jobTitle, string hireDate, string postName
                      , string password, string departmentName)
        {
            Id = id;
            Name = name;
            Sex = sex;
            Education = education;
            JobTitle = jobTitle;
            HireDate = hireDate;
            PostName = postName;
            Password = password;
            DepartmentName = departmentName;
        }

    }
}