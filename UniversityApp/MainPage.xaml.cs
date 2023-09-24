using System.Net.Http.Headers;
using UniversityApp.Controller;
using UniversityApp.Models;
using static System.Net.WebRequestMethods;

namespace UniversityApp;

public partial class MainPage : ContentPage
{
	private List<Rootobject> rootObjects;
	private HttpHelper httpHelper;
	public MainPage()
	{
		InitializeComponent();
		rootObjects = new List<Rootobject>();
        httpHelper = new HttpHelper();
    }

	private void SearchUniversity(object sender, EventArgs e)
	{
		if (CountryName.Text != null)
		{
			LoadData(CountryName.Text);
		}
        else
        {
            // Show an alert when the country name is empty
            DisplayAlert("Error", "Please enter the name of your country.", "OK");
        }
    }

    private async void LoadData(string CountryName)
    {
        // Show the loading animation while fetching the data
        LoadingIndicator.IsRunning = true;
        LoadingIndicator.IsVisible = true;

        // Clear Search Results layout
        rootObjects.Clear();
        Container.Clear();

        // Get Response
        var response = await httpHelper.GetResponseAsync("http://universities.hipolabs.com/search?country=" + CountryName);

        // Converts JSON results into a List of objects of type Rootobject
        rootObjects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Rootobject>>(response);

        // Add results in container
        for (int i = 0; i < rootObjects.Count; i++)
        {
            var item = rootObjects[i];
            Container.Add(new Views.UniversityInfoView(item.name, item.web_pages[0]));
        }

        // Hide the loading animation after data retrieval
        LoadingIndicator.IsRunning = false;
        LoadingIndicator.IsVisible = false;
    }
}


