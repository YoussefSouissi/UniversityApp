namespace UniversityApp.Views;

public partial class UniversityInfoView : ContentView
{
	public UniversityInfoView(string UnivName , string UnivSite)
	{
		InitializeComponent();
		UniversityName.Text = UnivName;
		UniversitySite.Text = UnivSite;
	}
}