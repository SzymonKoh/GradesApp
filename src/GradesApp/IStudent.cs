namespace GradesApp
{
    public interface IStudent
    {
        string Name { get; set; }
        event GradeAddedDelegate GradeAdded, GradeLowerThen3;
        void AddGrade(double grade);
        void AddGrade(string grade);
        Statistics GetStatistics();
        void ShowStatistics();
    }
}