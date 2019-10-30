using System;
using System.Collections.Generic;

namespace QuizApp.ApiModels
{
    public class QuizModel
    {
        // TODO: create quiz model props
        int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; } 
        string Instructions { get; set; }
        IEnumerable<QuestionModel> Questions { get; set; }
    }
}
