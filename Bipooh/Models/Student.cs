using Bipooh.Models;
using Bipooh.Services;
using System;
public class Student 
{
    public long Id { get; set; }
    public string? _lastName = "User";
    //public long HomeworkID { get; set; }
    public string? LastName { get { return _lastName; } set { _lastName = value; } }

    public string? _firstName = "Name";
    public string? FirstName { get { return _firstName; } set { _firstName = value; } }
   
    public string? _schoolName = "Name";
    public string? SchoolName { get { return _schoolName; } set { _schoolName = value; } }

    public long catalogueID { get; set; }
}
