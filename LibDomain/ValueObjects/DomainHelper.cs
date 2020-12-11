using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.ValueObjects
{
    public class DomainHelper
    {
        public static string CheckDate(string date) {
            string data = date;
            try
            {
                DateTime edDatetime;
                edDatetime = Convert.ToDateTime(data);
            }
            catch (Exception ex)
            {
                string debug = data.Remove(data.Length - 1, 1);
                data = debug + "0";
            }
            return data;
        }

        public static string createDay(object SelectedYear, object SelectedMonth, object SelectedDay)
        {
            // TODO YYYY-MM-DDに変換
            DayObject month = new DayObject(Convert.ToString(SelectedMonth));
            DayObject day = new DayObject(Convert.ToString(SelectedDay));
            return (Convert.ToString(SelectedYear) + "-" + month.InputDay + "-" + day.InputDay);
        }

        public static string createDay(object SelectedYear, string month, string day)
        {
            // TODO YYYY-MM-DDに変換
            return (Convert.ToString(SelectedYear) + "-" + month + "-" + day);
        }
    }
}
