
using System;
using Serilog;
using WAMWayStyles.Controls;
using Xamarin.Forms;

namespace Forms_test
{
    public class StyleTestPage : ContentPage
    {
        private AbsoluteLayout MainLayout;
        private StackLayout Stack;
        private ContentView CView;
        public StyleTestPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            MainLayout = new AbsoluteLayout();
            Stack = new StackLayout();
            CView = new ContentView();
            this.Content = MainLayout;
            AddLabel();
            AddEntry();
            AddButton();
            AddStackToLayout();
        }
        void AddStackToLayout()
        {
            MainLayout.Children.Add(Stack, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
        }
        void AddLabel()
        {
            var lbl = new HeaderLabel
            {
                Text = "Oooh I'm so stylish. Don'tcha wish your boyfriend was hot like me."
            };
            Stack.Children.Add(lbl);
        }

        void AddEntry()
        {
            var ent = new Entry
            {
                Placeholder = "Stylish Entry ;)",
            };
            ent.TextChanged += Ent_TextChanged;
            Stack.Children.Add(ent);
        }

        string entryText = null;
        private void Ent_TextChanged(object sender, TextChangedEventArgs e)
        {
            entryText = e.NewTextValue;
        }

        void AddButton()
        {
            var btn = new Button { Text = "TouchMe" };
            btn.Clicked += Btn_Clicked;
            Stack.Children.Add(btn);
        }

        private async void Btn_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryText))
            {
                try
                {
                    var strip = entryText.Trim('#');
                    for (int i = 0; i < strip.Length; i += 2)
                    {
                        var c = strip.Substring(i, 2);
                        
                        Int32 rgb = Int32.Parse(c, System.Globalization.NumberStyles.HexNumber);
                       

                    }
                }
                catch (Exception ex)
                {
                    Log.Information("bad hex input {0}", entryText);
                    await DisplayAlert("ERROR!!!!!ERROR!!!!!!", "Invalid hex color", "Okay");
                }

            }
        }

        /* Add Separate Listview page. a Page with Pickers. */
    }
}
