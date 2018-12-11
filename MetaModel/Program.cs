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
            var me = new StudentModel() {
                CardNumber = 22,
                Name = "@klesogor did whole stuff on his own, shame on you!"
            };
            repo.Save(new StudentModel() { CardNumber = 11, Name = "Fake like my existance" });
            repo.Save(me);
            
            var all = repo.GetAll();

            var item = all.ToList()[0];


            Console.WriteLine("Saved successfully!");
            Console.ReadLine();
        }
    }
}
