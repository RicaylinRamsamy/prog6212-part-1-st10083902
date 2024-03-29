﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace prog6212_task_1.Models
{
    class Module : INotifyPropertyChanged
    {
        public String code { get; private set; }
        public String name { get; private set; }
        public int num_of_credits { get; private set; }
        public int class_hours_per_week { get; private set; }
        public int semester_num_of_weeks { get; private set; }
        public int recommended_self_study_hours_per_week { get; private set; }

        // Hold all the dates studying occured in and for how long.
        public Dictionary<DateOnly, int> study_dates { get; private set; }

        public Module(string code, string name, int num_of_credits, int class_hours_per_week, int semester_num_of_weeks)
        {
            this.code = code;
            this.name = name;
            this.num_of_credits = num_of_credits;
            this.class_hours_per_week = class_hours_per_week;
            this.semester_num_of_weeks = semester_num_of_weeks;
            recommended_self_study_hours_per_week = ((num_of_credits * 10) / semester_num_of_weeks) - class_hours_per_week;
            study_dates= new Dictionary<DateOnly, int>();
        }


        // Set the hours studied for a specific date
        public void setHoursStudied(int hours_studied, DateOnly date)
        {

            if (study_dates.ContainsKey(date))
            {
                study_dates[date] = hours_studied;
            } else
            {
                study_dates.Add(date, hours_studied);
            }

            OnPropertyChanged(nameof(study_dates));
            OnPropertyChanged(nameof(getRemainingSelfStudyHoursThisWeek));
        }


        // Get the total hours studied this week
        public int getHoursStudiedThisWeek
        {
            get
            {
                DateTime today = DateTime.Today;
                DateOnly startOfWeek = DateOnly.FromDateTime(today.AddDays(-(int)today.DayOfWeek + 1));
                DateOnly endOfWeek = startOfWeek.AddDays(6);

                var filtered = study_dates.Where(kvp => kvp.Key >= startOfWeek && kvp.Key <= endOfWeek)
                             .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                return filtered.Values.Sum();
            }
        }


        // Get how many hours of studying are left from the recommended
        public int getRemainingSelfStudyHoursThisWeek
        {

            get
            {
                int remaining = recommended_self_study_hours_per_week - getHoursStudiedThisWeek;
                return remaining < 0 ? 0 : remaining; // If less than 0, return 0
            }
        }


        // Displays the module as a string for the combobox
        public override string? ToString()
        {
            return code;
        }


        // Allows the ui to update automtically when the underlying values change
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
