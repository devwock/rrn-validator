using System;
using System.Linq;

namespace RrnValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RrnValidator rrnValidator = new RrnValidator();
            Console.WriteLine("주민등록번호/외국인등록번호를 입력하세요");
            string numbers = Console.ReadLine();
            numbers = numbers.Replace("-", "");
            bool isCorrect = false;
            switch (numbers.Length)
            {
                case 6:
                    isCorrect = rrnValidator.IsValidBirthday(numbers);
                    break;

                case 7:
                    isCorrect = rrnValidator.IsValidRrnFirst(numbers);
                    break;

                case 13:
                    isCorrect = rrnValidator.IsValidRrn(numbers);
                    break;
            }

            string result = isCorrect ? "올바른 주민번호입니다." : "틀린 주민번호입니다.";
            Console.WriteLine(result);
        }
    }
}