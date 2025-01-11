using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public sealed class AppData
    {
        private static readonly AppData _instance = new();
        public IReadOnlyList<Product> ListProductsBD { get; private set; }

        private List<Opinion> BaseOpinions { get; } = new List<Opinion>
        {
            new Opinion(1, 0, "Carlos89", 5, "2024-01-05", ""),
            new Opinion(2, 0, "AnaMtz", 4, "2024-02-10", "Buena calidad, pero podría mejorar en algunos aspectos."),
            new Opinion(3, 0, "LuisPerez", 3, "2024-03-15", "Es aceptable, aunque he probado mejores."),
            new Opinion(4, 0, "Valeria33", 5, "2024-04-20", ""),
            new Opinion(5, 0, "PepeLucho", 2, "2024-05-12", "No cumplió mis expectativas."),
            new Opinion(6, 0, "Maria_22", 4, "2024-06-08", "Buena relación calidad-precio."),
            new Opinion(7, 0, "Juanito", 3, "2024-07-15", ""),
            new Opinion(8, 0, "SuperGaby", 5, "2024-08-05", "Supera todas mis expectativas."),
            new Opinion(9, 0, "Alfonso99", 1, "2024-09-12", "Pésima experiencia, no lo recomiendo."),
            new Opinion(10, 0, "Sandra19", 4, "2024-10-03", ""),
            new Opinion(11, 0, "LeoTech", 5, "2024-10-25", "Fantástico, volvería a comprarlo."),
            new Opinion(12, 0, "Tina95", 2, "2024-11-02", "No era lo que esperaba."),
            new Opinion(13, 0, "Pedro00", 3, "2024-11-09", "Cumple con lo básico, pero nada especial."),
            new Opinion(14, 0, "Laura88", 4, "2024-11-10", ""),
            new Opinion(15, 0, "RicardoZ", 5, "2024-11-10", "Vale cada centavo, muy satisfecho.")
        };


        //constructor privado
        private AppData() 
        {
            CargarProductos();
        }

        public static AppData Instance => _instance;

        //metodo para inicializar productos
        private void CargarProductos() 
        {
            ListProductsBD = new List<Product>
            {
                new(1,"Adaptador USB C a Ethernet","adaptador_rj45_c.jpg","WALNEW,Adaptador USB C a Ethernet, convertidor de cable adaptador USB C tipo C a RJ45 Gigabit Ethernet, adaptador de red LAN Thunderbolt 3 a RJ45 para MacBook Pro/Air, Dell XPS, Galaxy S20 S10 S9",23.27m,0),
                new(2,"Lapiz Tactil Tablet","lapiz_tablet.jpg","Lapiz para Tablet MEKO 3 en 1 Lapiz para iPad/iPhone/Samsung/Android/iOS, Lapiz Tactil Tablet de Alta Sensibilidad y Precisión con 10 Puntas de Repuesto (Negro + Oro Rosa)",9.99m,0),
                new(3,"Lenovo Tab M9","tablet.jpg","Tablet de 9\" HD, MediaTek Helio G80, 3 GB de RAM, 32 GB ampliables hasta 2 TB, 2 Altavoces, WiFi + Bluetooth 5.1, Android 12 Funda y Película - Gris",89.00m,0),
                new(4,"Mouse inalámbrico gaming","mouse_inalambrico.jpg","Ratón inalámbrico para juegos, Bluetooth, RGB, recargable, 2.4 G, USB, inalámbrico, con retroiluminación de 7 colores, 6 botones y clic silencioso para laptop, iPad, Mac OS, PC, Windows, color negro",48.14m,0),
                new(5,"Teclado inalámbrico Gaming","teclado_gaming.jpg","KLIM Chroma Wireless -  Nuevo 2024 - Teclado Gaming Ligero, Duradero, resiste al Agua, ergonómico, silencioso - Teclado Gamer PC PS4 PS5 Xbox One Mac - Negro",39.97m,0),
                new(6,"Audifonos Inalámbricos Bluetooth 5.1","audifonos_inalambricos.jpg","Auriculares Bluetooth In-Ear Audífonos Inalámbricos Deportes Deep Bass con Micrófono, Compatible con iPhone Xiaomi Samsung Huawei, Negro - 1 Hora",29.99m,0),
                new(7,"Smartwatch Haga","smartwatch.jpg","Haga y reciba Llamadas, Actividad Fitness Reloj Inteligente Hombre Mujer con Podómetro Reloj de Impermeable IP68,con 120 Deportes Modos de Reloj de Compatible para Android iOS",39.99m,0),
                new(8,"Dron Mini 3","dron.jpg","Dron Mini con cámara ligero y plegable con vídeo 4K HDR, 38 min de tiempo de vuelo, Grabación vertical y funciones inteligentes. (El control remoto se vende por separado.)",469.24m,0),
                new(9,"Audífonos De Diadema Inalámbricos","audifonos_inalambrico_diadema.jpg","STF Audífonos De Diadema Inalámbricos Aurum, Conexión 5.0, Micrófono Incorporado para Llamadas, Conexión De Cable 3.5 mm, Tiempo De Uso De hasta 10 Horas, Alcance Inalámbrico De 10 Metros (Gris)",59.99m,0),
                new(10,"Memoria USB 128GB","memoria_usb.jpg","Tipo C Memoria USB 128GB, Pendrive USB C 2 en 1 USB 3.0 128GB con hasta 40 MB/s de Velocidad de Lectura, OTG Memory Stick para Android//Pc/MacBook, Tabletas, Almacenamiento de Datos Externo (Azul)",14.99m,0)
            }.AsReadOnly();

            AsignarOpinionesAleatorias();
        }

        //Método para Asignar Opiniones Aleatoriamente
        private void AsignarOpinionesAleatorias()
        {
            Random random = new Random();

            foreach (var product in ListProductsBD)
            {
                // Determina aleatoriamente la cantidad de opiniones para este producto
                int cantidadOpiniones = random.Next(1, 15); // 1 a 5 opiniones

                // Selecciona opiniones al azar sin repetición
                var opinionesSeleccionadas = BaseOpinions
                    .OrderBy(_ => random.Next())
                    .Take(cantidadOpiniones)
                    .Select(opinion => new Opinion(
                        opinion.Id,
                        product.Id,
                        opinion.NombreUsuario,
                        opinion.Calificacion,
                        opinion.Fecha,
                        opinion.Comentario
                    )).ToList();

                // Asigna las opiniones seleccionadas al producto
                product.Opiniones = opinionesSeleccionadas;
            }
        }



    }
}
