using redraven.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redraven.Helper
{
    public static class Search
    {
        public static void FilterExerciseListUsingEntry(Entry entry, int minimumLength, List<Exercise> exercises, CollectionView collectionView)
        {
            if (entry.Text.Length >= minimumLength)
            {
                string[] words = entry.Text.ToLower().Replace("-", " ").Split(' ');
                var foundExercise = exercises;
                foreach (var word in words)
                {
                    foundExercise = foundExercise.Where(x => x.Name.Replace("-", " ").ToLower().Contains(word) || (x.AlternativeName != null && String.Join(",", x.AlternativeName).ToLower().Contains(word))).ToList();
                }
                Device.BeginInvokeOnMainThread(() => {
                    collectionView.ItemsSource = foundExercise;
                });
                return;
            }
            Device.BeginInvokeOnMainThread(() => {
                collectionView.ItemsSource = exercises;
            });
        }
    }
}