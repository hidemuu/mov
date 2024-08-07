﻿using Reactive.Bindings;
using System;
using System.Windows.Controls;

namespace Mov.WpfMvvms.Tabs
{
    public class MenuTabModel
    {
        public int Index { get; }
        public Action TabCommand { get; }

        public ReactivePropertySlim<string> Title { get; } = new ReactivePropertySlim<string>();
        public ReactivePropertySlim<Image> IconKey { get; } = new ReactivePropertySlim<Image>();
        public ReactivePropertySlim<bool> IsSelected { get; } = new ReactivePropertySlim<bool>();

        public MenuTabModel(int index, string title, Image iconkey, Action tabcommand)
        {
            Index = index;
            TabCommand = tabcommand;
            Title.Value = title;
            IconKey.Value = iconkey;
        }
    }
}
