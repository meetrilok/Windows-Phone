using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace SqliteTutorial
{
    public class DataBaseController
    {
        public static void createTable()
        {
            using (var connection = new SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"CREATE TABLE IF NOT EXISTS Student (
                                                ID NVARCHAR(10),
                                                NAME NVARCHAR(50),
                                                CGPA NVARCHAR(10));"))
                {
                    statement.Step();
                }
            }
        }

        public static void insertData(string param1, string param2, string param3)
        {
            try 
            { 
            using (var connection = new SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"INSERT INTO Student (ID,NAME,CGPA)
                                            VALUES(?, ?,?);"))
                {
                    statement.Bind(1, param1);
                    statement.Bind(2, param2);
                    statement.Bind(3, param3);

                    // Inserts data.
                    statement.Step();

                  
                    statement.Reset();
                    statement.ClearBindings();


                }
            }

            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception\n"+ex.ToString());
            }
        }

        public static ObservableCollection<Student> getValues()
        {
             ObservableCollection<Student> list = new ObservableCollection<Student>();

            using (var connection = new SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"SELECT * FROM Student;"))
                {
                    
                    while (statement.Step() == SQLiteResult.ROW)
                    {
 
                        list.Add(new Student()
                        {
                            Id = (string)statement[0],
                            Name = (string)statement[1],
                            Cgpa = statement[2].ToString()
                        });

                        Debug.WriteLine(statement[0]+" ---"+statement[1]+" ---"+statement[2]);
                    }
                }
            }
            return list;
        }

        public static void dropTable()
        {
            using (var connection = new SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DROP TABLE Student"))
                {
                    statement.Step();
                }
            }
        }

        public static void delete(string id)
        {
            using (var connection = new SQLiteConnection("Storage.db"))
            {
                using (var statement = connection.Prepare(@"DELETE FROM Student WHERE ID=?"))
                {
                    
                    statement.Bind(1, id);
                    statement.Step();
                }
              //  getValues();
            }
        }
    }
}
