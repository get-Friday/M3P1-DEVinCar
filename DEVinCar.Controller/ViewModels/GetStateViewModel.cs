using DEVinCar.Controller.Models;

namespace DEVinCar.Controller.ViewModels {
    public class GetStateViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }

        public virtual List<string> Cities { get; set; }

        public GetStateViewModel(int id, string name, string intials) {
            Id = id;
            Name = name;
            Initials = intials;
            Cities = new List<string>();
        }
    }
}
