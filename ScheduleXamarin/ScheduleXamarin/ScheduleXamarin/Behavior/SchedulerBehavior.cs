using Syncfusion.SfSchedule.XForms;
using Syncfusion.XForms.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        Button button;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.FindByName<SfSchedule>("schedule");
            this.button = bindable.FindByName<Button>("theme");

            this.WireEvents();
        }
        private void WireEvents()
        {
            this.button.Clicked += Theme_Clicked;
        }
        private void Theme_Clicked(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            var darkTheme = mergedDictionaries.OfType<DarkTheme>().FirstOrDefault();
            var lightTheme = mergedDictionaries.OfType<LightTheme>().FirstOrDefault();
            if (darkTheme != null)
            {
                mergedDictionaries.Remove(darkTheme);
                mergedDictionaries.Add(new LightTheme());
            }
            else
            {
                mergedDictionaries.Remove(lightTheme);
                mergedDictionaries.Add(new DarkTheme());
            }
        }
        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }
        private void UnWireEvents()
        {
            this.button.Clicked -= Theme_Clicked;
        }
    }
}



