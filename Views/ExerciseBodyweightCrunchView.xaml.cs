﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JimuApuri.Models;
using JimuApuri.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JimuApuri.Views
{
    public partial class ExerciseBodyweightCrunchView : ContentPage
    {
        // get contents
        private ObservableCollection<ExerciseBodyweightCrunchViewModel> getContents;
        private ObservableCollection<ExerciseBodyweightCrunchViewModel> _expandedContent;

        public ExerciseBodyweightCrunchView()
        {
            InitializeComponent();

            getContents = ExerciseBodyweightCrunchViewModel.Contents;
            UpdateListContent();
        }

        // when arrow is tapped
        private void HeaderTapped(object sender, EventArgs args)
        {
            int ListselectedIndex = _expandedContent.IndexOf(((ExerciseBodyweightCrunchViewModel)((Button)sender).CommandParameter));
            getContents[ListselectedIndex].Expanded = !getContents[ListselectedIndex].Expanded;
            UpdateListContent();
        }

        // updates content
        private void UpdateListContent()
        {
            _expandedContent = new ObservableCollection<ExerciseBodyweightCrunchViewModel>();
            foreach (ExerciseBodyweightCrunchViewModel group in getContents)
            {
                ExerciseBodyweightCrunchViewModel exercises = new ExerciseBodyweightCrunchViewModel(group.Title, group.Expanded);
                exercises.ExerciseItems = group.Count;
                if (group.Expanded)
                {
                    foreach (ExerciseBodyweightCrunchModel exercise in group)
                    {
                        exercises.Add(exercise);
                    }
                }
                _expandedContent.Add(exercises);
            }
            MyListView.ItemsSource = _expandedContent;
        }
    }
}
