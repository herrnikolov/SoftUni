namespace BashSoft
{
    public class StartUp
    {
        public static void Main()
        {
            //IOManager.TraverseDirectory(0);
            
            //StudentsRepository.InitializeData();
            //StudentsRepository.InitializeData(@"Files/dataNew.txt");

            //StudentsRepository.GetAllStudentsFromCourse("Unity");
            //StudentsRepository.GetStudentScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContent(@"E:\GitHub\SoftUni_-_CSharp_Advanced_-_Jan_2018\05. BashSoft\BashSoft\BashSoft\Files\test2.txt", @"E:\GitHub\SoftUni_-_CSharp_Advanced_-_Jan_2018\05. BashSoft\BashSoft\BashSoft\Files\test3.txt");


            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(1);

            //IOManager.CreateDirectoryInCurrentFolder("*2");

            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            
            InputReader.StartReadingCommands();
        }
    }
}
