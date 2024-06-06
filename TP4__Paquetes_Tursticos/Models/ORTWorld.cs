public static class ORTWorld
{
    public static List<string> ListaDestinos {get; private set;} = new List<string>() {
            "Buenos Aires", 
            "Río de Janeiro", 
            "París",
            "Nueva York",
            "Tokio",
            "Roma",
            "Londres",
            "Miami",
            "Barcelona",
            "Dubái"};
    public static List<string> ListaHoteles {get; private set;} = new List<string>(){
            "Hotel Plaza",
            "Hotel Hilton",
            "Hotel Sheraton",
            "Hotel Intercontinental",
            "Hotel Marriott"};
    public static List<string> ListaAereos {get; private set;} = new List<string>(){
            "../img/AA.jpg",
            "../img/Iberia.jpg",
            "../img/Lufthansa.jpg",
            "../img/Emirates.jpg",
            "../img/United.jpg"};
    public static List<string> ListaExcursiones {get; private set;} = new List<string>(){
            "../img/Excursion-tigre.jpg",
            "../img/Excursion-centralpark.jpg",
            "../img/Excursion-crucerocena.png",
            "../img/Excursion-gastronomica.jpg",
            "../img/Excursion-vaticano.jpg"};
    public static Dictionary<string, Paquete> Paquetes {get; private set;}


    public static bool IngresarPaquete(string destinoSeleccionado, Paquete paquete)
    {
        bool a = true;
        if(Paquetes.ContainsKey(destinoSeleccionado))
        {
            a = false;
        }
        else
        {
            Paquetes.Add(destinoSeleccionado, paquete);
        }
        return a;
    }
}