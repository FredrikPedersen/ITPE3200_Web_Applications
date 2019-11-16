using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VyCustomerSupport.Models.DbModels;

namespace VyCustomerSupport.DAL
{
    public class DbInit
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.EnsureCreated();

            if (!dbContext.QandAs.Any())
            {
                SeedQandA(dbContext);
            }

            if (!dbContext.UserQuestions.Any())
            {
                SeedUserQuestions(dbContext);
            }
        }

        private static void SeedQandA(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\DAL\Files\QuestionsAnswersSeed.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var QA = reader.ReadLine();
                    if (QA != null)
                    {
                        var columns = QA.Split("|");

                        var upVotesFromFile = 0;
                        var downVotesFromFile = 0;

                        if (int.TryParse(columns[2], out upVotesFromFile) &&
                            int.TryParse(columns[3], out downVotesFromFile))
                        {
                            var QAFromFile = new DbQa
                            {
                                Question = columns[0],
                                Answer = columns[1],
                                UpVotes = upVotesFromFile,
                                DownVotes = downVotesFromFile
                            };

                            dbContext.Add(QAFromFile);
                        }
                    }
                }
            }

            dbContext.SaveChanges();
        }

        private static void SeedUserQuestions(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\DAL\Files\UserQuestionsSeed.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var question = reader.ReadLine();
                    if (question != null)
                    {
                        var columns = question.Split("|");

                        var userQuestionFromFile = new DbUserQuestion
                        {
                            Username = columns[0],
                            Email = columns[1],
                            Question = columns[2]
                        };

                        dbContext.Add(userQuestionFromFile);
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}