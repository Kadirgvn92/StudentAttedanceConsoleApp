namespace StudentAttedanceConsoleApp;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, This is My Student List..");

        List<string> list = new List<string>()  //Burada bir liste oluşturup öğrencilerimizi ekledik.
        {
            "01 - Ahmet Yıldız",
            "02 - Mehmet Mars",
            "03 - Saadettin Teksoy",
            "04 - Haluk Levent",
            "05 - Kadir GÜVEN"
        };

        List<string> intList = new List<string>(); //Burada bir liste oluşturup öğrenci numaralarını ekledik.

        foreach (string item in list)  //Burada öğrencilerimizi teker teker ekrana yazdırdık.
        {
            Console.WriteLine(item);
        }

        List<bool> isStudentAttend = new List<bool>(new bool[list.Count]); /*burada amacım bonus 2.sorudaki tüm öğrencilerin sınıfta olup olmadığını
                                                                             kontrol ettirmekti biraz chatGDPden yardım aldım..*/
        for (int i = 0; i < isStudentAttend.Count; i++)
        {
            isStudentAttend[i] = false;
        }

        bool isAllOkey = false; //Burada bir bool oluşturup döngüde kullandım..

        while (!isAllOkey)
        {
            // Bu mantığı chatGPT ile buldum..amacım bütün öğrencileri sınıfta olduğunda işlem yapmak..
            Console.WriteLine("Please enter your student number");
            string result = Console.ReadLine();
            int intResult;
            bool isInt = int.TryParse(result, out intResult);
            if (isInt == false) //Burada amacım girdinin sayı olup olmadığını kontrol etmek değilse hata verdirmek..
            {
                Console.WriteLine("You didnt enter integer value, try again!!");
            }
            else
            {
                Console.WriteLine("Right!! You enter integer value");
                Console.WriteLine("-------------------------------");

                //Burada girdinin sayı olduğunu onayladık 
                //sonra yeni bir bool oluşturup döngü ile öğrencilerin sınıfta olup olmadığını kontrol etmek..
                for (int i = 0; i < list.Count; i++)
                {
                    string number = new string(list[i].Where(char.IsDigit).ToArray());
                    intList.Add(number);

                    if (result.Equals(number))
                    {

                        if (isStudentAttend[i] == false)
                        {
                            Console.WriteLine(list[i] + " is in the class..");
                            isStudentAttend[i] = true;
                        }
                        else
                        {
                            Console.WriteLine(list[i] + " is already in the class, Please try to enter other students numbers");
                        }
                    }
                }
            }
            if (isStudentAttend.TrueForAll(status => status))
            {
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("All students are in the class sir");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                isAllOkey = true;
            }
        }
    }
}



