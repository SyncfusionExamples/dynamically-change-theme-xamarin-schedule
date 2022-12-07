# How to dynamically change the themes in Xamarin Schedule (SfSchedule)

You can dynamically change the themes by removing the dark theme and adding the light theme in Xamarin.Forms [SfSchedule](https://www.syncfusion.com/xamarin-ui-controls/xamarin-scheduler).

**XAML**

Add the `SchedulerBehavior` class to the `Schedule`.
```
<Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="0.1*"/>
            <RowDefinition Height="0.9*"/>
        </Grid.RowDefinitions>
        <Button x:Name="theme" Text="change theme"/>
        <syncfusion:SfSchedule x:Name="schedule" 
                               Grid.Row="1" 
                               ScheduleView="MonthView">
        </syncfusion:SfSchedule>
    </Grid>
    <ContentPage.Behaviors>
        <local:SchedulerBehavior/>
    </ContentPage.Behaviors>
```
**C#**

You can change the theme at runtime by removing the dark theme and adding the light theme.
```
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
```

KB article - [How to dynamically change the themes in Xamarin Schedule (SfSchedule)](https://www.syncfusion.com/kb/12252/how-to-dynamically-change-the-themes-in-xamarin-schedule-sfschedule)