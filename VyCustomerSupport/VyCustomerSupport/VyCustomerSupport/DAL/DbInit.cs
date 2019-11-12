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

            if (!dbContext.QandA.Any())
            {
                SeedQandA(dbContext);
            }
        }

        private static void SeedQandA(DatabaseContext dbContext)
        {
            using (var reader = new StreamReader(@".\DAL\Files\QuestionsAnswers.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var QA = reader.ReadLine();
                    if (QA != null)
                    {
                        var columns = QA.Split("|");
                        var QAFromFile = new DbQA
                        {
                            Question = columns[0],
                            Answer = columns[1]
                        };
                        dbContext.Add(QAFromFile);
                    }
                }
            }
            dbContext.SaveChanges();
        }
    }
}