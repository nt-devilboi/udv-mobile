namespace Task1;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnShowClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(GroupEntry.Text))
        {
            await DisplayAlertAsync("Ошибка", "Введите группу", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(FioEntry.Text))
        {
            await DisplayAlertAsync("Ошибка", "Введите ФИО", "OK");
            return;
        }

        if (FacultyPicker.SelectedIndex == -1)
        {
            await DisplayAlertAsync("Ошибка", "Выберите факультет", "OK");
            return;
        }

        var course = "";
        if (Course1Radio.IsChecked) course = "1";
        if (Course2Radio.IsChecked) course = "2";
        if (Course3Radio.IsChecked) course = "3";
        if (Course4Radio.IsChecked) course = "4";

        if (course == "")
        {
            await DisplayAlertAsync("Ошибка", "Выберите курс", "OK");
            return;
        }

        var hobbies = new List<string>();
        if (SportCheckBox.IsChecked) hobbies.Add("Спорт");
        if (MusicCheckBox.IsChecked) hobbies.Add("Музыка");
        if (GamesCheckBox.IsChecked) hobbies.Add("Игры");
        if (!string.IsNullOrWhiteSpace(HobbyEditor.Text)) hobbies.Add(HobbyEditor.Text);

        ResultLabel.Text =
            $"Группа: {GroupEntry.Text}\n" +
            $"ФИО: {FioEntry.Text}\n" +
            $"Факультет: {FacultyPicker.SelectedItem}\n" +
            $"Курс: {course}\n" +
            $"Возраст: {AgeStepper.Value}\n" +
            $"Дата поступления: {EnrollDatePicker.Date:dd.MM.yyyy}\n" +
            $"Хобби: {(hobbies.Count > 0 ? string.Join(", ", hobbies) : "нет")}";
        ResultLabel.IsVisible = true;
    }

    private void OnClearClicked(object? sender, EventArgs e)
    {
        GroupEntry.Text = "";
        FioEntry.Text = "";
        FacultyPicker.SelectedIndex = -1;
        Course1Radio.IsChecked = false;
        Course2Radio.IsChecked = false;
        Course3Radio.IsChecked = false;
        Course4Radio.IsChecked = false;
        AgeStepper.Value = 18;
        EnrollDatePicker.Date = new DateTime(2025, 9, 1);
        SportCheckBox.IsChecked = false;
        MusicCheckBox.IsChecked = false;
        GamesCheckBox.IsChecked = false;
        HobbyEditor.Text = "";
        AgreeSwitch.IsToggled = false;
        ResultLabel.Text = "";
        ResultLabel.IsVisible = false;
    }
}
