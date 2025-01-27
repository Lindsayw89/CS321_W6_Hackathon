﻿using System;
using System.Collections.Generic;

namespace QuizApp.ApiModels
{
    public class QuizModel
    {
        // TODO: create quiz model props
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Instructions { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }

    }
}
