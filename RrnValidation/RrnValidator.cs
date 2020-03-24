using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace RrnValidation
{
    public class RrnValidator
    {
        /**
         * 주민등록번호/외국인등록번호 뒷 첫 자리
         *
         * 1/2: 1900~1999년 사이에 탄생한 내국인
         * 3/4: 2000~2099년 사이에 탄생한 내국인
         * 5/6: 1900~1999년 사이에 탄생한 외국인
         * 7/8: 2000~2099년 사이에 탄생한 외국인
         * 9/0: 1800~1899년 사이에 탄생한 내국인
         */
        private static readonly int[] ssnFirstCode = { 1, 2, 3, 4, 5, 6, 7, 8 };

        /**
         * 외국인등록번호 뒷 첫 자리
         *
         * 5/6: 1900~1999년 사이에 탄생한 외국인
         * 7/8: 2000~2099년 사이에 탄생한 외국인
         */
        private static readonly int[] foreignFirstCode = { 5, 6, 7, 8 };

        /**
         * 외국인등록번호 중 뒤 6섯번째 분류코드
         *
         * 7: 외국 국적 동포
         * 8: 재외국인
         * 9: 외국인
         */
        private static readonly int[] foreignClassCode = { 7, 8, 9 };

        private bool IsInputValid(string rrn, int length)
        {
            if (string.IsNullOrWhiteSpace(rrn))
            {
                return false;
            }

            if (rrn.Length != length)
            {
                return false;
            }

            if (length > 9)
            {
                return int.TryParse(rrn, out int rrnNumber);
            }
            else
            {
                return ulong.TryParse(rrn, out ulong rrnNumber);
            }
        }

        public bool IsValidBirthday(string rrn)
        {
            if (!IsInputValid(rrn, 6))
            {
                return false;
            }

            DateTime temp;
            bool isValid = DateTime.TryParseExact(rrn, "yyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp);
            if (isValid)
            {
                return true;
            }
            return false;
        }

        public bool IsValidRrnFirst(string rrn)
        {
            if (!IsInputValid(rrn, 7))
            {
                return false;
            }

            string birthday = rrn.Substring(0, 6);
            int lastRrnNumber = int.Parse(rrn.Substring(6, 1));

            if (!ssnFirstCode.Contains(lastRrnNumber))
            {
                return false;
            }

            return IsValidBirthday(birthday);
        }

        public bool IsValidRrn(string rrn)
        {
            if (!IsInputValid(rrn, 13))
            {
                return false;
            }

            string birthdayAndFirst = rrn.Substring(0, 7);
            int[] firstRrnNumber = rrn.Substring(0, 6).Select(c => c - '0').ToArray();
            int[] lastRrnNumber = rrn.Substring(6, 7).Select(c => c - '0').ToArray();

            bool isValid = IsValidRrnFirst(birthdayAndFirst);
            if (!isValid)
            {
                return false;
            }

            if (foreignFirstCode.Contains(lastRrnNumber[0]))
            {
                int orgCode = lastRrnNumber[1] * 10 + lastRrnNumber[2];
                if (orgCode % 2 != 0)
                {
                    return false;
                }

                if (!foreignClassCode.Contains(lastRrnNumber[5]))
                {
                    return false;
                }
            }

            int calculated = firstRrnNumber[0] * 2 + firstRrnNumber[1] * 3 + firstRrnNumber[2] * 4 + firstRrnNumber[3] * 5 + firstRrnNumber[4] * 6 + firstRrnNumber[5] * 7
                            + lastRrnNumber[0] * 8 + lastRrnNumber[1] * 9 + lastRrnNumber[2] * 2 + lastRrnNumber[3] * 3 + lastRrnNumber[4] * 4 + lastRrnNumber[5] * 5;

            int result = 11 - (calculated % 11);
            if (result >= 10)
            {
                result %= 10;
            }

            if (foreignFirstCode.Contains(lastRrnNumber[0]))
            {
                result += 2;
                result %= 10;
            }

            if (result == lastRrnNumber.Last())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static readonly int[] crnCheckId = { 1, 3, 7, 1, 3, 7, 1, 3, 5 };

        public static bool IsValidCrn(string crn)
        {
            if (crn.Length != 10)
            {
                return false;
            }

            int[] crnNumber = crn.Select(c => c - '0').ToArray();
            int checkSum = 0;
            for (int i = 0; i < 9; i++)
            {
                checkSum += crnCheckId[i] * crnNumber[i];
            }
            int checkSum2 = Convert.ToInt32(Math.Floor(Convert.ToDecimal(crnNumber[8] * crnCheckId[8]) / 10));
            checkSum += checkSum2;
            var result = 10 - (checkSum % 10);
            if (result >= 10)
            {
                result %= 10;
            }
            if (crnNumber[9] == result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}