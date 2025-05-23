using Bipooh.Services;

namespace Bipooh.Models
{
    public class Catalogue 
    {

        public long Id { get; set; }
        //Subject Description
        public string? _dscrp = "Description";
        public string? DSCRP { get { return _dscrp; } set { _dscrp = value; } }

        //Subject Grade
        public decimal? _grd;
        public decimal? GRD { get { return _grd; } set { _grd = value; } }

        //Number of Absences
        public decimal? _nbAbsences;
        public decimal? NbAbsences { get { return _nbAbsences; } set { _nbAbsences = value; } }

        //Number of Attendance
        public decimal? _nbAttendances;
        public decimal? NbAttendances { get { return _nbAttendances; } set { _nbAttendances = value; } }

        //public long StudentId { get; set; }
        //public long SubjectId { get; set; }

        public List<Subject> subjects { get; set; }

        public List<Student> students { get; set;}
    }
}
