﻿using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.ApiModels;
using QuizApp.Core.Models;

namespace QuizApp.ApiModels
{
	public static class AnswerMappingExtensions
	{

		public static AnswerModel ToApiModel(this Answer answer)
		{
            // : map domain properties to equivalent ApiModel properties
            return new AnswerModel
            {
                Id = answer.Id,
                QuestionId = answer.QuestionId,
                Content = answer.Content,
                IsCorrect = answer.IsCorrect,
            };
		}

		public static Answer ToDomainModel(this AnswerModel answerModel)
		{
            // : map ApiModel properties to equivalen domain properties
			return new Answer
			{
                Id = answerModel.Id,
                QuestionId = answerModel.QuestionId,
                Content = answerModel.Content,
                IsCorrect = answerModel.IsCorrect,

                //push experiment
			};
		}

		public static IEnumerable<AnswerModel> ToApiModels(this IEnumerable<Answer> items)
		{
			return items.Select(a => a.ToApiModel());
		}

		public static IEnumerable<Answer> ToDomainModels(this IEnumerable<AnswerModel> items)
		{
			return items.Select(a => a.ToDomainModel());
		}
	}
}
