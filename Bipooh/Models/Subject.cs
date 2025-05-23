using System;

public class Subject
{
    //SCHOOL Subjects

    public long Id { get; set; }
    //Subject Description
    public string? _dscrp = "Description";
    public string? DSCRP { get { return _dscrp; } set { _dscrp = value; } }

    //Homework required flag
    public bool _homework = false;
    public bool Homework { get { return _homework; } set { _homework = value; } }


    //The Subject require today presence or not flag
    public bool _inSchedule = false;
    public bool InSchedule { get { return _inSchedule; } set { _inSchedule = value; } } 
    
    public long catalogueID { get; set; }

}

