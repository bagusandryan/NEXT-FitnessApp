using redraven.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Converters
{
    public class SetToString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return "";

            if (parameter is string stringParameter)
            {
                switch (stringParameter)
                {
                    case "Description":
                        {
                            string sets = string.Empty;
                            string oneRepMax = string.Empty;
                            if (values[0] != null) sets = "Sets " + values[0];
                            if (values[1] != null && values[2] != null)
                            {
                                double weight = double.Parse(values[1].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                                int reps = int.Parse(values[2].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                                oneRepMax = "One Rep Max (1RM): " + Math.Round(OneRepMax(weight, reps), 1) + " kg";
                            }

                            return sets + MauiProgram.SeparatorText + oneRepMax;
                        }
                    case "Title":
                        {
                            string title = string.Empty;
                            for (int i = 1; i <= 2; i++)
                            {
                                if (i == 1 && values[0] != null && values[0].ToString() != "0")
                                {
                                    title = values[0].ToString() + " kg";
                                    continue;
                                }

                                if (i == 2 && values[1] != null && string.IsNullOrWhiteSpace(title))
                                {
                                    title = values[1].ToString() + " reps";
                                    continue;
                                }

                                if (i == 2 && values[1] != null && !string.IsNullOrWhiteSpace(title))
                                {
                                    title = title + " x " + values[1].ToString() + " reps";
                                    continue;
                                }
                            }

                            return title;
                        }
                }
            }

            return "";
        }

        double OneRepMax(double weight, int reps)
        {
            return weight / (1.0278 - (0.0278 * reps));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}