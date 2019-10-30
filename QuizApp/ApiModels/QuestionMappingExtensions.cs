using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.ApiModels;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class QuestionMappingExtensions
	{

		public static QuestionModel ToApiModel(this Question question)
		{
            // TODO: map domain properties to equivalent apiModel properties
            // Id
            // QuestionType
            // Prompt
            // Answers
            return new QuestionModel
            {
                // HINT: Answers = item.Answers?.ToApiModels().ToList()
                Id = question.Id,
                QuestionType = question.QuestionType,
                Prompt = question.Prompt,
                Answers = question.Answer,
            };
        }

		public static Question ToDomainModel(this QuestionModel questionModel)
		{
            // TODO: map api model props to equivalent domain props
            // Id
            // QuestionType
            // Prompt
            // Answers
            return new Question
            {
                // HINT: Answers is similar to above, but uses Domain Models
                // HINT: you can ignore QuizQuestions
                Id = questionModel.Id,
                QuestionType = questionModel.QuestionType,
                Prompt = questionModel.Prompt,
                Answer = questionModel.Amswer,
			};
		}

		public static IEnumerable<QuestionModel> ToApiModels(this IEnumerable<Question> items)
		{
			return items.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Question> ToDomainModels(this IEnumerable<QuestionModel> items)
		{
			return items.Select(a => a.ToDomainModel());
		}
	}
}
