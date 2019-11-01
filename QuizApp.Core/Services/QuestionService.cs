using System;
using System.Collections.Generic;
using System.Linq;
using QuizApp.Core.Models;

namespace QuizApp.Core.Services
{
    public class QuestionService : IQuestionService
    {
        // TODO: Inherit and implement the IQuestionService interface
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;

        }

        public Question Add(Question question)
        {
            if( question.Answers.Count <2)
            {
                throw new Exception(" need more answer choices");
            }
            else
            {
                var count = question.Answers.Count(a => a.IsCorrect == true);
                  if(count!=1)
                {
                    throw new Exception("more than one correct answer");
                }
            }
            
              
                return _questionRepository.Add(question);

           

        }
        public Question Get(int id)
        {
            return _questionRepository.Get(id);
        }
        public IEnumerable<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }
        public Question Update(Question updatedQuestion)
        {

            if (updatedQuestion.Answers.Count < 2)
            {
                throw new Exception(" need more answer choices");
            }
            else
            {
                var count = updatedQuestion.Answers.Count(a => a.IsCorrect == true);
                if (count != 1)
                {
                    throw new Exception("more than one correct answer");
                }
            }
            return _questionRepository.Update(updatedQuestion);
        }
        public void Remove(int id)
        {
            var question=_questionRepository.Get(id);
            _questionRepository.Remove(question);


        }



    }
}
