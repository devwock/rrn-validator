using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RrnTest
{
    public class DataCreator
    {
        /*
         *
         *
         * UNDER CONSTRUCTION!!!
         *
         *
         *
         */

        private Random rand { get; set; } = new Random();
        private const string numbers = "01234567890";

        private DateTime GetRandomDay()
        {
            DateTime start = new DateTime(1900, 1, 1);
            DateTime end = new DateTime(2099, 12, 31);
            int range = (end - start).Days;
            return start.AddDays(rand.Next(range));
        }

        private string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(numbers, length).Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        /**
         * <summary>1900 ~ 2099년 사이의 생년월일 생성</summary>
         * <returns>1900 ~ 2099년 사이의 생년월일</returns>
         * <example>111111</example>
         */

        public string GetBirthday()
        {
            return GetRandomDay().ToString("yyyyMMdd");
        }

        /**
         * <summary>랜덤한 잘못된 생년월일 생성/summary>
         * <returns>잘못된 생년월일</returns>
         * <example>222222</example>
         */

        public string GetInvalidBirthday()
        {
            while (true)
            {
            }
            string randBirthday = GetRandomString(6);
        }

        /**
         * <summary>1900 ~ 2099년 사이의 생년월일 + 주민번호 첫자리 생성</summary>
         * <returns>1900 ~ 2099년 사이의 생년월일 + 주민번호 첫자리</returns>
         * <example>1111111</example>
         */

        public string GetRrnFirst()
        {
            return null;
        }

        /**
         * <summary>랜덤한 잘못된 생년월일 + 주민번호 첫자리 생성/summary>
         * <returns>잘못된 생년월일 + 주민번호 첫자리</returns>
         * <example>2222222</example>
         */

        public string GetInvalidRrnFirst()
        {
            return GetRandomString(7);
        }

        /**
         * <summary>주민등록번호 생성</summary>
         * <returns>주민등록번호</returns>
         * <example>1111111111118</example>
         */

        public string GetRrn()
        {
            return null;
        }

        /**
         * <summary>잘못된 주민등록번호 생성</summary>
         * <returns>잘못된 주민등록번호</returns>
         * <example>1111111111111</example>
         */

        public string GetInvalidRrn()
        {
            return null;
        }
    }
}