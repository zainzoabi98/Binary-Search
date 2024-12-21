using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Binary Search



            //חישוב קצב קטיפת תפוח בשבוע
            int[] apples1 = { 3, 6, 7 };
            int h1 = 8;
            Console.WriteLine("Example 1 Output: " + MinHarvestRate(apples1, h1));

            int[] apples2 = { 25, 9, 23, 8, 3 };
            int h2 = 5;
            Console.WriteLine("Example 2 Output: " + MinHarvestRate(apples2, h2));


            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////
            ///חיפוש ערך בתוך מערך ממוין 
            //יש סיכוי בגלל סיבוב שהערכים לא בהכרח ממוינים אחד אחרי השיני
            //צריך להחזיר את המיקום של הערך שמחפשים

            int[] nums1 = { 4, 5, 6, 7, 0, 1, 2 };
            int target1 = 0;
            Console.WriteLine("Example 1 Output: " + Search(nums1, target1));  // Output: 4

            int[] nums2 = { 4, 5, 6, 7, 0, 1, 2 };
            int target2 = 3;
            Console.WriteLine("Example 2 Output: " + Search(nums2, target2));  // Output: -1













        }


        public static int MinHarvestRate(int[] apples, int h)
        {
            int left = 1; // הקצב האיטי ביותר
            int right = GetMax(apples); // הקצב המהיר ביותר
            int result = right; // נתחיל בהנחה שהקצב המקסימלי הוא הפתרון

            while (left <= right)
            {
                int mid = left + (right - left) / 2; // חישוב אמצע
                if (CanFinish(apples, h, mid))
                {
                    result = mid; // הקצב אפשרי, ננסה להקטין אותו
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1; // הקצב לא מספיק, נעלה אותו
                }
            }

            return result;
        }

        // פונקציה שבודקת אם אפשר לסיים בזמן עם קצב מסוים
        private static bool CanFinish(int[] apples, int h, int rate)
        {
            int hoursNeeded = 0;
            foreach (int apple in apples)
            {
                hoursNeeded += (int)Math.Ceiling((double)apple / rate); // עיגול כלפי מעלה
            }
            return hoursNeeded <= h;
        }

        // פונקציה למציאת הערך המקסימלי במערך
        private static int GetMax(int[] array)
        {
            int max = array[0];
            foreach (int num in array)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }





        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////
        ///חיפוש ערך בתוך מערך ממוין 
        //יש סיכוי בגלל סיבוב שהערכים לא בהכרח ממוינים אחד אחרי השיני
        //צריך להחזיר את המיקום של הערך שמחפשים
        public static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;  // מצאנו את המטרה, החזר את האינדקס.
                }

                // בדוק אם החלק הראשון ממויין
                if (nums[left] <= nums[mid])
                {
                    // אם המטרה נמצאת בחלק הראשון
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                // אם החלק השני ממויין
                else
                {
                    // אם המטרה נמצאת בחלק השני
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;  // אם לא מצאנו את המטרה
        }


    }
}

