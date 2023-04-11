namespace WebApplication1
{
    public class Product
    {
        public Product() { }

        public Product(int id, string title, double price, string description,
            string category, string image) { 
            this.id = id;
            this.title = title;
            this.price = price;
            this.description = description;      
            this.category = category;
            this.image = image;
        }

        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }

    }

  }

