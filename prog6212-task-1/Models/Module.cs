using System;
using System.Collections.Generic;
using System.Linq;

namespace prog6212_task_1.Models
{
    class Module
    {
        private String code;
        private String name;
        private int num_of_credits;
        private int class_hours_per_week;
        private int semester_num_of_weeks;
        private int recommended_self_study_hours_per_week;
        private Dictionary<DateOnly, int> study_dates = new Dictionary<DateOnly, int>();

        public Module(string code, string name, int num_of_credits, int class_hours_per_week, int semester_num_of_weeks)
        {
            this.code = code;
            this.name = name;
            this.num_of_credits = num_of_credits;
            this.class_hours_per_week = class_hours_per_week;
            this.semester_num_of_weeks = semester_num_of_weeks;
            recommended_self_study_hours_per_week = ((num_of_credits * 10) / semester_num_of_weeks) - class_hours_per_week;
        }

        public void setHoursStudied(int hours_studied, DateOnly date)
        {

            if (study_dates.ContainsKey(date))
            {
                study_dates[date] = hours_studied;
            } else
            {
                study_dates.Add(date, hours_studied);
            }
        }

        public int getHoursStudiedThisWeek()
        {
            DateTime today = DateTime.Today;
            DateOnly startOfWeek = DateOnly.FromDateTime(today.AddDays(-(int)today.DayOfWeek + 1));
            DateOnly endOfWeek = startOfWeek.AddDays(6);

            var filtered = study_dates.Where(kvp => kvp.Key >= startOfWeek && kvp.Key <= endOfWeek)
                         .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            return filtered.Values.Sum();
        }

        public int getRemainingSelfStudyHoursThisWeek()
        {
            int remaining =  recommended_self_study_hours_per_week - getHoursStudiedThisWeek();
            return remaining < 0 ? 0 : remaining;
        }
    }
}
