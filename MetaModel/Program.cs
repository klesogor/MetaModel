using MetaModel.Core;
using System;
using System.Linq;

namespace MetaModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = MetaModelRepository<StudentModel>.GetInstance();
            var student = new StudentModel() {
                CardNumber = 22,
                Name = "Test Student"
            };
            repo.Save(new StudentModel() { CardNumber = 11, Name = "Fake like my existance" });
            repo.Save(student);
            
            var all = repo.GetAll().ToList();

            var item = all[0];

            var byId = repo.GetById(student.Id);

            byId.Name = "ById";
            repo.Save(byId);

            foreach (var obj in all) {
                repo.Delete(obj);
            }

            var empty = repo.GetAll().ToList();


            Console.WriteLine("Done showcase");
            Console.ReadLine();
        }
    }
}
