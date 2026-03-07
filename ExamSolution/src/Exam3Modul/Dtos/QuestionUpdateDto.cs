namespace Exam3Modul.Dtos;

public class QuestionUpdateDto
{
    public Guid QuestionId { get; set; }
    public string Text { get; set; }
    public string QuestionName { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Answer { get; set; }
}
