using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInheritanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.WriteLine("Enter a value for the DataFileID");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter a value for the Field");
                int field = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter a value for the OtherField");
                string otherfield = Console.ReadLine();

                Console.WriteLine("Is this a DataFileStore? (If not, it will be a DataFileEditor)");
                Console.WriteLine("y/n");
                bool isStore = Console.ReadLine() == "y";

                using (var db = new Context())
                {
                    if (isStore)
                    {
                        var Store = new DataFileStore
                        {
                            Id = id,
                            MyDataField = field,
                            MyOtherDataField = otherfield
                        };
                        db.DataFileParents.Add(Store);
                        db.SaveChanges();
                    }
                    else
                    {
                        var Editor = new DataFileEditor
                        {
                            Id = id,
                            MyDataField = field,
                            MyOtherDataField = otherfield
                        };
                        db.DataFileParents.Add(Editor);
                        db.SaveChanges();
                    }
                }

                Console.WriteLine("Would you like to create another?");
                run = Console.ReadLine() == "y";
            }


            Console.WriteLine("Would you like to view all?");
            if (Console.ReadLine() == "y")
            {
                using (var db = new Context())
                {
                    var dataFiles = db.DataFileParents.ToList();
                    dataFiles.ForEach(d =>
                    {
                        Console.WriteLine(d.Id);
                        Console.WriteLine(d.MyDataField);
                        Console.WriteLine(d.MyOtherDataField);
                        Console.WriteLine();
                    });
                }
                Console.ReadKey();
            }
        }
    }
}
