namespace UniSelector.Models;

public class UniversityFilter
{
    public string UniversityType { get; set; }
    public string Faculty { get; set; }
    public string Major { get; set; }
    public double? MinimumGrade { get; set; }
    public double? IeltsScore { get; set; }
    public double? ToeflScore { get; set; }
    public string HighSchoolPath { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
    public int? MaxRank { get; set; }
    public int? StudyDuration { get; set; }
    public bool? RequiresAptitudeTest { get; set; }
}