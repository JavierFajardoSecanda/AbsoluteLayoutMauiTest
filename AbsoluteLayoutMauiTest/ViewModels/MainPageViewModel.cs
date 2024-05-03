using AbsoluteLayoutMauiTest.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;


namespace AbsoluteLayoutMauiTest.ViewModels
{
    class MainPageViewModel : ObservableObject
    {
        public ObservableRangeCollection<MyItem> MyItems { get; } = new ObservableRangeCollection<MyItem>();

        public MainPageViewModel()
        {
            MyItems.Add(new MyItem() {FirstName = "Uno"});
            MyItems.Add(new MyItem() { FirstName = "Dos" });
            MyItems.Add(new MyItem() { FirstName = "Tres" });
        }
    }

    internal class MyItem : ObservableObject
    {
        
        private string _firstName;
        
        
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

    }
}
