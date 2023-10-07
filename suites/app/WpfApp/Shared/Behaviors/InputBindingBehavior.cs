using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Mov.Suite.WpfApp.Shared.Behaviors
{
    /// <summary>
    /// インプットバインディングのビヘイビア
    /// </summary>
    public static class InputBindingsBehavior
    {
        #region property

        public static readonly DependencyProperty TakesInputBindingPrecedenceProperty =
        DependencyProperty.RegisterAttached("TakesInputBindingPrecedence",
            typeof(bool),
            typeof(InputBindingsBehavior),
            new PropertyMetadata(false, OnTakesInputBindingPrecedenceChanged));

        #endregion property

        #region method

        public static bool GetTakesInputBindingPrecedence(FrameworkElement obj)
        {
            return (bool)obj.GetValue(TakesInputBindingPrecedenceProperty);
        }

        public static void SetTakesInputBindingPrecedence(FrameworkElement obj, bool value)
        {
            obj.SetValue(TakesInputBindingPrecedenceProperty, value);
        }

        #endregion method

        #region event

        private static void OnTakesInputBindingPrecedenceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement frameworkElement)
            {
                frameworkElement.Loaded += OnLoaded;
                return;
            }
            if (d is UIElement uiElement)
            {
                uiElement.PreviewKeyDown += new KeyEventHandler(OnPreviewKeyDown);
                return;
            }
        }

        private static void OnLoaded(object sender, RoutedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            frameworkElement.Loaded -= OnLoaded;

            var window = Window.GetWindow(frameworkElement);
            if (window == null)
            {
                return;
            }

            // Move input bindings from the FrameworkElement to the window.
            for (int i = frameworkElement.InputBindings.Count - 1; i >= 0; i--)
            {
                var inputBinding = (InputBinding)frameworkElement.InputBindings[i];
                window.InputBindings.Add(inputBinding);
                frameworkElement.InputBindings.Remove(inputBinding);
            }
        }

        private static void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uiElement = (UIElement)sender;

            var foundBinding = uiElement.InputBindings
                .OfType<KeyBinding>()
                .FirstOrDefault(kb => kb.Key == e.Key && kb.Modifiers == e.KeyboardDevice.Modifiers);

            if (foundBinding != null)
            {
                e.Handled = false;
                if (foundBinding.Command.CanExecute(foundBinding.CommandParameter))
                {
                    foundBinding.Command.Execute(foundBinding.CommandParameter);
                }
            }
        }

        #endregion event
    }
}
